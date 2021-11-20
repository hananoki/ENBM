using HananokiLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ENBM {
	public partial class IniEditorForm : Form {

		string m_fullpath;
		IniEnbSeries m_iniEnbSeries;


		/////////////////////////////////////////
		public IniEditorForm( string iniFullPath, string csvFullPath ) {
			InitializeComponent();

			m_fullpath = iniFullPath;
			m_iniEnbSeries = IniFile.load<IniEnbSeries>( iniFullPath );

			var lines = csvFullPath.isExistsFile() ? File.ReadAllLines( csvFullPath ) : new string[0];
			List<IniEnbSeriesTypeConverter.RegisterType> lst = new List<IniEnbSeriesTypeConverter.RegisterType>( lines.Length );
			foreach( var s in lines ) {
				if( s.isEmpty() ) continue;
				if( s[ 0 ] == '#' ) continue;

				var ss = s.Split( '\t' );
				var rt = new IniEnbSeriesTypeConverter.RegisterType();
				rt.name = ss[ 0 ];
				switch( ss[ 2 ] ) {
				case "VK":
					rt.type = typeof( Win32.VK );
					break;
				case "bool":
					rt.type = typeof( bool );
					break;
				case "int":
					rt.type = typeof( int );
					break;
				case "uint":
					rt.type = typeof( uint );
					break;
				case "double":
					rt.type = typeof( double );
					break;
				case "Quality3":
					rt.type = typeof( IniEnbSeriesTypeConverter.Quality3 );
					break;
				case "Quality4":
					rt.type = typeof( IniEnbSeriesTypeConverter.Quality4 );
					break;
				case "AnisotropySize":
					rt.type = typeof( IniEnbSeriesTypeConverter.AnisotropySize );
					break;
				case "ReservedMemorySizeMb":
					rt.type = typeof( IniEnbSeriesTypeConverter.ReservedMemorySizeMb );
					break;
				}
				
				rt.desc = ss[ 1 ] == "unknown" ? "" : $@"{ss[ 1 ].Replace(@"\n",@"
")}";
				lst.Add( rt );
			}
			IniEnbSeriesTypeConverter.registerParameter( lst.ToArray() );
		}


		/////////////////////////////////////////
		void IniEditorForm_Load( object sender, EventArgs e ) {
			Text = $"{m_fullpath.getFileName()} - {m_fullpath.getDirectoryName().getBaseName()}";
			Font = SystemFonts.IconTitleFont;

			tsl_msg.Text = $"パラメータ数: {m_iniEnbSeries.m_parameterCount}";

			propertyGrid1.SelectedObject = m_iniEnbSeries;

			if( MainForm.config.flag.Has( D.ENABLE_SAVE_AND_INSTALL ) ) {
				toolStripButton2.Image = MainForm.instance.imglst_Tree.Images[ 2 ];
			}
			else {
				toolStripButton2.Image = MainForm.instance.imglst_Tree.Images[ 1 ];
			}

			toolStripButton2.Visible = MainForm.instance.hasInstalled();
			toolStripSeparator1.Visible = MainForm.instance.hasInstalled();
			rollbackWindow();
		}


		/////////////////////////////////////////
		void IniEditorForm_FormClosing( object sender, FormClosingEventArgs e ) {
			//save();
			backupWindow();
			MainForm.config.save();
			MainForm.instance.m_editorForm = null;
		}


		/////////////////////////////////////////
		void rollbackWindow() {
			Location = new Point( MainForm.config.editorX, MainForm.config.editorY );
			Width = MainForm.config.editorWidth;
			Height = MainForm.config.editorHeight;
		}


		/////////////////////////////////////////
		void backupWindow() {
			MainForm.config.editorX = Location.X;
			MainForm.config.editorY = Location.Y;
			MainForm.config.editorWidth = Width;
			MainForm.config.editorHeight = Height;
		}


		/////////////////////////////////////////
		void toolStripButton1_Click( object sender, EventArgs e ) => save();


		/////////////////////////////////////////
		void save() {
			m_iniEnbSeries.save( m_fullpath );
			if( MainForm.instance.hasInstalled() && MainForm.config.flag.Has( D.ENABLE_SAVE_AND_INSTALL ) ) {
				MainForm.instance.copyFiles();
			}
			Debug.Log( MainForm.instance.hasInstalled() );
		}


		/////////////////////////////////////////
		void toolStripButton2_Click( object sender, EventArgs e ) {
			if( MainForm.config.flag.Has( D.ENABLE_SAVE_AND_INSTALL ) ) {
				toolStripButton2.Image = MainForm.instance.imglst_Tree.Images[ 1 ];
				MainForm.config.flag.Disable( D.ENABLE_SAVE_AND_INSTALL );
			}
			else {
				toolStripButton2.Image = MainForm.instance.imglst_Tree.Images[ 2 ];
				MainForm.config.flag.Enable( D.ENABLE_SAVE_AND_INSTALL );
			}
		}
	}
}
