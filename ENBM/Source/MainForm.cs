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

		Dictionary<string, int> m_imageIndexMap = new Dictionary<string, int>();

		bool exceptionError;


		FileENBLocal m_enbLocal;

		NodeTitle m_currentTitle;

		GameTitleList m_gameTitleList;


		List<ListViewItem> m_fileItems;

		


		/////////////////////////////////////////
		public MainForm() {
			instance = this;
			InitializeComponent();
		}



		/////////////////////////////////////////
		void Form1_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;
			Text = $"{Text} {Helper.version}";

			m_config = new Config();
			Helper.ReadJson( ref m_config, Helper.configPath );
			rollbackWindow();

			// レイアウトの微調整
			var pt = splitContainer1.Location;
			pt.Y = 28;
			splitContainer1.Location = pt;


			// 必須読み込み処理、失敗したら終了
			try {
				m_language = new Language();
			}
			catch( Exception except ) {
				MessageBox.Show( except.Message, "Error" );
				exceptionError = true;
				Close();
				return;
			}
			if( !$@"{Helper.s_appPath}\.gametitle".isExistsFile() ) {
				MessageBox.Show( "\".gametitle\" is Not Found.", "Error" );
				exceptionError = true;
				Close();
				return;
			}


			// 各種UIのアイテム処理

			m_fileItems = new List<ListViewItem>();
			listView1.SetDoubleBuffered( true );
			//treeView1.SetDoubleBuffered( true );


			toolStripStatusLabel1.Text = "";
			label2.Text = "";

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


			m_gameTitleList = new GameTitleList();
			m_gameTitleList.load( $@"{Helper.s_appPath}\.gametitle" );

			m_iconIndexs = new Dictionary<string, int>();
			foreach( var p in m_gameTitleList.m_data ) {
				if( p.icon == null ) continue;
				imglst_Tree.Images.Add( p.icon );
				m_iconIndexs.Add( p.folderName, imglst_Tree.Images.Count - 1 );
			}


			timer = new Timer();
			timer.Tick += new EventHandler( ( s, ee ) => {
				toolStripStatusLabel1.Text = "";
				toolStripStatusLabel1.Image = null;
				timer.Stop();
			} );


			initTreeView();

			makeAddGameTitleDropDownMenu();

			//sound.addData( "start", Helper.s_appPath + "\\startup.wav" );
			//sound.play( "start" );

			var enblocalPath = $@"{Helper.s_appPath}\.enbseries\enblocal.ini";
			m_enbLocal = FileENBLocal.load( enblocalPath );

			var pw=listView3.Size.Width / 2;
			var w =label4.Size.Width/2;
			label4.Location = new Point(pw-w, 50);
			linkLabel_ENB.Tag = "http://enbdev.com/news.html";

			updateLanguage();

			if(m_config.shortCutFilePath.isEmpty()) {
				toolStripButton1.Visible = false;
			}
		}



		/////////////////////////////////////////
		void MainForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( exceptionError ) return;

			var foldList = new List<string>();
			foreach( var p in m_titleTree ) {
				if( p.node.IsExpanded ) {
					foldList.Add( p.name );
				}
			}
			m_config.foldTitle = foldList;
			backupWindow();

			m_config.save();
		}



		/////////////////////////////////////////
		void Form1_KeyDown( object sender, KeyEventArgs e ) {
			if( e.KeyCode == Keys.F11 ) {
				LogWindow.Visible = !LogWindow.Visible;
			}
		}



		//void checkBox1_CheckStateChanged( object sender, EventArgs e ) {
		//	var chk = (CheckBox) sender;
		//	var node = (NodeTitle) chk.Tag;

		//	m_config.setEnableEnbLocal( node.name, chk.Checked );

		//	if( !chk.Checked ) return;

		//	var path = $@"{node.fullPath}\.override\enblocal.ini";

		//	if( path.isExistsFile() ) return;

		//	fs.mkDir( path.getDirectoryName() );
		//	File.WriteAllText( path, "" );
		//}


		/////////////////////////////////////////
		private void wINDOWToolStripMenuItem_Click( object sender, EventArgs e ) {
			var preset = cms_Preset.Tag as NodePreset;
			if( preset == null ) return;
			m_enbLocal?.replace( $@"{preset.fullPath}\enblocal.ini", typeof( FileENBLocal.WINDOW ) );
		}


		/////////////////////////////////////////
		private void iNPUTToolStripMenuItem_Click( object sender, EventArgs e ) {
			var preset = cms_Preset.Tag as NodePreset;
			if( preset == null ) return;
			m_enbLocal?.replace( $@"{preset.fullPath}\enblocal.ini", typeof( FileENBLocal.INPUT ) );
		}


		void toolStripButton1_Click( object sender, EventArgs e ) {
			System.Diagnostics.Process.Start( m_config.shortCutFilePath, m_config.shortCutFileArg );
		}


	}
}
