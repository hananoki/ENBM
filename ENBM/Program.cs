using HananokiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENBM {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main( string[] args ) {
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
