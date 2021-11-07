using HananokiLib;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {

		void updateLanguage() {
			toolStripLabel_Language.Text = S.UI_LANG;
			toolStripButton_Install.Text = S.UI_INSTALL;
			toolStripButton_Uninstall.Text = S.UI_UNINSTALL;
			toolStripButton_Reload.Text = S.UI_REFRESH;
			contextMenuStrip1.Items[ 0 ].Text = S.CONTEXT_OPEN_GAME_FOLDER;
			contextMenuStrip2.Items[ 0 ].Text = S.CONTEXT_OPEN_PRESET_FOLDER;
			contextMenuStrip2.Items[ 1 ].Text = S.CONTEXT_REMOVE_PRESET_FOLDER;
			contextMenuStrip2.Items[ 3 ].Text = S.CONTEXT_COM_EMBLOC_RESET;
			button_ExtractArcive.Text = S.UI_EXTRACT_CHECKED_FILES;
			uiAddGameTitle.Text = S.UI_ADD_GAME;
		}



		void makeAddGameTitleDropDownMenu() {
			var items = uiAddGameTitle.DropDownItems;
			items.Clear();
			foreach( var p in m_gameTitleList.m_data ) {
				if( $"{Helper.s_appPath}\\{p.folderName}".isExistsDirectory() ) continue;
				var it = items.Add( p.gameName, p.icon );
				it.Click += onClick_AddGameTitle;
				it.Tag = p;
			}
			uiAddGameTitle.Enabled = items.Count == 0 ? false : true;
		}



		void initTreeView() {
			treeView1.Nodes.Clear();
			m_nodeInfos = new Dictionary<TreeNode, NodeInfo>();

			var dirs = Directory.GetDirectories( Helper.s_appPath ).Where( x => !x.getFileName().StartsWith( "." ) );

			m_titleTree = dirs.Select( x => new NodeTitle { name = x.getBaseName(), fullPath = x } ).ToList();

			foreach( var d in m_titleTree ) {
				var treeNode = d.makeNode();
				treeView1.Nodes.Add( treeNode );
				m_nodeInfos.Add( treeNode, d );
			}

			if( !m_config.lastSelectGUID.isEmpty() ) {
				var lst = m_nodeInfos.Values.Where( x => x.GetType() == typeof( NodePreset ) ).Cast<NodePreset>().ToList();
				var find = lst.Find( x => x.GUID == m_config.lastSelectGUID );
				if( find != null ) {
					find.node.Parent.Expand();
					treeView1.SelectedNode = find.node;
				}
			}
			else if( !m_config.lastSelectTitle.isEmpty() ) {
				var find = m_titleTree.Find( x => x.name == m_config.lastSelectTitle );
				if( find != null ) {
					treeView1.SelectedNode = find.node;
				}
			}

			foreach( var p in m_config.foldTitle ) {
				var find = m_titleTree.Find( x => x.name == p );
				if( find != null ) {
					find.node.ExpandAll();
				}
			}
		}



		void updatePanel() {
			button_ExtractArcive.Enabled = m_config.sevenZipPath.isExistsFile() ? true : false;
		}


		/////////////////////////////////////////
		void initPanel( NodeTitle node ) {
			listView1.Visible = false;
			panel1.Visible = true;
			m_currentTitle = node;

			linkLabel_Nexus.Tag = m_gameTitleList.get( m_currentTitle.name ).url;

			//checkBox1.Tag = node;
			//checkBox1.Checked = m_config.hasEnableEnbLocal( node.name );

			label2.Text = m_config.lastSelectTitle;

			var gg = m_gameTitleList.get( node.name );
			var filter = gg.enbFilter.isEmpty() ? "" : gg.enbFilter;
			bool filterCheck = !filter.isEmpty();

			listView2.Items.Clear();
			var dirpath = $@"{Helper.s_appPath }\.enbseries";
			if( dirpath.isExistsDirectory() ) {
				int i = 0;
				foreach( var p in Directory.GetFiles( dirpath, "*.zip" ) ) {
					if( filterCheck ) {
						if( !p.getFileName().Contains( filter ) ) continue;
					}

					var item = new ListViewItem( p.getBaseName() );
					item.Tag = new FilePathTag {
						fullpath = p,
						nodeTitle = node,
					};
					int imageInex;
					if( m_imageIndexMap.TryGetValue( p.getExt(), out imageInex ) ) {
						item.ImageIndex = imageInex;
					}
					else {
						var bmp = icon.file( p );
						imageList2.Images.Add( bmp );
						m_imageIndexMap.Add( p.getExt(), imageList2.Images.Count - 1 );
						item.ImageIndex = imageList2.Images.Count - 1;
					}

					if( i.Has( 0x01 ) ) {
						item.BackColor = Helper.LVBKColor;
					}
					else {
						item.BackColor = SystemColors.Window;
					}

					listView2.Items.Add( item );
					i++;
				}
				listView2.Columns[ 0 ].Width = listView2.Width - 4;
			}


			listView3.Items.Clear();
			var dirpath2 = $@"{Helper.s_appPath }\{node.name}\.presets";
			if( dirpath2.isExistsDirectory() ) {
				int i = 0;
				foreach( var p in Directory.GetFiles( dirpath2 ) ) {
					var item = new ListViewItem( p.getBaseName() );
					item.Tag = new FilePathTag {
						fullpath = p,
						nodeTitle = node,
					};

					int imageInex;
					if( m_imageIndexMap.TryGetValue( p.getExt(), out imageInex ) ) {
						item.ImageIndex = imageInex;
					}
					else {
						var bmp = icon.file( p );
						imageList2.Images.Add( bmp );
						m_imageIndexMap.Add( p.getExt(), imageList2.Images.Count - 1 );
						item.ImageIndex = imageList2.Images.Count - 1;
					}
					if( i.Has( 0x01 ) ) {
						item.BackColor = Helper.LVBKColor;
					}
					else {
						item.BackColor = SystemColors.Window;
					}

					listView3.Items.Add( item );
					i++;
				}
				listView3.Columns[ 0 ].Width = listView3.Width - 4;
			}

			updatePanel();
		}



		void rollbackWindow() {
			//Location = new Point( m_config.x, m_config.y );
			Width = m_config.width;
			Height = m_config.height;
		}



		void backupWindow() {
			m_config.x = Location.X;
			m_config.y = Location.Y;
			m_config.width = Width;
			m_config.height = Height;
		}

	} // class
}
