using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {

		void treeView1_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e ) {
			treeView1.SelectedNode = e.Node;
		}


		void treeView1_AfterSelect( object sender, TreeViewEventArgs e ) {

			var nodeInfo = m_nodeInfos[ e.Node ];
			if( nodeInfo.GetType() == typeof( NodeTitle ) ) {
				m_config.lastSelectTitle = nodeInfo.name;
				m_config.lastSelectGUID = "";
				toolStripButton1.Visible = false;
				toolStripButton2.Visible = false;
				return;
			}

			m_selectNodePreset = (NodePreset) nodeInfo;

			var path = nodeInfo.fullPath;
			var files = Directory.GetFiles( path, "*", SearchOption.AllDirectories );
			m_selectNodePreset.m_targetFileName = new List<string>( files.Length );

			listView1.Items.Clear();

			foreach( var p in files ) {

				var pname = p.Remove( 0, path.Length + 1 );
				var newItem = new ListViewItem( new string[] { pname } );
				listView1.Items.Add( newItem );

				m_selectNodePreset.m_targetFileName.Add( pname );
			}

			m_config.lastSelectTitle = "";
			m_config.lastSelectGUID = m_selectNodePreset.GUID;

			toolStripButton1.Enabled = true;
			if( m_selectNodePreset.node.ImageIndex == 1 ) {
				toolStripButton2.Visible = false;
				if( m_selectNodePreset.title.installed != null ) {
					toolStripButton1.Visible = false;
				}
				else {
					toolStripButton1.Visible = true;
				}
			}
			else {
				toolStripButton1.Visible = false;
				toolStripButton2.Visible = true;
			}
		}

	} // class
}
