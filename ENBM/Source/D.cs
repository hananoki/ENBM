using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace ENBM {

	public class D {
		public const int ENABLE_PRESET_UPDATE = 0x01;
		public const int ENABLE_SAVE_AND_INSTALL = 0x02;

		public const int ENABLE_ENBLOCAL = 0x01;
	}

	public class FilePathTag {
		public NodeTitle nodeTitle;
		public string fullpath;
	}

}
