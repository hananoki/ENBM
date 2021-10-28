using HananokiLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ENBM {

	public class Language {

		Dictionary<string, string> m_languageFileMap;
		Dictionary<string, string> m_dic;

		public List<string> languageNames => m_languageFileMap.Keys.Select( x => x ).ToList();


		public Language() {

			var lang = Directory.GetFiles( $"{Helper.s_appPath}\\.translations", "*.txt" );
			m_languageFileMap = new Dictionary<string, string>( lang.Length );
			foreach( var s in lang ) {
				m_languageFileMap.Add( s.getBaseName(), s );
			}

			init();
		}


		public void init() {
			var langFilePath = "";
			m_dic = new Dictionary<string, string>();

			var langName = MainForm.config.langName;
			if( langName.isEmpty() ) {
				langName = "english";
				MainForm.config.langName = "english";
			}

			m_languageFileMap.TryGetValue( langName, out langFilePath );
			if( langFilePath.isEmpty() ) {
				return;
			}

			foreach( var loc in File.ReadLines( langFilePath ) ) {
				if( string.IsNullOrEmpty( loc ) ) continue;
				var locText = loc.Split( '\t' );
				m_dic.Add( locText[ 0 ], locText[ 1 ] );
			}
		}


		public string this[ string s ] {
			get {
				string result = "";
				m_dic.TryGetValue( s, out result );
				return result.isEmpty() ? string.Empty : result;
			}
		}

	} // class
}
