using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ENBM {

	public partial class MainForm : Form {

		void listView1_DoubleClick( object sender, EventArgs e ) {
			Point formClientCurPos = listView1.PointToClient( Cursor.Position );
			var item = listView1.GetItemAt( formClientCurPos.X, formClientCurPos.Y );
			if( item != null ) {
				startFilePath( item.getFullPath() );
			}
		}


		void initListView( NodePreset presetNode, string fullpath ) {

			var files = Directory.GetFiles( fullpath, "*", SearchOption.AllDirectories );
			presetNode.m_targetFileName = new List<string>( files.Length );

			listView1.Items.Clear();

			foreach( var p in files ) {
				var pname = p.Remove( 0, fullpath.Length + 1 );
				var newItem = new ListViewItem( new string[] { pname } );
				newItem.Tag = new ListViewItemTag { fullpath = p };

				listView1.Items.Add( newItem );

				presetNode.m_targetFileName.Add( pname );
			}


		}
	}
}
