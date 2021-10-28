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


		async void toolStripButton1_Click( object sender, EventArgs e ) {
			var steamPath = getSteamFolder();

			var fo4path = $@"{steamPath}\steamapps\common\{m_selectNodePreset.title.name}";

			if( !fo4path.isExistsDirectory() ) return;

			Environment.CurrentDirectory = fo4path;

			var path = m_selectNodePreset.fullPath;
			var files = Directory.GetFiles( path, "*", SearchOption.AllDirectories );

			toolStripButton1.Enabled = false;

			setNotifyText( S.MsgInstallNow.format( m_selectNodePreset.name ) );
			toolStripProgressBar1.Visible = true;
			toolStripProgressBar1.Value = 0;
			toolStripProgressBar1.Step = (int)((100000.0f / files.Length)+0.5f);
			await Task.Run(()=> {
				foreach( var p in files ) {
					var pname = p.Remove( 0, path.Length + 1 );
					fs.cp( p, pname );
					Invoke( new Action( () => {
						toolStripProgressBar1.PerformStep();
					} ) );
				}
			} );

			// 内部的にはコピー完了していてもPerformStep呼び出しの結果反映が画面に出るまでラグがある
			// 見た目上プログレスバーの表示が100%になってから終了したいので適当に待つ
			// PC環境依存の可能性もあるので微妙かもしれない
			await Task.Run( () => {
				Thread.Sleep( 500 );
			} );

			
			toolStripProgressBar1.Visible = false;
			setNotifyText( S.MsgInstall.format( m_selectNodePreset.name ) );

			initTreeView();
		}


		void toolStripButton2_Click( object sender, EventArgs e ) {
			var steamPath = getSteamFolder();

			var gamePath = $@"{steamPath}\steamapps\common\{m_selectNodePreset.title.name}";

			if( gamePath.isExistsDirectory() ) {
				//Debug.Log( fo4path );
				Environment.CurrentDirectory = gamePath;

				foreach( var p in m_selectNodePreset.m_targetFileName ) {
					//if(p.isExistsFile()) {
					//	Debug.Log( p );
					//}
					fs.rm( p );
				}

				fs.rm( "enbseries", true );
				fs.rm( $".{m_selectNodePreset.name}" );
			}

			setNotifyText( S.Uninstall.format( m_selectNodePreset.name ) );

			initTreeView();
		}

	} // class
}
