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

			textBox1.Text = MainForm.config.sevenZipPath;
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
			MainForm.config.sevenZipPath = txtbox.Text;
		}
	}
}
