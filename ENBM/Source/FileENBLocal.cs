using HananokiLib;
using System;
using System.IO;
using System.Text;

namespace ENBM {
	public class FileENBLocal {
		public struct WINDOW {
			public bool ForceBorderless;
			public bool ForceBorderlessFullscreen;
			public string iniString() {
				string[] ss = {
					$"ForceBorderless={ForceBorderless.ToString().ToLower()}",
					$"ForceBorderlessFullscreen={ForceBorderlessFullscreen.ToString().ToLower()}",
					};
				return string.Join( "\n", ss );
			}
		}
		public struct INPUT {
			public int KeyCombination;
			public int KeyUseEffect;
			public int KeyFPSLimit;

			public int KeyShowFPS;
			public int KeyScreenshot;
			public int KeyEditor;
			public int KeyFreeVRAM;

			public string iniString() {
				string[] ss = {
					$"KeyCombination={KeyCombination}",
					$"KeyUseEffect={KeyUseEffect}",
					$"KeyFPSLimit={KeyFPSLimit}",

					$"KeyShowFPS={KeyShowFPS}",
					$"KeyScreenshot={KeyScreenshot}",
					$"KeyEditor={KeyEditor}",
					$"KeyFreeVRAM={KeyFreeVRAM}",
					};
				return string.Join( "\n", ss );
			}
		}

		public WINDOW window;
		public INPUT input;


		public void replace( string targetFullPath, Type t ) {
			if( targetFullPath.isEmpty() ) return;
			if( !targetFullPath.isExistsFile() ) return;

			var ss = File.ReadLines( targetFullPath );

			StringBuilder b = new StringBuilder();
			bool skip = false;

			foreach( var s in ss ) {
				var section = s.match2( @"\[(.*)\]", ( m ) => {
					return m[ 1 ].ToString();
				} );

				if( section != null ) {
					if( s.Contains( "WINDOW" ) && t == typeof( WINDOW ) ) {
						b.Append( s );
						b.Append( "\n" );
						b.Append( window.iniString() );
						b.Append( "\n" );
						skip = true;
					}
					else if( s.Contains( "INPUT" ) && t == typeof( INPUT ) ) {
						b.Append( s );
						b.Append( "\n" );
						b.Append( input.iniString() );
						b.Append( "\n" );

						skip = true;
					}
					else {
						skip = false;
					}
				}
				if( skip && !s.isEmpty() ) continue;

				b.Append( s );
				b.Append( "\n" );
			}
			File.WriteAllText( targetFullPath, b.ToString() );

		}


		public static FileENBLocal load( string fullpath ) {
			if( fullpath.isEmpty() ) return null;
			if( !fullpath.isExistsFile() ) return null;

			var self = new FileENBLocal();
			self.window = new WINDOW();
			self.input = new INPUT();

			bool bWINDOW = false;
			bool bINPUT = false;

			string[] windowSections = { "ForceBorderless", "ForceBorderlessFullscreen" };
			string[] inputSections = { "KeyCombination", "KeyUseEffect", "KeyFPSLimit", "KeyShowFPS", "KeyEditor", "KeyFreeVRAM" };

			var ss = File.ReadLines( fullpath );
			foreach( var s in ss ) {
				var section = s.match2( @"\[(.*)\]", ( m ) => {
					return m[ 1 ].ToString();
				} );

				if( section != null ) {
					if( s.Contains( "WINDOW" ) ) {
						bWINDOW = true;
						bINPUT = false;
					}
					else if( s.Contains( "INPUT" ) ) {
						bWINDOW = false;
						bINPUT = true;
					}
					else {
						bWINDOW = false;
						bINPUT = false;
					}
					continue;
				}
				else {
					if( bWINDOW ) {
						foreach( var sec in windowSections ) {
							bool value = false;
							var result = s.match2( $@"{sec}[\s\t]*=[\s\t]*(.*)", ( m ) => {
								return m[ 1 ].ToString();
							} );
							if( result.isEmpty() ) continue;
							bool.TryParse( result, out value );

							switch( sec ) {
							case "ForceBorderless":
								self.window.ForceBorderless = value;
								break;
							case "ForceBorderlessFullscreen":
								self.window.ForceBorderlessFullscreen = value;
								break;
							}
						}
					}
					else if( bINPUT ) {
						foreach( var sec in inputSections ) {
							int value = 0;
							var result = s.match2( $@"{sec}[\s\t]*=[\s\t]*(.*)", ( m ) => {
								return m[ 1 ].ToString();
							} );
							if( result.isEmpty() ) continue;
							int.TryParse( result, out value );

							switch( sec ) {
							case "KeyCombination":
								self.input.KeyCombination = value;
								break;
							case "KeyUseEffect":
								self.input.KeyUseEffect = value;
								break;
							case "KeyFPSLimit":
								self.input.KeyFPSLimit = value;
								break;
							case "KeyShowFPS":
								self.input.KeyShowFPS = value;
								break;
							case "KeyEditor":
								self.input.KeyEditor = value;
								break;
							case "KeyFreeVRAM":
								self.input.KeyFreeVRAM = value;
								break;
							}
							break;
						}
					}
				}
			}

			return self;
		}
	}
}
