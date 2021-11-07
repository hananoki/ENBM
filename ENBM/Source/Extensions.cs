using System.Windows.Forms;

namespace ENBM {
	public static class TagExtensions {
		public static string getURL( this LinkLabel ll ) {
			return (string) ll.Tag;
		}

		public static GameTitleList.Data getGameTitleData( this ToolStripItem tsi ) {
			return (GameTitleList.Data) tsi.Tag;
		}

	}
}
