using HananokiLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;



namespace ENBM {

	public class GameTitleList {

		public class Data {
			public string gameName;   // 表示向けの名前
			public string folderName; // インストールしたフォルダ名
			public string exeName;
			public string enbFilter;
			public string url;        // nexusのenbプリセット
			public Bitmap icon;
		}


		public List<Data> m_data;


		public void load( string filepath ) {
			var steamPath = Utils.getSteamFolder();

			var lines = File.ReadAllLines( filepath );

			m_data = new List<Data>( lines.Length );

			foreach( var t in lines ) {
				if( t.isEmpty() ) continue;

				var tt = t.Split( '\t' );
				var data = new Data { gameName = tt[ 0 ], folderName = tt[ 1 ], exeName = tt[ 2 ], enbFilter = tt[ 3 ], url = tt[ 4 ] };
				m_data.Add( data );
				var exepath = $@"{steamPath}\steamapps\common\{data.folderName}\{data.exeName}".separatorToOS();
				if( !exepath.isExistsFile() ) continue;

				var shinfo = new Win32.SHFILEINFO();
				IntPtr hSuccess = Win32.SHGetFileInfo( exepath, 0, ref shinfo, (uint) Marshal.SizeOf( shinfo ), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON );
				if( hSuccess != IntPtr.Zero ) {
					data.icon = Icon.FromHandle( shinfo.hIcon ).ToBitmap();
				}
			}
			m_data = m_data.OrderBy( x => x.gameName ).ToList();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="titleName">インストールフォルダの名前</param>
		/// <returns></returns>
		public Data get( string titleName ) {
			var find = m_data.Find( x => x.folderName == titleName );
			return find;
		}
	}
}
