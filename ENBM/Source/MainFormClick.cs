using HananokiLib;
using System;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {


		/////////////////////////////////////////
		void onClick_ShowDialog( object sender, EventArgs e ) {
			var a = new Settings();
			a.ShowDialog(); ///< ブロッキング処理
			updatePanel();
		}


		/////////////////////////////////////////
		void onClick_AddGameTitle( object sender, EventArgs e ) {
			var tsi = (ToolStripItem) sender;

			var gt = tsi.getGameTitleData();

			var path = $@"{Helper.s_appPath}\{gt.folderName}";

			fs.mkDir( path );
			fs.mkDir( $@"{path}\.presets" );

			makeAddGameTitleDropDownMenu();
			initTreeView();
		}



		/////////////////////////////////////////
		void onLinkClicked_URLJump( object sender, LinkLabelLinkClickedEventArgs e ) {
			var ll = (LinkLabel) sender;
			var url = ll.getURL();
			if( url.isEmpty() ) {
				Utils.setNotifyText( "Invalid URL", NotifyType.Error );
				return;
			}

			System.Diagnostics.Process.Start( url );
		}


		/// <summary>
		/// アーカイブの展開
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void onClick_ExtractArcive( object sender, EventArgs e ) {
			void extract( ListView lv, string _outputPath ) {
				foreach( ListViewItem p in lv.Items ) {
					if( !p.Checked ) continue;
					var tag = (FilePathTag) p.Tag;
					shell.SetProcessEnvironmentPath( m_config.sevenZipPath.getDirectoryName() );
					var outputDirName = _outputPath;
					fs.mkDir( outputDirName );
					var result = shell.startProcess( m_config.sevenZipPath.getFileName(), $@"x -o{outputDirName.quote()} {tag.fullpath.quote()}" );
					if( result.exitCode != 0 ) {
						Utils.setNotifyText( result.error, NotifyType.Error );
					}

				}
			}


			var folder = "New Preset";
			foreach( ListViewItem pp in listView2.Items ) {
				if( !pp.Checked ) continue;
				folder = pp.Text;
				break;
			}
			foreach( ListViewItem pp in listView3.Items ) {
				if( !pp.Checked ) continue;
				folder = pp.Text;
				break;
			}
			var outputPath = $@"{m_currentTitle.fullPath}\{folder}";
			if( outputPath.isExistsDirectory() ) {
				int count = 1;
				while( true ) {
					var newPath = $"{outputPath}{count}";
					if( !newPath.isExistsDirectory() ) {
						outputPath = newPath;
						break;
					}
					count++;
				}
			}
			extract( listView2, outputPath );
			extract( listView3, outputPath );

			initTreeView();

			foreach( var p in m_titleTree ) {
				if( p.name == m_config.lastSelectTitle ) {
					var find = p.presets.Find( x => x.fullPath == outputPath );
					if( find != null ) {
						treeView1.SelectedNode = find.node;
						treeView1.Focus();
					}
					break;
				}
			}
		}
	}
}
