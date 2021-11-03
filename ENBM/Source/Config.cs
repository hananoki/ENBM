using HananokiLib;
using System.Collections.Generic;


namespace ENBM {
	public class Config {
		public int width = 800;
		public int height = 600;
		public int x;
		public int y;

		public string langName;

		public string lastSelectTitle;
		public string lastSelectGUID;

		public string sevenZipPath;


		public List<string> foldTitle = new List<string>();

		public List<ConfigTitle> title = new List<ConfigTitle>();


		public bool hasEnableEnbLocal( string titleName ) {
			var find = title.Find( x => x.name == titleName );
			if( find == null ) return false;

			return find.flag.Has( D.ENABLE_ENBLOCAL );
		}
		public void setEnableEnbLocal( string titleName, bool flag ) {
			var find = title.Find( x => x.name == titleName );
			if( find == null ) {
				find = new ConfigTitle();
				find.name = titleName;
				title.Add( find );
			}

			find.flag.Toggle( D.ENABLE_ENBLOCAL, flag );
		}
	} // class


	public class ConfigTitle {
		public string name;
		public int flag;
	} // class

}
