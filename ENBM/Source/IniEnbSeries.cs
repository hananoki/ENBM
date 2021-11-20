
using HananokiLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace ENBM {
	/// http://programmers.high-way.info/cs/property-grid-sort_dropdown.htmlから引用
	class UITypeEditorDropDown : UITypeEditor {
		public override UITypeEditorEditStyle GetEditStyle( ITypeDescriptorContext context ) {
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue( ITypeDescriptorContext context, IServiceProvider provider, object value ) {
			IWindowsFormsEditorService s = provider.GetService( typeof( IWindowsFormsEditorService ) ) as IWindowsFormsEditorService;

			if( s != null ) {
				var list = new ListBox();
				list.Font = SystemFonts.IconTitleFont;
				list.BorderStyle = BorderStyle.None;
				// リストボックスに項目をセット
				list.Items.Add( "2" );
				list.Items.Add( "4" );
				list.Items.Add( "6" );
				list.Items.Add( "8" );
				list.Items.Add( "10" );
				list.Items.Add( "12" );
				list.Items.Add( "14" );
				list.Items.Add( "16" );
				//list.Site = s.;

				// リストの項目に一致するものがあれば選択する
				if( list.Items.Contains( value.ToString() ) ) {
					list.SelectedItem = value.ToString();
				}

				// クリックで閉じるようにする
				EventHandler onclick = ( sender, e ) => {
					s.CloseDropDown();
				};

				list.Click += onclick;

				// ドロップダウンリストの表示
				s.DropDownControl( list );

				list.Click -= onclick;

				// 選択されていればその値を返す
				return ( list.SelectedItem != null ) ? list.SelectedItem : value;
			}
			return value;
		}
	}

	class ReservedMemorySizeMbDropDown : UITypeEditor {
		public override UITypeEditorEditStyle GetEditStyle( ITypeDescriptorContext context ) {
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue( ITypeDescriptorContext context, IServiceProvider provider, object value ) {
			IWindowsFormsEditorService s = provider.GetService( typeof( IWindowsFormsEditorService ) ) as IWindowsFormsEditorService;

			if( s != null ) {
				var list = new ListBox();
				list.Font = SystemFonts.IconTitleFont;
				list.BorderStyle = BorderStyle.None;
				
				list.Items.Add( "64" );
				list.Items.Add( "128" );
				list.Items.Add( "256" );
				list.Items.Add( "384" );
				list.Items.Add( "512" );
				list.Items.Add( "640" );
				list.Items.Add( "768" );
				list.Items.Add( "896" );
				list.Items.Add( "1024" );

				if( list.Items.Contains( value.ToString() ) ) {
					list.SelectedItem = value.ToString();
				}

				// クリックで閉じるようにする
				EventHandler onclick = ( sender, e ) => {
					s.CloseDropDown();
				};

				list.Click += onclick;

				// ドロップダウンリストの表示
				s.DropDownControl( list );

				list.Click -= onclick;

				// 選択されていればその値を返す
				return ( list.SelectedItem != null ) ? list.SelectedItem : value;
			}
			return value;
		}
	}



	//////////////////////////////////////////////////////////////////////////////////
	public class IniEnbSeriesTypeConverter : TypeConverter {

		public enum Quality3 {
			High = 0,
			Medium = 1,
			Low = 2,
		}
		public enum Quality4 {
			Extreme = -1,
			High = 0,
			Medium = 1,
			Low = 2,
		}


		public class AnisotropySize { }

		public class ReservedMemorySizeMb { }


		public class RegisterType {
			public string name;
			public Type type;
			public string desc;
		}

		internal static Dictionary<string, RegisterType> s_registerTypes;


		protected readonly Type type;



		/////////////////////////////////////////
		public static void registerParameter( RegisterType[] rt ) {
			s_registerTypes = new Dictionary<string, RegisterType>();
			foreach( var p in rt ) {
				s_registerTypes.Add( p.name, p );
			}
		}


		/////////////////////////////////////////
		public IniEnbSeriesTypeConverter( Type type ) {
			this.type = type;
		}


		/////////////////////////////////////////
		public override bool GetPropertiesSupported( ITypeDescriptorContext context ) => true;


		/////////////////////////////////////////
		public override PropertyDescriptorCollection GetProperties( ITypeDescriptorContext context, object value, Attribute[] attributes ) {
			var list = new List<PropertyDescriptor>();

			var ini = value as IniEnbSeries;

			int i = 1;
			foreach( var p in ini.m_sections ) {
				foreach( var v in p.values ) {
					list.Add( CreateDescriptor( ini, $"{i:D2} - [{p.name}]", v ) );
				}
				i++;
			}

			return new PropertyDescriptorCollection( list.ToArray() );
		}


		/////////////////////////////////////////
		PropertyDescriptor CreateDescriptor( IniEnbSeries ini, string sectionName, IniFile.KeyValue keyValue ) {

			RegisterType registerType;
			s_registerTypes.TryGetValue( keyValue.key, out registerType );

			// 登録型から見つからない場合は値を見て自動設定、正確さに欠ける
			if( registerType == null ) {
				registerType = new RegisterType();
				var ss = keyValue.value.ToLower();
				if( ss == "true" || ss == "false" ) {
					registerType.type = typeof( bool );
				}
				else if( ss.match( @"[0-9]+\.[0-9]+" ) ) {
					registerType.type = typeof( double );
				}
				else if( ss.match( @"-?[0-9]+" ) ) {
					registerType.type = typeof( int );
				}
				Debug.Log( $"自動設定: {keyValue.key}" );
			}

			if( registerType.type == typeof( AnisotropySize ) ) {
				return new IniDescriptor( type, ini, keyValue, registerType,
					new CategoryAttribute( sectionName ),
					new DescriptionAttribute( registerType.desc ),
					new EditorAttribute( typeof( UITypeEditorDropDown ), typeof( UITypeEditor ) ) );
			}
			else if( registerType.type == typeof( ReservedMemorySizeMb ) ) {
				return new IniDescriptor( type, ini, keyValue, registerType,
					new CategoryAttribute( sectionName ),
					new DescriptionAttribute( registerType.desc ),
					new EditorAttribute( typeof( ReservedMemorySizeMbDropDown ), typeof( UITypeEditor ) ) );
			}
			else {
				return new IniDescriptor( type, ini, keyValue, registerType,
					new CategoryAttribute( sectionName ), new DescriptionAttribute( registerType.desc ) );
			}
		}


		//////////////////////////////////////////////////////////////////////////////////
		class IniDescriptor : SimplePropertyDescriptor {

			IniEnbSeries obj;
			IniFile.KeyValue keyValue;
			RegisterType m_registerType;

			public IniDescriptor( Type componentType, IniEnbSeries obj, IniFile.KeyValue keyValue, RegisterType registerType, params Attribute[] attributes )
				: base( componentType, keyValue.key, obj.GetType(), attributes ) {
				this.obj = obj;
				this.keyValue = keyValue;
				m_registerType = registerType;

				if( m_registerType.type == typeof( bool ) ) {
					Converter = new BooleanConverter();
				}
				else if( m_registerType.type == typeof( double ) ) {
					Converter = new DoubleConverter();
				}
				else if( m_registerType.type == typeof( int ) ) {
					Converter = new Int32Converter();
				}
				else if( m_registerType.type == typeof( uint ) ) {
					Converter = new UInt32Converter();
				}
				else if( m_registerType.type == typeof( AnisotropySize ) ) {
					Converter = new UInt32Converter();
				}
				else if( m_registerType.type == typeof( ReservedMemorySizeMb ) ) {
					Converter = new UInt32Converter();
				}
				else if( m_registerType.type != null && m_registerType.type.IsEnum ) {
					Converter = new EnumConverter( m_registerType.type );
				}
				else {
					Converter = new StringConverter();
				}
			}


			public override TypeConverter Converter { get; }

			public override object GetValue( object component ) {
				if( m_registerType.type == typeof( bool ) ) {
					return keyValue.getBool();
				}
				else {
					return keyValue.value;
				}
			}

			public override void SetValue( object component, object value ) {
				var t = value.GetType();
				if( t == typeof( bool ) ) {
					keyValue.setBool( (bool) value );
				}
				else if( t == typeof( double ) ) {
					keyValue.setDouble( (double) value );
				}
				else if( t == typeof( int ) ) {
					keyValue.setInt( (int) value );
				}
				else if( t == typeof( uint ) ) {
					keyValue.setInt( (int) value );
				}
				else if( t.IsEnum ) {
					keyValue.setInt( (int) value );
				}
				else {
					keyValue.value = (string) value;
				}
			}
		}
	}


	//////////////////////////////////////////////////////////////////////////////////
	[TypeConverter( typeof( IniEnbSeriesTypeConverter ) )]
	public class IniEnbSeries : IniFile { }


#if false
	public class IniEnbSeries {
		IniFile iniFile;

		public enum Quality4 {
			Extreme = -1,
			High = 0,
			Medium = 1,
			Low = 2,
		}
		public enum Quality3 {
			High = 0,
			Medium = 1,
			Low = 2,
		}

		public static IniEnbSeries load( string filePath ) {
			var ies = new IniEnbSeries();
			ies.iniFile = IniFile.load( filePath );
			return ies;
		}

		public void save( string filePath ) {
			iniFile.save( filePath );
		}

		const string cGLOBAL = "GLOBAL";
		const string cEFFECT = "EFFECT";
		const string cCOLORCORRECTION = "COLORCORRECTION";
		const string cNIGHTDAY = "NIGHTDAY";
		const string cADAPTATION = "ADAPTATION";
		const string cBLOOM = "BLOOM";
		const string cLENS = "LENS";
		const string cSSAO_SSIL = "SSAO_SSIL";
		const string cENVIRONMENT = "ENVIRONMENT";
		const string cSKY = "SKY";
		const string cDEPTHOFFIELD = "DEPTHOFFIELD";
		const string cSHADOW = "SHADOW";
		const string cRAYS = "RAYS";
		const string cPARTICLES = "PARTICLES";
		const string cFIRE = "FIRE";
		const string cLIGHTEMITTERS = "LIGHTEMITTERS";


		/////////////////////////////////////////
	#region GLOBAL

		[Category( cGLOBAL )]
		public bool UseEffect {
			get => iniFile.getBool( cGLOBAL, "UseEffect" );
			set => iniFile.setBool( cGLOBAL, "UseEffect", value );
		}

	#endregion


		/////////////////////////////////////////
	#region EFFECT

		[Category( cEFFECT )]
		public bool UseOriginalPostProcessing {
			get => iniFile.getBool( cEFFECT, "UseOriginalPostProcessing" );
			set => iniFile.setBool( cEFFECT, "UseOriginalPostProcessing", value );
		}
		[Category( cEFFECT )]
		public bool UseOriginalObjectsProcessing {
			get => iniFile.getBool( cEFFECT, "UseOriginalObjectsProcessing" );
			set => iniFile.setBool( cEFFECT, "UseOriginalObjectsProcessing", value );
		}
		[Category( cEFFECT )]
		public bool EnableBloom {
			get => iniFile.getBool( cEFFECT, "EnableBloom" );
			set => iniFile.setBool( cEFFECT, "EnableBloom", value );
		}
		[Category( cEFFECT )]
		public bool EnableLens {
			get => iniFile.getBool( cEFFECT, "EnableLens" );
			set => iniFile.setBool( cEFFECT, "EnableLens", value );
		}
		[Category( cEFFECT )]
		public bool EnableAdaptation {
			get => iniFile.getBool( cEFFECT, "EnableAdaptation" );
			set => iniFile.setBool( cEFFECT, "EnableAdaptation", value );
		}
		[Category( cEFFECT )]
		public bool EnableDepthOfField {
			get => iniFile.getBool( cEFFECT, "EnableDepthOfField" );
			set => iniFile.setBool( cEFFECT, "EnableDepthOfField", value );
		}
		[Category( cEFFECT )]
		public bool EnableAmbientOcclusion {
			get => iniFile.getBool( cEFFECT, "EnableAmbientOcclusion" );
			set => iniFile.setBool( cEFFECT, "EnableAmbientOcclusion", value );
		}
		[Category( cEFFECT )]
		public bool EnableDetailedShadow {
			get => iniFile.getBool( cEFFECT, "EnableDetailedShadow" );
			set => iniFile.setBool( cEFFECT, "EnableDetailedShadow", value );
		}
		[Category( cEFFECT )]
		public bool EnableSunRays {
			get => iniFile.getBool( cEFFECT, "EnableSunRays" );
			set => iniFile.setBool( cEFFECT, "EnableSunRays", value );
		}
		[Category( cEFFECT )]
		public bool EnableSunGlare {
			get => iniFile.getBool( cEFFECT, "EnableSunGlare" );
			set => iniFile.setBool( cEFFECT, "EnableSunGlare", value );
		}
	#endregion


		/////////////////////////////////////////
	#region COLORCORRECTION
		[Category( cCOLORCORRECTION )]
		public bool UsePaletteTexture {
			get => iniFile.getBool( cCOLORCORRECTION, "UsePaletteTexture" );
			set => iniFile.setBool( cCOLORCORRECTION, "UsePaletteTexture", value );
		}
		[Category( cCOLORCORRECTION )]
		public bool UseProceduralCorrection {
			get => iniFile.getBool( cCOLORCORRECTION, "UseProceduralCorrection" );
			set => iniFile.setBool( cCOLORCORRECTION, "UseProceduralCorrection", value );
		}
		[Category( cCOLORCORRECTION )]
		public float Brightness {
			get => iniFile.getFloat( cCOLORCORRECTION, "Brightness" );
			set => iniFile.setFloat( cCOLORCORRECTION, "Brightness", value );
		}
		[Category( cCOLORCORRECTION )]
		public float GammaCurve {
			get => iniFile.getFloat( cCOLORCORRECTION, "GammaCurve" );
			set => iniFile.setFloat( cCOLORCORRECTION, "GammaCurve", value );
		}
	#endregion


		/////////////////////////////////////////
	#region NIGHTDAY

		[Category( cNIGHTDAY )]
		public bool DetectorDefaultDay {
			get => iniFile.getBool( cNIGHTDAY, "DetectorDefaultDay" );
			set => iniFile.setBool( cNIGHTDAY, "DetectorDefaultDay", value );
		}
		[Category( cNIGHTDAY )]
		public float DetectorLevelDay {
			get => iniFile.getFloat( cNIGHTDAY, "DetectorLevelDay" );
			set => iniFile.setFloat( cNIGHTDAY, "DetectorLevelDay", value );
		}
		[Category( cNIGHTDAY )]
		public float DetectorLevelNight {
			get => iniFile.getFloat( cNIGHTDAY, "DetectorLevelNight" );
			set => iniFile.setFloat( cNIGHTDAY, "DetectorLevelNight", value );
		}
		[Category( cNIGHTDAY )]
		public float DetectorLevelCurve {
			get => iniFile.getFloat( cNIGHTDAY, "DetectorLevelCurve" );
			set => iniFile.setFloat( cNIGHTDAY, "DetectorLevelCurve", value );
		}

	#endregion


		/////////////////////////////////////////
	#region ADAPTATION

		[Category( cADAPTATION )]
		public bool ForceMinMaxValues {
			get => iniFile.getBool( cADAPTATION, "ForceMinMaxValues" );
			set => iniFile.setBool( cADAPTATION, "ForceMinMaxValues", value );
		}
		[Category( cADAPTATION )]
		public float AdaptationSensitivity {
			get => iniFile.getFloat( cADAPTATION, "AdaptationSensitivity" );
			set => iniFile.setFloat( cADAPTATION, "AdaptationSensitivity", value );
		}
		[Category( cADAPTATION )]
		public float AdaptationTime {
			get => iniFile.getFloat( cADAPTATION, "AdaptationTime" );
			set => iniFile.setFloat( cADAPTATION, "AdaptationTime", value );
		}
		[Category( cADAPTATION )]
		public float AdaptationMin {
			get => iniFile.getFloat( cADAPTATION, "AdaptationMin" );
			set => iniFile.setFloat( cADAPTATION, "AdaptationMin", value );
		}
		[Category( cADAPTATION )]
		public float AdaptationMax {
			get => iniFile.getFloat( cADAPTATION, "AdaptationMax" );
			set => iniFile.setFloat( cADAPTATION, "AdaptationMax", value );
		}

	#endregion


		/////////////////////////////////////////
	#region BLOOM

		[Category( cBLOOM )]
		public int Quality {
			get => iniFile.getInt( cBLOOM, "Quality" );
			set => iniFile.setInt( cBLOOM, "Quality", value );
		}
		[Category( cBLOOM )]
		public float AmountDay {
			get => iniFile.getFloat( cBLOOM, "AmountDay" );
			set => iniFile.setFloat( cBLOOM, "AmountDay", value );
		}
		[Category( cBLOOM )]
		public float AmountNight {
			get => iniFile.getFloat( cBLOOM, "AmountNight" );
			set => iniFile.setFloat( cBLOOM, "AmountNight", value );
		}
		[Category( cBLOOM )]
		public float AmountInterior {
			get => iniFile.getFloat( cBLOOM, "AmountInterior" );
			set => iniFile.setFloat( cBLOOM, "AmountInterior", value );
		}
		[Category( cBLOOM )]
		public float BlueShiftAmountDay {
			get => iniFile.getFloat( cBLOOM, "BlueShiftAmountDay" );
			set => iniFile.setFloat( cBLOOM, "BlueShiftAmountDay", value );
		}
		[Category( cBLOOM )]
		public float BlueShiftAmountNight {
			get => iniFile.getFloat( cBLOOM, "BlueShiftAmountNight" );
			set => iniFile.setFloat( cBLOOM, "BlueShiftAmountNight", value );
		}
		[Category( cBLOOM )]
		public float BlueShiftAmountInterior {
			get => iniFile.getFloat( cBLOOM, "BlueShiftAmountInterior" );
			set => iniFile.setFloat( cBLOOM, "BlueShiftAmountInterior", value );
		}

	#endregion


		/////////////////////////////////////////
	#region LENS

		[Category( cLENS )]
		public float LenzReflectionIntensityDay {
			get => iniFile.getFloat( cLENS, "LenzReflectionIntensityDay" );
			set => iniFile.setFloat( cLENS, "LenzReflectionIntensityDay", value );
		}
		[Category( cLENS )]
		public float LenzReflectionIntensityNight {
			get => iniFile.getFloat( cLENS, "LenzReflectionIntensityNight" );
			set => iniFile.setFloat( cLENS, "LenzReflectionIntensityNight", value );
		}
		[Category( cLENS )]
		public float LenzReflectionIntensityInterior {
			get => iniFile.getFloat( cLENS, "LenzReflectionIntensityInterior" );
			set => iniFile.setFloat( cLENS, "LenzReflectionIntensityInterior", value );
		}
		[Category( cLENS )]
		public float LenzReflectionPowerDay {
			get => iniFile.getFloat( cLENS, "LenzReflectionPowerDay" );
			set => iniFile.setFloat( cLENS, "LenzReflectionPowerDay", value );
		}
		[Category( cLENS )]
		public float LenzReflectionPowerNight {
			get => iniFile.getFloat( cLENS, "LenzReflectionPowerNight" );
			set => iniFile.setFloat( cLENS, "LenzReflectionPowerNight", value );
		}
		[Category( cLENS )]
		public float LenzReflectionPowerInterior {
			get => iniFile.getFloat( cLENS, "LenzReflectionPowerInterior" );
			set => iniFile.setFloat( cLENS, "LenzReflectionPowerInterior", value );
		}
		[Category( cLENS )]
		public float LenzDirtIntensityDay {
			get => iniFile.getFloat( cLENS, "LenzDirtIntensityDay" );
			set => iniFile.setFloat( cLENS, "LenzDirtIntensityDay", value );
		}
		[Category( cLENS )]
		public float LenzDirtIntensityNight {
			get => iniFile.getFloat( cLENS, "LenzDirtIntensityNight" );
			set => iniFile.setFloat( cLENS, "LenzDirtIntensityNight", value );
		}
		[Category( cLENS )]
		public float LenzDirtIntensityInterior {
			get => iniFile.getFloat( cLENS, "LenzDirtIntensityInterior" );
			set => iniFile.setFloat( cLENS, "LenzDirtIntensityInterior", value );
		}
		[Category( cLENS )]
		public float LenzDirtPowerDay {
			get => iniFile.getFloat( cLENS, "LenzDirtPowerDay" );
			set => iniFile.setFloat( cLENS, "LenzDirtPowerDay", value );
		}
		[Category( cLENS )]
		public float LenzDirtPowerNight {
			get => iniFile.getFloat( cLENS, "LenzDirtPowerNight" );
			set => iniFile.setFloat( cLENS, "LenzDirtPowerNight", value );
		}
		[Category( cLENS )]
		public float LenzDirtPowerInterior {
			get => iniFile.getFloat( cLENS, "LenzDirtPowerInterior" );
			set => iniFile.setFloat( cLENS, "LenzDirtPowerInterior", value );
		}

	#endregion


		/////////////////////////////////////////
	#region SSAO_SSIL

		[Category( cSSAO_SSIL )]
		public bool UseIndirectLighting {
			get => iniFile.getBool( cSSAO_SSIL, "UseIndirectLighting" );
			set => iniFile.setBool( cSSAO_SSIL, "UseIndirectLighting", value );
		}

		[Category( cSSAO_SSIL )]
		public Quality4 SamplingQuality {
			get => (Quality4) iniFile.getInt( cSSAO_SSIL, "SamplingQuality" );
			set => iniFile.setInt( cSSAO_SSIL, "SamplingQuality", (int) value );
		}

		[Category( cSSAO_SSIL )]
		public int SamplingPrecision {
			get => iniFile.getInt( cSSAO_SSIL, "SamplingPrecision" );
			set => iniFile.setInt( cSSAO_SSIL, "SamplingPrecision", value );
		}
		[Category( cSSAO_SSIL )]
		public float SamplingRange {
			get => iniFile.getFloat( cSSAO_SSIL, "SamplingRange" );
			set => iniFile.setFloat( cSSAO_SSIL, "SamplingRange", value );
		}
		[Category( cSSAO_SSIL )]
		public float FadeFogRangeDay {
			get => iniFile.getFloat( cSSAO_SSIL, "FadeFogRangeDay" );
			set => iniFile.setFloat( cSSAO_SSIL, "FadeFogRangeDay", value );
		}
		[Category( cSSAO_SSIL )]
		public float FadeFogRangeNight {
			get => iniFile.getFloat( cSSAO_SSIL, "FadeFogRangeNight" );
			set => iniFile.setFloat( cSSAO_SSIL, "FadeFogRangeNight", value );
		}
		[Category( cSSAO_SSIL )]
		public float SizeScale {
			get => iniFile.getFloat( cSSAO_SSIL, "SizeScale" );
			set => iniFile.setFloat( cSSAO_SSIL, "SizeScale", value );
		}
		[Category( cSSAO_SSIL )]
		public float SourceTexturesScale {
			get => iniFile.getFloat( cSSAO_SSIL, "SourceTexturesScale" );
			set => iniFile.setFloat( cSSAO_SSIL, "SourceTexturesScale", value );
		}
		[Category( cSSAO_SSIL )]
		public Quality3 FilterQuality {
			get => (Quality3) iniFile.getInt( cSSAO_SSIL, "FilterQuality" );
			set => iniFile.setInt( cSSAO_SSIL, "FilterQuality", (int) value );
		}
		[Category( cSSAO_SSIL )]
		public float AOAmount {
			get => iniFile.getFloat( cSSAO_SSIL, "AOAmount" );
			set => iniFile.setFloat( cSSAO_SSIL, "AOAmount", value );
		}
		[Category( cSSAO_SSIL )]
		public float AOAmountInterior {
			get => iniFile.getFloat( cSSAO_SSIL, "AOAmountInterior" );
			set => iniFile.setFloat( cSSAO_SSIL, "AOAmountInterior", value );
		}
		[Category( cSSAO_SSIL )]
		public float ILAmount {
			get => iniFile.getFloat( cSSAO_SSIL, "ILAmount" );
			set => iniFile.setFloat( cSSAO_SSIL, "ILAmount", value );
		}
		[Category( cSSAO_SSIL )]
		public float ILAmountInterior {
			get => iniFile.getFloat( cSSAO_SSIL, "ILAmountInterior" );
			set => iniFile.setFloat( cSSAO_SSIL, "ILAmountInterior", value );
		}
		[Category( cSSAO_SSIL )]
		public float AOIntensity {
			get => iniFile.getFloat( cSSAO_SSIL, "AOIntensity" );
			set => iniFile.setFloat( cSSAO_SSIL, "AOIntensity", value );
		}
		[Category( cSSAO_SSIL )]
		public float AOIntensityInterior {
			get => iniFile.getFloat( cSSAO_SSIL, "AOIntensityInterior" );
			set => iniFile.setFloat( cSSAO_SSIL, "AOIntensityInterior", value );
		}
		[Category( cSSAO_SSIL )]
		public int AOType {
			get => iniFile.getInt( cSSAO_SSIL, "AOType" );
			set => iniFile.setInt( cSSAO_SSIL, "AOType", value );
		}
		[Category( cSSAO_SSIL )]
		public int AOMixingType {
			get => iniFile.getInt( cSSAO_SSIL, "AOMixingType" );
			set => iniFile.setInt( cSSAO_SSIL, "AOMixingType", value );
		}
		[Category( cSSAO_SSIL )]
		public int AOMixingTypeInterior {
			get => iniFile.getInt( cSSAO_SSIL, "AOMixingTypeInterior" );
			set => iniFile.setInt( cSSAO_SSIL, "AOMixingTypeInterior", value );
		}
		[Category( cSSAO_SSIL )]
		public bool EnableSupersampling {
			get => iniFile.getBool( cSSAO_SSIL, "EnableSupersampling" );
			set => iniFile.setBool( cSSAO_SSIL, "EnableSupersampling", value );
		}
		[Category( cSSAO_SSIL )]
		public bool EnableDenoiser {
			get => iniFile.getBool( cSSAO_SSIL, "EnableDenoiser" );
			set => iniFile.setBool( cSSAO_SSIL, "EnableDenoiser", value );
		}

	#endregion


		/////////////////////////////////////////
	#region ENVIRONMENT

		[Category( cENVIRONMENT )]
		public float LightingIntensityDay {
			get => iniFile.getFloat( cENVIRONMENT, "LightingIntensityDay" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingIntensityDay", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingIntensityNight {
			get => iniFile.getFloat( cENVIRONMENT, "LightingIntensityNight" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingIntensityNight", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingIntensityInterior {
			get => iniFile.getFloat( cENVIRONMENT, "LightingIntensityInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingIntensityInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingCurveDay {
			get => iniFile.getFloat( cENVIRONMENT, "LightingCurveDay" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingCurveDay", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingCurveNight {
			get => iniFile.getFloat( cENVIRONMENT, "LightingCurveNight" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingCurveNight", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingCurveInterior {
			get => iniFile.getFloat( cENVIRONMENT, "LightingCurveInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingCurveInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingDesaturationDay {
			get => iniFile.getFloat( cENVIRONMENT, "LightingDesaturationDay" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingDesaturationDay", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingDesaturationNight {
			get => iniFile.getFloat( cENVIRONMENT, "LightingDesaturationNight" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingDesaturationNight", value );
		}
		[Category( cENVIRONMENT )]
		public float LightingDesaturationInterior {
			get => iniFile.getFloat( cENVIRONMENT, "LightingDesaturationInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "LightingDesaturationInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingIntensityDay {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingIntensityDay" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingIntensityDay", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingIntensityNight {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingIntensityNight" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingIntensityNight", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingIntensityInterior {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingIntensityInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingIntensityInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingCurveDay {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingCurveDay" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingCurveDay", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingCurveNight {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingCurveNight" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingCurveNight", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingCurveInterior {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingCurveInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingCurveInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingDesaturationDay {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingDesaturationDay" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingDesaturationDay", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingDesaturationNight {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingDesaturationNight" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingDesaturationNight", value );
		}
		[Category( cENVIRONMENT )]
		public float AmbientLightingDesaturationInterior {
			get => iniFile.getFloat( cENVIRONMENT, "AmbientLightingDesaturationInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "AmbientLightingDesaturationInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorMultiplierDay {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorMultiplierDay" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorMultiplierDay", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorMultiplierNight {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorMultiplierNight" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorMultiplierNight", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorMultiplierInterior {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorMultiplierInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorMultiplierInterior", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorCurveDay {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorCurveDay" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorCurveDay", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorCurveNight {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorCurveNight" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorCurveNight", value );
		}
		[Category( cENVIRONMENT )]
		public float FogColorCurveInterior {
			get => iniFile.getFloat( cENVIRONMENT, "FogColorCurveInterior" );
			set => iniFile.setFloat( cENVIRONMENT, "FogColorCurveInterior", value );
		}

	#endregion


		/////////////////////////////////////////
	#region SKY

		[Category( cSKY )]
		public bool Enable {
			get => iniFile.getBool( cSKY, "Enable" );
			set => iniFile.setBool( cSKY, "Enable", value );
		}
		[Category( cSKY )]
		public float StarsIntensity {
			get => iniFile.getFloat( cSKY, "StarsIntensity" );
			set => iniFile.setFloat( cSKY, "StarsIntensity", value );
		}
		[Category( cSKY )]
		public float CloudsIntensityDay {
			get => iniFile.getFloat( cSKY, "CloudsIntensityDay" );
			set => iniFile.setFloat( cSKY, "CloudsIntensityDay", value );
		}
		[Category( cSKY )]
		public float CloudsIntensityNight {
			get => iniFile.getFloat( cSKY, "CloudsIntensityNight" );
			set => iniFile.setFloat( cSKY, "CloudsIntensityNight", value );
		}
		[Category( cSKY )]
		public float CloudsCurveDay {
			get => iniFile.getFloat( cSKY, "CloudsCurveDay" );
			set => iniFile.setFloat( cSKY, "CloudsCurveDay", value );
		}
		[Category( cSKY )]
		public float CloudsCurveNight {
			get => iniFile.getFloat( cSKY, "CloudsCurveNight" );
			set => iniFile.setFloat( cSKY, "CloudsCurveNight", value );
		}
		[Category( cSKY )]
		public float CloudsDesaturationDay {
			get => iniFile.getFloat( cSKY, "CloudsDesaturationDay" );
			set => iniFile.setFloat( cSKY, "CloudsDesaturationDay", value );
		}
		[Category( cSKY )]
		public float CloudsDesaturationNight {
			get => iniFile.getFloat( cSKY, "CloudsDesaturationNight" );
			set => iniFile.setFloat( cSKY, "CloudsDesaturationNight", value );
		}
		[Category( cSKY )]
		public float CloudsEdgeClamp {
			get => iniFile.getFloat( cSKY, "CloudsEdgeClamp" );
			set => iniFile.setFloat( cSKY, "CloudsEdgeClamp", value );
		}
		[Category( cSKY )]
		public float CloudsEdgeIntensity {
			get => iniFile.getFloat( cSKY, "CloudsEdgeIntensity" );
			set => iniFile.setFloat( cSKY, "CloudsEdgeIntensity", value );
		}
		[Category( cSKY )]
		public float GradientIntensityDay {
			get => iniFile.getFloat( cSKY, "GradientIntensityDay" );
			set => iniFile.setFloat( cSKY, "GradientIntensityDay", value );
		}
		[Category( cSKY )]
		public float GradientIntensityNight {
			get => iniFile.getFloat( cSKY, "GradientIntensityNight" );
			set => iniFile.setFloat( cSKY, "GradientIntensityNight", value );
		}
		[Category( cSKY )]
		public float GradientDesaturationDay {
			get => iniFile.getFloat( cSKY, "GradientDesaturationDay" );
			set => iniFile.setFloat( cSKY, "GradientDesaturationDay", value );
		}
		[Category( cSKY )]
		public float GradientDesaturationNight {
			get => iniFile.getFloat( cSKY, "GradientDesaturationNight" );
			set => iniFile.setFloat( cSKY, "GradientDesaturationNight", value );
		}
		[Category( cSKY )]
		public float GradientTopIntensityDay {
			get => iniFile.getFloat( cSKY, "GradientTopIntensityDay" );
			set => iniFile.setFloat( cSKY, "GradientTopIntensityDay", value );
		}
		[Category( cSKY )]
		public float GradientTopIntensityNight {
			get => iniFile.getFloat( cSKY, "GradientTopIntensityNight" );
			set => iniFile.setFloat( cSKY, "GradientTopIntensityNight", value );
		}
		[Category( cSKY )]
		public float GradientTopCurveDay {
			get => iniFile.getFloat( cSKY, "GradientTopCurveDay" );
			set => iniFile.setFloat( cSKY, "GradientTopCurveDay", value );
		}
		[Category( cSKY )]
		public float GradientTopCurveNight {
			get => iniFile.getFloat( cSKY, "GradientTopCurveNight" );
			set => iniFile.setFloat( cSKY, "GradientTopCurveNight", value );
		}
		[Category( cSKY )]
		public float GradientMiddleIntensityDay {
			get => iniFile.getFloat( cSKY, "GradientMiddleIntensityDay" );
			set => iniFile.setFloat( cSKY, "GradientMiddleIntensityDay", value );
		}
		[Category( cSKY )]
		public float GradientMiddleIntensityNight {
			get => iniFile.getFloat( cSKY, "GradientMiddleIntensityNight" );
			set => iniFile.setFloat( cSKY, "GradientMiddleIntensityNight", value );
		}
		[Category( cSKY )]
		public float GradientMiddleCurveDay {
			get => iniFile.getFloat( cSKY, "GradientMiddleCurveDay" );
			set => iniFile.setFloat( cSKY, "GradientMiddleCurveDay", value );
		}
		[Category( cSKY )]
		public float GradientMiddleCurveNight {
			get => iniFile.getFloat( cSKY, "GradientMiddleCurveNight" );
			set => iniFile.setFloat( cSKY, "GradientMiddleCurveNight", value );
		}
		[Category( cSKY )]
		public float GradientHorizonIntensityDay {
			get => iniFile.getFloat( cSKY, "GradientHorizonIntensityDay" );
			set => iniFile.setFloat( cSKY, "GradientHorizonIntensityDay", value );
		}
		[Category( cSKY )]
		public float GradientHorizonIntensityNight {
			get => iniFile.getFloat( cSKY, "GradientHorizonIntensityNight" );
			set => iniFile.setFloat( cSKY, "GradientHorizonIntensityNight", value );
		}
		[Category( cSKY )]
		public float GradientHorizonCurveDay {
			get => iniFile.getFloat( cSKY, "GradientHorizonCurveDay" );
			set => iniFile.setFloat( cSKY, "GradientHorizonCurveDay", value );
		}
		[Category( cSKY )]
		public float GradientHorizonCurveNight {
			get => iniFile.getFloat( cSKY, "GradientHorizonCurveNight" );
			set => iniFile.setFloat( cSKY, "GradientHorizonCurveNight", value );
		}
		[Category( cSKY )]
		public float SunIntensity {
			get => iniFile.getFloat( cSKY, "SunIntensity" );
			set => iniFile.setFloat( cSKY, "SunIntensity", value );
		}
		[Category( cSKY )]
		public float SunDesaturation {
			get => iniFile.getFloat( cSKY, "SunDesaturation" );
			set => iniFile.setFloat( cSKY, "SunDesaturation", value );
		}
		[Category( cSKY )]
		public float SunCoronaIntensity {
			get => iniFile.getFloat( cSKY, "SunCoronaIntensity" );
			set => iniFile.setFloat( cSKY, "SunCoronaIntensity", value );
		}
		[Category( cSKY )]
		public float SunCoronaCurve {
			get => iniFile.getFloat( cSKY, "SunCoronaCurve" );
			set => iniFile.setFloat( cSKY, "SunCoronaCurve", value );
		}
		[Category( cSKY )]
		public float SunCoronaDesaturation {
			get => iniFile.getFloat( cSKY, "SunCoronaDesaturation" );
			set => iniFile.setFloat( cSKY, "SunCoronaDesaturation", value );
		}
		[Category( cSKY )]
		public float MoonIntensity {
			get => iniFile.getFloat( cSKY, "MoonIntensity" );
			set => iniFile.setFloat( cSKY, "MoonIntensity", value );
		}
		[Category( cSKY )]
		public float MoonCurve {
			get => iniFile.getFloat( cSKY, "MoonCurve" );
			set => iniFile.setFloat( cSKY, "MoonCurve", value );
		}
		[Category( cSKY )]
		public float MoonDesaturation {
			get => iniFile.getFloat( cSKY, "MoonDesaturation" );
			set => iniFile.setFloat( cSKY, "MoonDesaturation", value );
		}
		[Category( cSKY )]
		public float MoonCoronaIntensity {
			get => iniFile.getFloat( cSKY, "MoonCoronaIntensity" );
			set => iniFile.setFloat( cSKY, "MoonCoronaIntensity", value );
		}

	#endregion


		/////////////////////////////////////////
	#region DEPTHOFFIELD

		[Category( cDEPTHOFFIELD )]
		public float FadeTime {
			get => iniFile.getFloat( cDEPTHOFFIELD, "FadeTime" );
			set => iniFile.setFloat( cDEPTHOFFIELD, "FadeTime", value );
		}

	#endregion


		/////////////////////////////////////////
	#region SHADOW

		[Category( cSHADOW )]
		public Quality4 DetailedShadowQuality {
			get => (Quality4) iniFile.getInt( cSHADOW, "DetailedShadowQuality" );
			set => iniFile.setInt( cSHADOW, "DetailedShadowQuality", (int) value );
		}
		[Category( cSHADOW )]
		public float ShadowDesaturation {
			get => iniFile.getFloat( cSHADOW, "ShadowDesaturation" );
			set => iniFile.setFloat( cSHADOW, "ShadowDesaturation", value );
		}

	#endregion


		/////////////////////////////////////////
	#region RAYS

		[Category( cRAYS )]
		public float SunRaysMultiplier {
			get => iniFile.getFloat( cRAYS, "SunRaysMultiplier" );
			set => iniFile.setFloat( cRAYS, "SunRaysMultiplier", value );
		}

	#endregion


		/////////////////////////////////////////
	#region PARTICLES

		[Category( cPARTICLES )]
		public float ParticlesIntensityDay {
			get => iniFile.getFloat( cPARTICLES, "ParticlesIntensityDay" );
			set => iniFile.setFloat( cPARTICLES, "ParticlesIntensityDay", value );
		}
		[Category( cPARTICLES )]
		public float ParticlesIntensityNight {
			get => iniFile.getFloat( cPARTICLES, "ParticlesIntensityNight" );
			set => iniFile.setFloat( cPARTICLES, "ParticlesIntensityNight", value );
		}
		[Category( cPARTICLES )]
		public float ParticlesIntensityInterior {
			get => iniFile.getFloat( cPARTICLES, "ParticlesIntensityInterior" );
			set => iniFile.setFloat( cPARTICLES, "ParticlesIntensityInterior", value );
		}

	#endregion


		/////////////////////////////////////////
	#region FIRE

		[Category( cFIRE )]
		public float FireIntensityDay {
			get => iniFile.getFloat( cFIRE, "FireIntensityDay" );
			set => iniFile.setFloat( cFIRE, "FireIntensityDay", value );
		}
		[Category( cFIRE )]
		public float FireIntensityNight {
			get => iniFile.getFloat( cFIRE, "FireIntensityNight" );
			set => iniFile.setFloat( cFIRE, "FireIntensityNight", value );
		}
		[Category( cFIRE )]
		public float FireIntensityInterior {
			get => iniFile.getFloat( cFIRE, "FireIntensityInterior" );
			set => iniFile.setFloat( cFIRE, "FireIntensityInterior", value );
		}

	#endregion


		/////////////////////////////////////////
	#region LIGHTEMITTERS

		[Category( cLIGHTEMITTERS )]
		public float LightEmittersIntensityDay {
			get => iniFile.getFloat( cLIGHTEMITTERS, "LightEmittersIntensityDay" );
			set => iniFile.setFloat( cLIGHTEMITTERS, "LightEmittersIntensityDay", value );
		}
		[Category( cLIGHTEMITTERS )]
		public float LightEmittersIntensityNight {
			get => iniFile.getFloat( cLIGHTEMITTERS, "LightEmittersIntensityNight" );
			set => iniFile.setFloat( cLIGHTEMITTERS, "LightEmittersIntensityNight", value );
		}
		[Category( cLIGHTEMITTERS )]
		public float LightEmittersIntensityInterior {
			get => iniFile.getFloat( cLIGHTEMITTERS, "LightEmittersIntensityInterior" );
			set => iniFile.setFloat( cLIGHTEMITTERS, "LightEmittersIntensityInterior", value );
		}

	#endregion
	}
#endif
}
