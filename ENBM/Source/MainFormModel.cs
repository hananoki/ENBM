using HananokiLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ENBM {

	public partial class MainForm : Form {

		public void updateLanguage() {
			toolStripLabel1.Text = S.Lang;
			toolStripButton1.Text = S.Install;
			toolStripButton2.Text = S.Uninstall;
			//toolStripLabel_Profile.Text = m_language[ "$UI_PROFILE" ];
			//toolStripButton_Build.Text = m_language[ "$UI_BUILD" ];
			//toolStripButton_Clean.Text = m_language[ "$UI_CLEAN" ];
			//toolStripButton_Refresh.Text = m_language[ "$UI_REFRESH" ];
			//toolStripButton2.Text = m_language[ "$UI_COPY_GUID" ];
			//linkLabel1.Text = m_language[ "$UI_OUTPUT_FOLDER" ];
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
