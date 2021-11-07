﻿using HananokiLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace ENBM {

	public partial class MainForm : Form {

		/////////////////////////////////////////
		void listView1_DoubleClick( object sender, EventArgs e ) {
			Point formClientCurPos = listView1.PointToClient( Cursor.Position );
			var item = listView1.GetItemAt( formClientCurPos.X, formClientCurPos.Y );
			if( item != null ) {
				Utils.startFilePath( item.getFullPath() );
			}
		}


		/////////////////////////////////////////
		void initListView( NodePreset presetNode, string fullpath ) {

			var files = Directory.GetFiles( fullpath, "*", SearchOption.AllDirectories );
			presetNode.m_targetFileName = new List<string>( files.Length );

			listView1.Items.Clear();
			listView1.Columns[ 0 ].Text = S.UI_FILEPATH;

			foreach( var p in files ) {
				var pname = p.Remove( 0, fullpath.Length + 1 );
				var newItem = new ListViewItem( new string[] { pname } );
				newItem.Tag = new ListViewItemTag { fullpath = p };
				if( pname == "enblocal.ini" ) {
					newItem.BackColor = Color.PaleTurquoise;
				}
				if( pname == "enbseries.ini" ) {
					newItem.BackColor = Color.LightSkyBlue;
				}
				listView1.Items.Add( newItem );

				presetNode.m_targetFileName.Add( pname );
			}
		}



		/////////////////////////////////////////
		void listView_DragEnter( object sender, DragEventArgs e ) {
			var lstView = (ListView) sender;

			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {

				// ドラッグ中のファイルやディレクトリの取得
				var drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				e.Effect = DragDropEffects.None;

				if( lstView == listView2 ) {
					foreach( var d in drags ) {
						if( !File.Exists( d ) ) return;
						if( !d.getFileName().Contains( "enbseries" ) ) return;
					}
				}
				else {
					foreach( var d in drags ) {
						if( !File.Exists( d ) ) return;
						var ext = d.getExt();
						if( ext != ".zip" && ext != ".rar" && ext != ".7z" ) return;
					}
				}
				if( e.KeyState.Has( 0x4 ) ) {
					e.Effect = DragDropEffects.Move;
				}
				else {
					e.Effect = DragDropEffects.Copy;
				}
			}
		}



		/////////////////////////////////////////
		void listView_DragDrop( object sender, DragEventArgs e ) {
			var lstView = (ListView) sender;

			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				string[] files = (string[]) e.Data.GetData( DataFormats.FileDrop );

				var copyPath = "";// $@"{Helper.s_appPath}\.enbseries";
				if( lstView == listView2 ) {
					copyPath = $@"{Helper.s_appPath}\.enbseries";
				}
				else {
					copyPath = $@"{Helper.s_appPath}\{m_currentTitle.name}\.presets";
				}
				fs.mkDir( copyPath );

				var mv = e.KeyState.Has( 0x4 );
				foreach( var p in files ) {
					var dst = $@"{copyPath}\{p.getFileName()}";
					if( mv ) {
						fs.mv( p, dst );
					}
					else {
						fs.cp( p, dst, true );
					}
				}
				initPanel( m_currentTitle );
			}
		}



		/////////////////////////////////////////
		// チェックボックスがクリックされたらその部分を再描画
		void listViewR_MouseClick( object sender, MouseEventArgs e ) {
			var listview = (ListView) sender;
			var item = listview.GetItemAt( e.X, e.Y );

			if( item != null ) {
				if( e.X < ( item.Bounds.Left + 16 ) ) {
					var chk = item.Checked;
					WindowsFormExtended.DoSomethingWithoutEvents(
					listview,
					() => {
						foreach( ListViewItem p in listview.Items ) p.Checked = false;
						item.Checked = chk;
					}
					);
					//item.invertChecked();
					//se_checked();
				}
			}
		}
	}
}
