using HananokiLib;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ENBM {

	public partial class MainForm : Form {

		void toolStripComboBox1_SelectedIndexChanged( object sender, EventArgs e ) {
			m_config.langName = m_language.languageNames[ toolStripComboBox1.SelectedIndex ];
			m_language.init();
			updateLanguage();
		}



		/// <summary>
		/// 最新の情報に更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void toolStripButton_Click_Reload( object sender, EventArgs e ) {
			makeAddGameTitleDropDownMenu();
			initTreeView();
		}


		public async void copyFiles() {
			var gamePath = m_selectNodePreset.title.getGameFolderPath(); ;

			// コピー先のディレクトリが存在しない
			if( !gamePath.isExistsDirectory() ) return;

			Environment.CurrentDirectory = gamePath;

			var path = m_selectNodePreset.fullPath;
			var files = Directory.GetFiles( path, "*", SearchOption.AllDirectories );

			await Task.Run( () => {
				foreach( var p in files ) {
					var pname = p.Remove( 0, path.Length + 1 );
					if( Helper.hasDependUpdate( p, pname ) ) {
						fs.cp( p, pname, true );
					}
				}
			} );
		}


		/// <summary>
		/// インストール
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void toolStripButton_Click_Install( object sender, EventArgs e ) {
			var steamPath = Utils.getSteamFolder();

			var gamePath = m_selectNodePreset.title.getGameFolderPath(); ;

			if( !gamePath.isExistsDirectory() ) return;

			Environment.CurrentDirectory = gamePath;

			var path = m_selectNodePreset.fullPath;
			var files = Directory.GetFiles( path, "*", SearchOption.AllDirectories );

			toolStripButton_Install.Enabled = false;

			Utils.setNotifyText( S.MSG_INSTALL_NOW.format( m_selectNodePreset.name ) );
			toolStripProgressBar1.Visible = true;
			toolStripProgressBar1.Value = 0;
			toolStripProgressBar1.Step = (int) ( ( 100000.0f / files.Length ) + 0.5f );
			await Task.Run( () => {
				foreach( var p in files ) {
					var pname = p.Remove( 0, path.Length + 1 );
					fs.cp( p, pname );
					Invoke( new Action( () => {
						toolStripProgressBar1.PerformStep();
					} ) );
				}
			} );

			if( m_config.hasEnableEnbLocal( m_selectNodePreset.title.name ) ) {
				var enblocal = $@"{m_selectNodePreset.title.fullPath}\.override\enblocal.ini";
				fs.cp( enblocal, "enblocal.ini", true );
			}

			// 内部的にはコピー完了していてもPerformStep呼び出しの結果反映が画面に出るまでラグがある
			// 見た目上プログレスバーの表示が100%になってから終了したいので適当に待つ
			// PC環境依存の可能性もあるので微妙かもしれない
			await Task.Run( () => {
				Thread.Sleep( 500 );
			} );


			toolStripProgressBar1.Visible = false;
			Utils.setNotifyText( S.MSG_INSTALL.format( m_selectNodePreset.name ) );

			initTreeView();
		}



		void toolStripButton_Click_Uninstall( object sender, EventArgs e ) {
			var steamPath = Utils.getSteamFolder();

			var gamePath = $@"{steamPath}\steamapps\common\{m_selectNodePreset.title.name}";

			if( gamePath.isExistsDirectory() ) {
				Environment.CurrentDirectory = gamePath;

				foreach( var p in m_selectNodePreset.m_targetFileName ) {
					fs.rm( p );
				}

				fs.rm( "enbseries", true );
				fs.rm( $".{m_selectNodePreset.name}" );
			}

			Utils.setNotifyText( S.UI_UNINSTALL.format( m_selectNodePreset.name ) );

			initTreeView();
		}

	} // class
}
