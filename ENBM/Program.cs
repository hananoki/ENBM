using HananokiLib;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


namespace ENBM {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main( string[] args ) {
			using( var mutex = new Mutex( false, typeof( MainForm ).ToString() ) ) {
				if( mutex.WaitOne( 0, false ) == false ) {
					//すでに起動していると判断して終了
					MessageBox.Show( "[ENBM] instance is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				Helper._init();
				if( 0 < args.Length ) {
					Debug.Log( args[ 0 ] );
					Helper.s_appPath = args[ 0 ];
				}
				Application.Run( new MainForm() );
			}
		}
	}
}
