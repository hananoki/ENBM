using HananokiLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace ENBM {

	public enum NotifyType {
		None,
		Info,
		Warning,
		Error,
	}


	public partial class MainForm : Form {

		public static MainForm instance;

		NodePreset m_selectNodePreset;

		public Timer timer;

		public Config m_config = new Config();
		public Language m_language;
		public List<NodeTitle> m_titleTree;

		public Dictionary<string, int> m_iconIndexs;

		public static Dictionary<TreeNode, NodeInfo> m_nodeInfos;


		public static Config config => instance.m_config;
		public static Language language => instance.m_language;
		public static Dictionary<string, int> iconIndexs => instance.m_iconIndexs;

		public static Dictionary<TreeNode, NodeInfo> nodeInfos => m_nodeInfos;

		bool exceptionError;

		public MainForm() {
			instance = this;
			InitializeComponent();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Form1_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;
			Text = $"{Text} {Helper.version}";

			m_config = new Config();
			Helper.ReadJson( ref m_config, Helper.configPath );
			rollbackWindow();

			try {
				m_language = new Language();
			}
			catch( Exception except ) {
				MessageBox.Show( except.Message, "Error" );
				exceptionError = true;
				Close();
				return;
			}
			if( !$@"{Helper.s_appPath}\.icons".isExistsFile() ) {
				MessageBox.Show( "\".icons\" is Not Found.", "Error" );
				exceptionError = true;
				Close();
				return;
			}

			toolStripComboBox1.Items.Clear();
			var lst = m_language.languageNames;
			foreach( var s in lst ) {
				toolStripComboBox1.Items.Add( s );
			}
			WindowsFormExtended.DoSomethingWithoutEvents(
					toolStrip1,
					() => toolStripComboBox1.SelectedIndex = lst.IndexOf( m_config.langName )
					);
			toolStripProgressBar1.Visible = false;


			m_iconIndexs = new Dictionary<string, int>();
			var steamPath = getSteamFolder();
			foreach( var t in File.ReadAllLines( $@"{Helper.s_appPath}\.icons" ) ) {
				var tt = t.Split( '\t' );
				var exepath = $@"{steamPath}\steamapps\common\{tt[ 0 ]}\{tt[ 1 ]}".separatorToOS();
				if( !exepath.isExistsFile() ) continue;

				var shinfo = new Win32.SHFILEINFO();
				IntPtr hSuccess = Win32.SHGetFileInfo( exepath, 0, ref shinfo, (uint) Marshal.SizeOf( shinfo ), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON );
				if( hSuccess != IntPtr.Zero ) {
					imageList1.Images.Add( Icon.FromHandle( shinfo.hIcon ).ToBitmap() );
					m_iconIndexs.Add( tt[ 0 ], imageList1.Images.Count - 1 );
				}
			}


			timer = new Timer();
			timer.Tick += new EventHandler( ( s, ee ) => {
				toolStripStatusLabel1.Text = "";
				toolStripStatusLabel1.Image = null;
				timer.Stop();
			} );

			var pt = splitContainer1.Location;
			pt.Y = 28;
			splitContainer1.Location = pt;

			toolStripStatusLabel1.Text = "";

			initTreeView();

			updateLanguage();

			sound.addData( "start", Helper.s_appPath + "\\startup.wav" );
			sound.play( "start" );
		}



		private void MainForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( exceptionError ) return;

			var foldList = new List<string>();
			foreach( var p in m_titleTree ) {
				if( p.node.IsExpanded ) {
					foldList.Add( p.name );
				}
			}
			m_config.foldTitle = foldList;
			backupWindow();
			Helper.WriteJson( m_config );
		}


		void Form1_KeyDown( object sender, KeyEventArgs e ) {
			if( e.KeyCode == Keys.F11 ) {
				LogWindow.Visible = !LogWindow.Visible;
			}
		}


		void checkBox1_CheckStateChanged( object sender, EventArgs e ) {
			var chk = (CheckBox) sender;
			var node = (NodeTitle) chk.Tag;

			m_config.setEnableEnbLocal( node.name, chk.Checked );

			if( !chk.Checked ) return;

			var path = $@"{node.fullPath}\.override\enblocal.ini";

			if( path.isExistsFile() ) return;

			fs.mkDir( path.getDirectoryName() );
			File.WriteAllText( path, "" );
		}
	}
}
