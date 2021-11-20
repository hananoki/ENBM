using HananokiLib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ENBM {
	public partial class Settings : Form {

		public Settings() {
			InitializeComponent();
		}


		void SettingsForm_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;


			textBox1.init( S.MSG_TXTBOX, ( s ) => {
				MainForm.config.sevenZipPath = s;
				return s;
			} );
			textBox1.setText( MainForm.config.sevenZipPath );

			checkBox1.Tag = D.ENABLE_PRESET_UPDATE;
			WindowsFormExtended.DoSomethingWithoutEvents(
					checkBox1,
					() => checkBox1.Checked = MainForm.config.flag.Has( D.ENABLE_PRESET_UPDATE )
					);

			
		}

		
		void Settings_Shown( object sender, EventArgs e ) {
			button1.Focus();
		}


		void button1_Click( object sender, EventArgs e ) {
			Close();
		}



		void checkBox1_CheckedChanged( object sender, EventArgs e ) {
			var chkbox = (CheckBox) sender;
			var flag = (int) chkbox.Tag;
			MainForm.config.flag.Toggle( flag, chkbox.Checked );
			MainForm.config.save();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="toolInfo"></param>
		bool ShowToolDialog( ref string filepath ) {
			var ofd = new OpenFileDialog();
			ofd.InitialDirectory = filepath.getDirectoryName();
			ofd.FilterIndex = 1;
			ofd.Title = "開くファイルを選択してください";
			ofd.RestoreDirectory = false;
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			if( ofd.ShowDialog() == DialogResult.OK ) {
				filepath = ofd.FileName;
				return true;
			}
			return false;
		}


		void button2_Click( object sender, EventArgs e ) {
			try {
				var btn = sender as Button;
				var filepath = MainForm.config.sevenZipPath;
				if( ShowToolDialog( ref filepath ) ) {
					MainForm.config.sevenZipPath = filepath;
					MainForm.config.save();
					textBox1.setText( MainForm.config.sevenZipPath );
				}
			}
			catch( Exception ee ) {
				Log.Exception( ee );
			}
		}

		
	}
}
