using System.Windows.Forms;


namespace ENBM {

	public class ListViewItemTag {
		public string fullpath;
	}

	public static class Extensions {
		public static string getFullPath( this ListViewItem item ) {
			return ((ListViewItemTag) item.Tag).fullpath;
		}
	}
}
