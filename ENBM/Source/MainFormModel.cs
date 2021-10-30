using HananokiLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {

		void updateLanguage() {
			toolStripLabel_Language.Text = S.Lang;
			toolStripButton_Install.Text = S.Install;
			toolStripButton_Uninstall.Text = S.Uninstall;
			toolStripButton_Reload.Text = S.Refresh;
			contextMenuStrip1.Items[ 0 ].Text = S.Context_OpenGameFolder;
			contextMenuStrip2.Items[ 0 ].Text = S.Context_OpenPresetFolder;
			contextMenuStrip2.Items[ 1 ].Text = S.Context_RemovePresetFolder;
			checkBox1.Text = S.CheckBox_ENBLocal;
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



		void initPanel( NodeTitle node ) {
			listView1.Visible = false;
			panel1.Visible = true;

			
			checkBox1.Tag = node;
			checkBox1.Checked = m_config.hasEnableEnbLocal( node.name );
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


		void startFilePath( string filepath ) {
			if( string.IsNullOrEmpty( filepath ) ) return;

			System.Diagnostics.Process.Start( $"{filepath.quote()}" );
		}


		public static string getSteamFolder() {
			using( var regkey = Registry.CurrentUser.OpenSubKey( @"Software\Valve\Steam", false ) ) {
				//キーが存在しないときは null が返される
				if( regkey == null ) {
					Debug.Log( $@"Software\Valve\Steam None" );
					return "";
				}
				string stringValue = (string) regkey.GetValue( "SteamPath" );

				return stringValue;
			}
		}



		public void clearNotifyText() {
			toolStripStatusLabel1.Text = "";
			toolStripStatusLabel1.Image = null;
		}


		public void setNotifyText( string text = "", NotifyType type = NotifyType.Info, int interval = 10000 ) {
			Invoke( new Action( () => {
				toolStripStatusLabel1.Text = text;
				switch( type ) {
				case NotifyType.None:
					toolStripStatusLabel1.Image = null;
					break;
				case NotifyType.Info:
					toolStripStatusLabel1.Image = icon.info;
					break;
				case NotifyType.Warning:
					toolStripStatusLabel1.Image = icon.warning;
					break;
				case NotifyType.Error:
					toolStripStatusLabel1.Image = icon.error;
					break;
				}
				timer.Stop();
				if( 1 <= interval ) {
					timer.Interval = interval;
					timer.Start(); // timer.Start()と同じ
				}
			} ) );
			//Debug.Log( text );
		}
	} // class
}
