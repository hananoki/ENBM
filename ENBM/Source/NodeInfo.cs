using HananokiLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ENBM {

	/////////////////////////////////////////
	public class NodeInfo {
		public string name;
		public string fullPath;
		public TreeNode node;

		public virtual string getGameFolderPath() {
			return "";
		}
	} // class



	/////////////////////////////////////////
	public class NodeTitle : NodeInfo {

		public List<NodePreset> presets;
		public NodePreset installed;


		public TreeNode makeNode() {
			node = new TreeNode( name );

			int result;
			if( MainForm.iconIndexs.TryGetValue( name, out result ) ) {
				node.ImageIndex = result;
				node.SelectedImageIndex = result;
			}

			var dirs = Directory.GetDirectories( fullPath );

			presets = dirs.Where( x => !x.getFileName().StartsWith(".") ).Select( x =>
							new NodePreset { name = x.getFileName(), fullPath = x, title = this } ).ToList();

			foreach( var a in presets ) {
				var treeNnode = a.makeNode();
				node.Nodes.Add( treeNnode );
				MainForm.nodeInfos.Add( treeNnode, a );
			}

			var steamPath = Utils.getSteamFolder();
			var installPath = $@"{steamPath}\steamapps\common\{name}";
			if( installPath.isExistsDirectory() ) {
				var metaPath = $@"{installPath}\.enbm";
				if( metaPath.isExistsFile() ) {
					var ss = File.ReadAllLines( metaPath );
					var find = presets.Find( x => x.GUID == ss[ 0 ] );
					if( find != null ) {
						find.node.ImageIndex = 2;
						find.node.SelectedImageIndex = 2;

						installed = find;
					}
				}
			}
			return node;
		}



		public override string getGameFolderPath() {
			var steamPath = Utils.getSteamFolder();
			var path = $@"{steamPath}\steamapps\common\{name}";
			return path.separatorToOS();
		}

	} // class



	/////////////////////////////////////////
	public class NodePreset : NodeInfo {

		public NodeTitle title;

		public List<string> m_targetFileName; ///< コピーするファイルリスト
		public string GUID;


		public TreeNode makeNode() {
			node = new TreeNode( name );
			node.ImageIndex = 1;
			node.SelectedImageIndex = 1;
			var metaPath = $@"{fullPath}\.enbm";

			if( metaPath.isExistsFile() ) {
				var ss = File.ReadAllLines( metaPath );
				GUID = ss[ 0 ];
			}
			else {
				var id = Guid.NewGuid();
				GUID = id.ToString();
				File.WriteAllText( metaPath, GUID );
			}
			return node;
		}
	} // class
}
