using HananokiLib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ENBM {
	public partial class Settings : Form {

		//TextBoxPath m_textBoxPath;

		public Settings() {
			InitializeComponent();
		}


		void SettingsForm_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;

			TextBoxHelper.def = S.MSG_TXTBOX;
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

		void textBox1_Leave( object sender, EventArgs e ) {
			if( textBox1.Text.Length <= 0 || textBox1.Text == S.MSG_TXTBOX ) {
				textBox1.Text = S.MSG_TXTBOX;
				textBox1.ForeColor = Color.Silver;
			}
			else {
				textBox1.ForeColor = SystemColors.WindowText;
			}
		}

		void textBox1_Enter( object sender, EventArgs e ) {
			if( textBox1.Text == S.MSG_TXTBOX ) {
				textBox1.Text = string.Empty;
				textBox1.ForeColor = SystemColors.WindowText;
			}
		}


		void textBox1_DragEnter( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {

				// ドラッグ中のファイルやディレクトリの取得
				var drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				foreach( var d in drags ) {
					if( !File.Exists( d ) ) {
						// ファイル以外であればイベント・ハンドラを抜ける
						return;
					}
				}

				e.Effect = DragDropEffects.Link;
			}
		}


		void textBox1_DragDrop( object sender, DragEventArgs e ) {
			// ドラッグ＆ドロップされたファイル
			string[] files = (string[]) e.Data.GetData( DataFormats.FileDrop );

			//listBox1.Items.AddRange( files ); // リストボックスに表示

			( (TextBox) sender ).Text = files[ 0 ];
			if( sender == textBox1 ) {
				MainForm.config.sevenZipPath = textBox1.Text;
			}
			//if( sender == textBox_ReplaceModList ) {
			//	MainForm.config.replaceModListFilePath = textBox_ReplaceModList.Text;
			//}
		}



		void button1_Click( object sender, EventArgs e ) {
			Close();
		}


		void textBox1_TextChanged( object sender, EventArgs e ) {
			var txtbox = (TextBox) sender;
			if( txtbox.Text != TextBoxHelper.def ) {
				MainForm.config.sevenZipPath = txtbox.Text;
			}
			textBox1.updateTextStatus();
			//MainForm.config.save();
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

		private void button2_Click( object sender, EventArgs e ) {
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
