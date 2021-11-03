using HananokiLib;
using System;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {

		void treeView1_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e ) {
			treeView1.SelectedNode = e.Node;
			if( e.Button == MouseButtons.Right ) {
				if( m_nodeInfos[ e.Node ].GetType() == typeof( NodeTitle ) ) {
					contextMenuStrip1.Show( Cursor.Position );
				}
				else {
					contextMenuStrip2.Tag = m_nodeInfos[ e.Node ];
					contextMenuStrip2.Items[ 3 ].Enabled = m_enbLocal != null ? true : false;
					contextMenuStrip2.Show( Cursor.Position );
				}
			}
		}



		void treeView1_AfterSelect( object sender, TreeViewEventArgs e ) {

			var nodeInfo = m_nodeInfos[ e.Node ];
			if( nodeInfo.GetType() == typeof( NodeTitle ) ) {
				m_config.lastSelectTitle = nodeInfo.name;
				m_config.lastSelectGUID = "";
				toolStripButton_Install.Visible = false;
				toolStripButton_Uninstall.Visible = false;
				initPanel( (NodeTitle) nodeInfo );
				return;
			}

			listView1.Visible = true;
			panel1.Visible = false;
			m_selectNodePreset = (NodePreset) nodeInfo;

			initListView( m_selectNodePreset, nodeInfo.fullPath );

			m_config.lastSelectTitle = "";
			m_config.lastSelectGUID = m_selectNodePreset.GUID;

			toolStripButton_Install.Enabled = true;
			if( m_selectNodePreset.node.ImageIndex == 1 ) {
				toolStripButton_Uninstall.Visible = false;
				if( m_selectNodePreset.title.installed != null ) {
					toolStripButton_Install.Visible = false;
				}
				else {
					toolStripButton_Install.Visible = true;
				}
			}
			else {
				toolStripButton_Install.Visible = false;
				toolStripButton_Uninstall.Visible = true;
			}
		}


		void ゲームフォルダを開くToolStripMenuItem_Click( object sender, EventArgs e ) {
			var info = m_nodeInfos[ treeView1.SelectedNode ];
			var path = info.getGameFolderPath();
			shell.startProcess( "explorer", info.getGameFolderPath() );
			setNotifyText( $"Open: {path}" );
		}


		void プリセットフォルダを開くToolStripMenuItem_Click( object sender, EventArgs e ) {
			var info = m_nodeInfos[ treeView1.SelectedNode ];
			shell.startProcess( "explorer", info.fullPath );
			setNotifyText( $"Open: {info.fullPath}" );
		}


		void プリセットを削除ToolStripMenuItem_Click( object sender, EventArgs e ) {
			var info = m_nodeInfos[ treeView1.SelectedNode ];
			//fs.rm( info.fullPath, true );

			var sf = new Win32.SHFILEOPSTRUCT();

			sf.wFunc = Win32.FileFuncFlags.FO_DELETE; // 削除を指示します。
			sf.fFlags = Win32.FILEOP_FLAGS.FOF_ALLOWUNDO; //「元に戻す」を有効にします。
																										//sf.fFlags = sf.fFlags | FILEOP_FLAGS.FOF_NOERRORUI; //エラー画面を表示しません。
																										//sf.fFlags = sf.fFlags | FILEOP_FLAGS.FOF_SILENT; //進捗ダイアログを表示しません。
																										//sf.fFlags = sf.fFlags | FILEOP_FLAGS.FOF_NOCONFIRMATION; //削除確認ダイアログを表示しません。
			sf.pFrom = info.fullPath + "\0";

			int result;
			result = Win32.SHFileOperation( ref sf );

			if( result == 0 ) {
				System.Diagnostics.Debug.WriteLine( "成功" );
			}
			else {
				System.Diagnostics.Debug.WriteLine( "失敗。" + result );
			}

			initTreeView();
		}


	} // class
}
