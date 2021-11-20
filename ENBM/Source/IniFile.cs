using HananokiLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ENBM {

	public class IniFile {

		public class Section {
			public string name;
			public List<KeyValue> values = new List<KeyValue>();
			public Dictionary<string, KeyValue> valuesMap = new Dictionary<string, KeyValue>();
			public void makeMap() {
				foreach( var p in values ) {
					valuesMap.Add( p.key, p );
				}
			}
		}


		public class KeyValue {
			public string key;
			public string value;
			public KeyValue( string key, string value ) {
				this.key = key;
				this.value = value;
			}

			public double getDouble() {
				return double.Parse( value );
			}
			public void setDouble( double v ) {
				value = v.ToString( "0.#########" );
				if( !value.Contains( "." ) ) {
					value = v.ToString( "F1" );
				}
			}

			public int getInt() {
				return int.Parse( value );
			}
			public void setInt( int v ) {
				value = v.ToString();
			}

			public bool getBool() {
				return bool.Parse( value );
			}
			public void setBool( bool v ) {
				value = v.ToString().ToLower();
			}
		}


		public List<string> m_headetText = new List<string>();
		public List<Section> m_sections = new List<Section>();

		public Dictionary<string, Section> m_sectionsMap = new Dictionary<string, Section>();

		public int m_parameterCount;


		/////////////////////////////////////////
		public void save( string filePath ) {
			var b = new StringBuilder();

			foreach( var t in m_headetText ) {
				b.AppendLine( t );
			}
			b.AppendLine( "" );

			foreach( var sec in m_sections ) {
				b.AppendLine( $"[{sec.name}]" );
				foreach( var v in sec.values ) {
					b.AppendLine( $"{v.key}={v.value}" );
				}
				b.AppendLine( "" );
			}

			File.WriteAllText( filePath, b.ToString() );
		}


		/////////////////////////////////////////
		public static T load<T>( string filePath ) where T : IniFile, new() {

			if( filePath.isEmpty() ) return null;
			if( !filePath.isExistsFile() ) return null;

			var ini = new T();

			var ss = File.ReadLines( filePath );

			Section currentSection = null;

			ini.m_parameterCount = 0;

			foreach( var s in ss ) {
				if( s.isEmpty() ) continue;

				var sectionName = s.match2( @"\[(.*)\]", ( m ) => {
					return m[ 1 ].ToString();
				} );

				if( sectionName != null ) {
					currentSection = new Section {
						name = sectionName,
					};
					ini.m_sections.Add( currentSection );
				}
				else {
					if( currentSection != null ) {
						// パラメータ名の行頭文字が普通ありそうな文字なら許可
						// #だったり/だったりよくわからんのはコメント扱いで無視
						// 保持しないのでセーブすると消える
						if( s.match( "^[a-zA-Z0-9_]" ) ) {
							try {
								// split結果が変なのは無視
								var sss = s.Split( '=' );
								if( sss.Length == 2 ) {
									currentSection.values.Add( new KeyValue( sss[ 0 ], sss[ 1 ] ) );
									ini.m_parameterCount++;
								}
							}
							catch( Exception e ) {
								Debug.Exception( e );
							}
						}
					}
					else {
						ini.m_headetText.Add( s );
					}
				}
			}

			foreach( var p in ini.m_sections ) {
				p.makeMap();
				ini.m_sectionsMap.Add( p.name, p );
			}

			return ini;
		}
	}
}
