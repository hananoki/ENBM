using HananokiLib;
using Microsoft.Win32;
using System;



namespace ENBM {
	public static class Utils {
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



		public static void startFilePath( string filepath ) {
			if( string.IsNullOrEmpty( filepath ) ) return;

			System.Diagnostics.Process.Start( $"{filepath.quote()}" );
		}



		public static void setNotifyText( string text = "", NotifyType type = NotifyType.Info, int interval = 10000 ) {
			MainForm.instance.Invoke( new Action( () => {
				MainForm.instance.toolStripStatusLabel1.Text = text;
				switch( type ) {
				case NotifyType.None:
					MainForm.instance.toolStripStatusLabel1.Image = null;
					break;
				case NotifyType.Info:
					MainForm.instance.toolStripStatusLabel1.Image = icon.info;
					break;
				case NotifyType.Warning:
					MainForm.instance.toolStripStatusLabel1.Image = icon.warning;
					break;
				case NotifyType.Error:
					MainForm.instance.toolStripStatusLabel1.Image = icon.error;
					break;
				}
				MainForm.instance.timer.Stop();
				if( 1 <= interval ) {
					MainForm.instance.timer.Interval = interval;
					MainForm.instance.timer.Start(); // timer.Start()と同じ
				}
			} ) );
		}



		public static void clearNotifyText() {
			MainForm.instance.toolStripStatusLabel1.Text = "";
			MainForm.instance.toolStripStatusLabel1.Image = null;
		}
	}
}
