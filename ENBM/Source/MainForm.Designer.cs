namespace ENBM {
	partial class MainForm {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imglst_Tree = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imglst_FilePath = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelR_Center = new System.Windows.Forms.Panel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label5 = new System.Windows.Forms.Label();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label3 = new System.Windows.Forms.Label();
			this.panelR_Top = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.linkLabel_Nexus = new System.Windows.Forms.LinkLabel();
			this.linkLabel_ENB = new System.Windows.Forms.LinkLabel();
			this.panelR_Bottom = new System.Windows.Forms.Panel();
			this.button_ExtractArcive = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Uninstall = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Install = new System.Windows.Forms.ToolStripButton();
			this.btnShowDialog = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.uiAddGameTitle = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_Language = new System.Windows.Forms.ToolStripLabel();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_Reload = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.cms_Title = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ゲームフォルダを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_Preset = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.プリセットフォルダを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.プリセットを削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.共通enblocaliniでリセットするToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wINDOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iNPUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelDockCenter = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelR_Center.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panelR_Top.SuspendLayout();
			this.panelR_Bottom.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.cms_Title.SuspendLayout();
			this.cms_Preset.SuspendLayout();
			this.panelDockCenter.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 4, 2);
			this.splitContainer1.Size = new System.Drawing.Size(740, 342);
			this.splitContainer1.SplitterDistance = 185;
			this.splitContainer1.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.FullRowSelect = true;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imglst_Tree;
			this.treeView1.Location = new System.Drawing.Point(4, 2);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowLines = false;
			this.treeView1.Size = new System.Drawing.Size(181, 338);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// imglst_Tree
			// 
			this.imglst_Tree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst_Tree.ImageStream")));
			this.imglst_Tree.TransparentColor = System.Drawing.Color.Transparent;
			this.imglst_Tree.Images.SetKeyName(0, "ゲームの無料アイコン.png");
			this.imglst_Tree.Images.SetKeyName(1, "スライドボタンアイコン4.png");
			this.imglst_Tree.Images.SetKeyName(2, "スライドボタンアイコン1.png");
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(547, 338);
			this.panel2.TabIndex = 3;
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(547, 338);
			this.listView1.SmallImageList = this.imglst_FilePath;
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.VirtualMode = true;
			this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.onRetrieveVirtualItem);
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ファイルパス";
			this.columnHeader1.Width = 371;
			// 
			// imglst_FilePath
			// 
			this.imglst_FilePath.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imglst_FilePath.ImageSize = new System.Drawing.Size(16, 16);
			this.imglst_FilePath.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panelR_Center);
			this.panel1.Controls.Add(this.panelR_Top);
			this.panel1.Controls.Add(this.panelR_Bottom);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(547, 338);
			this.panel1.TabIndex = 2;
			// 
			// panelR_Center
			// 
			this.panelR_Center.Controls.Add(this.splitContainer2);
			this.panelR_Center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelR_Center.Location = new System.Drawing.Point(0, 24);
			this.panelR_Center.Name = "panelR_Center";
			this.panelR_Center.Size = new System.Drawing.Size(547, 285);
			this.panelR_Center.TabIndex = 14;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label5);
			this.splitContainer2.Panel1.Controls.Add(this.listView2);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.label4);
			this.splitContainer2.Panel2.Controls.Add(this.listView3);
			this.splitContainer2.Panel2.Controls.Add(this.label3);
			this.splitContainer2.Size = new System.Drawing.Size(547, 285);
			this.splitContainer2.SplitterDistance = 241;
			this.splitContainer2.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(38, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 14);
			this.label5.TabIndex = 13;
			this.label5.Text = "ENBをD&&Dで追加できます";
			this.label5.Visible = false;
			// 
			// listView2
			// 
			this.listView2.AllowDrop = true;
			this.listView2.CheckBoxes = true;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(0, 12);
			this.listView2.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(241, 273);
			this.listView2.SmallImageList = this.imglst_FilePath;
			this.listView2.TabIndex = 4;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
			this.listView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView2.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewR_MouseClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "ENBSeries";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new System.Drawing.Point(43, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(186, 14);
			this.label4.TabIndex = 12;
			this.label4.Text = "プリセットファイルをD&&Dで追加できます";
			this.label4.Visible = false;
			// 
			// listView3
			// 
			this.listView3.AllowDrop = true;
			this.listView3.CheckBoxes = true;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
			this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView3.GridLines = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView3.HideSelection = false;
			this.listView3.Location = new System.Drawing.Point(0, 12);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(302, 273);
			this.listView3.SmallImageList = this.imglst_FilePath;
			this.listView3.TabIndex = 8;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.View = System.Windows.Forms.View.Details;
			this.listView3.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
			this.listView3.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView3.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
			this.listView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewR_MouseClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "Presets";
			// 
			// panelR_Top
			// 
			this.panelR_Top.Controls.Add(this.label2);
			this.panelR_Top.Controls.Add(this.linkLabel_Nexus);
			this.panelR_Top.Controls.Add(this.linkLabel_ENB);
			this.panelR_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelR_Top.Location = new System.Drawing.Point(0, 0);
			this.panelR_Top.Name = "panelR_Top";
			this.panelR_Top.Size = new System.Drawing.Size(547, 24);
			this.panelR_Top.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "label2";
			// 
			// linkLabel_Nexus
			// 
			this.linkLabel_Nexus.ActiveLinkColor = System.Drawing.Color.DimGray;
			this.linkLabel_Nexus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_Nexus.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel_Nexus.Image")));
			this.linkLabel_Nexus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel_Nexus.LinkColor = System.Drawing.Color.DimGray;
			this.linkLabel_Nexus.Location = new System.Drawing.Point(465, 2);
			this.linkLabel_Nexus.Name = "linkLabel_Nexus";
			this.linkLabel_Nexus.Size = new System.Drawing.Size(79, 18);
			this.linkLabel_Nexus.TabIndex = 10;
			this.linkLabel_Nexus.TabStop = true;
			this.linkLabel_Nexus.Text = "Nexus Mods";
			this.linkLabel_Nexus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkLabel_Nexus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked_URLJump);
			// 
			// linkLabel_ENB
			// 
			this.linkLabel_ENB.ActiveLinkColor = System.Drawing.Color.DimGray;
			this.linkLabel_ENB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_ENB.Image = ((System.Drawing.Image)(resources.GetObject("linkLabel_ENB.Image")));
			this.linkLabel_ENB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel_ENB.LinkColor = System.Drawing.Color.DimGray;
			this.linkLabel_ENB.Location = new System.Drawing.Point(419, 2);
			this.linkLabel_ENB.Name = "linkLabel_ENB";
			this.linkLabel_ENB.Size = new System.Drawing.Size(40, 18);
			this.linkLabel_ENB.TabIndex = 11;
			this.linkLabel_ENB.TabStop = true;
			this.linkLabel_ENB.Text = "ENB";
			this.linkLabel_ENB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkLabel_ENB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked_URLJump);
			// 
			// panelR_Bottom
			// 
			this.panelR_Bottom.Controls.Add(this.button_ExtractArcive);
			this.panelR_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelR_Bottom.Location = new System.Drawing.Point(0, 309);
			this.panelR_Bottom.Name = "panelR_Bottom";
			this.panelR_Bottom.Size = new System.Drawing.Size(547, 29);
			this.panelR_Bottom.TabIndex = 13;
			// 
			// button_ExtractArcive
			// 
			this.button_ExtractArcive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_ExtractArcive.Location = new System.Drawing.Point(6, 3);
			this.button_ExtractArcive.Name = "button_ExtractArcive";
			this.button_ExtractArcive.Size = new System.Drawing.Size(538, 23);
			this.button_ExtractArcive.TabIndex = 7;
			this.button_ExtractArcive.Text = "チェックしたファイルを展開する";
			this.button_ExtractArcive.UseVisualStyleBackColor = true;
			this.button_ExtractArcive.Click += new System.EventHandler(this.onClick_ExtractArcive);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Uninstall,
            this.toolStripButton_Install,
            this.btnShowDialog,
            this.toolStripSeparator1,
            this.uiAddGameTitle,
            this.toolStripSeparator4,
            this.toolStripLabel_Language,
            this.toolStripComboBox1,
            this.toolStripSeparator2,
            this.toolStripButton_Reload,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(740, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton_Uninstall
			// 
			this.toolStripButton_Uninstall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_Uninstall.AutoToolTip = false;
			this.toolStripButton_Uninstall.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Uninstall.Image")));
			this.toolStripButton_Uninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Uninstall.Name = "toolStripButton_Uninstall";
			this.toolStripButton_Uninstall.Size = new System.Drawing.Size(98, 22);
			this.toolStripButton_Uninstall.Text = "アンインストール";
			this.toolStripButton_Uninstall.Click += new System.EventHandler(this.toolStripButton_Click_Uninstall);
			// 
			// toolStripButton_Install
			// 
			this.toolStripButton_Install.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_Install.AutoToolTip = false;
			this.toolStripButton_Install.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Install.Image")));
			this.toolStripButton_Install.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Install.Name = "toolStripButton_Install";
			this.toolStripButton_Install.Size = new System.Drawing.Size(80, 22);
			this.toolStripButton_Install.Text = "インストール";
			this.toolStripButton_Install.Click += new System.EventHandler(this.toolStripButton_Click_Install);
			// 
			// btnShowDialog
			// 
			this.btnShowDialog.AutoToolTip = false;
			this.btnShowDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnShowDialog.Image = ((System.Drawing.Image)(resources.GetObject("btnShowDialog.Image")));
			this.btnShowDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowDialog.Name = "btnShowDialog";
			this.btnShowDialog.Size = new System.Drawing.Size(23, 22);
			this.btnShowDialog.Text = "toolStripButton1";
			this.btnShowDialog.Click += new System.EventHandler(this.onClick_ShowDialog);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// uiAddGameTitle
			// 
			this.uiAddGameTitle.AutoToolTip = false;
			this.uiAddGameTitle.Image = ((System.Drawing.Image)(resources.GetObject("uiAddGameTitle.Image")));
			this.uiAddGameTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uiAddGameTitle.Name = "uiAddGameTitle";
			this.uiAddGameTitle.Size = new System.Drawing.Size(96, 22);
			this.uiAddGameTitle.Text = "ゲームを追加";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_Language
			// 
			this.toolStripLabel_Language.Name = "toolStripLabel_Language";
			this.toolStripLabel_Language.Size = new System.Drawing.Size(55, 22);
			this.toolStripLabel_Language.Text = "言語設定";
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
			this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_Reload
			// 
			this.toolStripButton_Reload.AutoToolTip = false;
			this.toolStripButton_Reload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Reload.Image")));
			this.toolStripButton_Reload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Reload.Name = "toolStripButton_Reload";
			this.toolStripButton_Reload.Size = new System.Drawing.Size(118, 22);
			this.toolStripButton_Reload.Text = "最新の情報に更新";
			this.toolStripButton_Reload.Click += new System.EventHandler(this.toolStripButton_Click_Reload);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 367);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(740, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(505, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripProgressBar1.Maximum = 100000;
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.RightToLeftLayout = true;
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// cms_Title
			// 
			this.cms_Title.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ゲームフォルダを開くToolStripMenuItem});
			this.cms_Title.Name = "contextMenuStrip1";
			this.cms_Title.Size = new System.Drawing.Size(165, 26);
			// 
			// ゲームフォルダを開くToolStripMenuItem
			// 
			this.ゲームフォルダを開くToolStripMenuItem.Name = "ゲームフォルダを開くToolStripMenuItem";
			this.ゲームフォルダを開くToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.ゲームフォルダを開くToolStripMenuItem.Text = "ゲームフォルダを開く";
			this.ゲームフォルダを開くToolStripMenuItem.Click += new System.EventHandler(this.ゲームフォルダを開くToolStripMenuItem_Click);
			// 
			// cms_Preset
			// 
			this.cms_Preset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.プリセットフォルダを開くToolStripMenuItem,
            this.プリセットを削除ToolStripMenuItem,
            this.toolStripSeparator3,
            this.共通enblocaliniでリセットするToolStripMenuItem});
			this.cms_Preset.Name = "contextMenuStrip2";
			this.cms_Preset.Size = new System.Drawing.Size(223, 76);
			// 
			// プリセットフォルダを開くToolStripMenuItem
			// 
			this.プリセットフォルダを開くToolStripMenuItem.Name = "プリセットフォルダを開くToolStripMenuItem";
			this.プリセットフォルダを開くToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
			this.プリセットフォルダを開くToolStripMenuItem.Text = "プリセットフォルダを開く";
			this.プリセットフォルダを開くToolStripMenuItem.Click += new System.EventHandler(this.プリセットフォルダを開くToolStripMenuItem_Click);
			// 
			// プリセットを削除ToolStripMenuItem
			// 
			this.プリセットを削除ToolStripMenuItem.Name = "プリセットを削除ToolStripMenuItem";
			this.プリセットを削除ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
			this.プリセットを削除ToolStripMenuItem.Text = "プリセットフォルダを削除";
			this.プリセットを削除ToolStripMenuItem.Click += new System.EventHandler(this.プリセットを削除ToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
			// 
			// 共通enblocaliniでリセットするToolStripMenuItem
			// 
			this.共通enblocaliniでリセットするToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wINDOWToolStripMenuItem,
            this.iNPUTToolStripMenuItem});
			this.共通enblocaliniでリセットするToolStripMenuItem.Name = "共通enblocaliniでリセットするToolStripMenuItem";
			this.共通enblocaliniでリセットするToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
			this.共通enblocaliniでリセットするToolStripMenuItem.Text = "共通enblocal.iniでリセットする";
			// 
			// wINDOWToolStripMenuItem
			// 
			this.wINDOWToolStripMenuItem.Name = "wINDOWToolStripMenuItem";
			this.wINDOWToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.wINDOWToolStripMenuItem.Text = "WINDOW";
			this.wINDOWToolStripMenuItem.Click += new System.EventHandler(this.wINDOWToolStripMenuItem_Click);
			// 
			// iNPUTToolStripMenuItem
			// 
			this.iNPUTToolStripMenuItem.Name = "iNPUTToolStripMenuItem";
			this.iNPUTToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
			this.iNPUTToolStripMenuItem.Text = "INPUT";
			this.iNPUTToolStripMenuItem.Click += new System.EventHandler(this.iNPUTToolStripMenuItem_Click);
			// 
			// panelDockCenter
			// 
			this.panelDockCenter.Controls.Add(this.splitContainer1);
			this.panelDockCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDockCenter.Location = new System.Drawing.Point(0, 25);
			this.panelDockCenter.Name = "panelDockCenter";
			this.panelDockCenter.Size = new System.Drawing.Size(740, 342);
			this.panelDockCenter.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 389);
			this.Controls.Add(this.panelDockCenter);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "ENBM";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panelR_Center.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panelR_Top.ResumeLayout(false);
			this.panelR_Top.PerformLayout();
			this.panelR_Bottom.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.cms_Title.ResumeLayout(false);
			this.cms_Preset.ResumeLayout(false);
			this.panelDockCenter.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton_Install;
		private System.Windows.Forms.ToolStripButton toolStripButton_Uninstall;
		private System.Windows.Forms.StatusStrip statusStrip1;
		public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		public System.Windows.Forms.ImageList imglst_Tree;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_Language;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripButton toolStripButton_Reload;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ContextMenuStrip cms_Title;
		private System.Windows.Forms.ToolStripMenuItem ゲームフォルダを開くToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cms_Preset;
		private System.Windows.Forms.ToolStripMenuItem プリセットフォルダを開くToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem プリセットを削除ToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panelDockCenter;
		private System.Windows.Forms.ToolStripButton btnShowDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button_ExtractArcive;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStripMenuItem 共通enblocaliniでリセットするToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wINDOWToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iNPUTToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripDropDownButton uiAddGameTitle;
		private System.Windows.Forms.LinkLabel linkLabel_Nexus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ImageList imglst_FilePath;
		private System.Windows.Forms.LinkLabel linkLabel_ENB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panelR_Top;
		private System.Windows.Forms.Panel panelR_Center;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panelR_Bottom;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.Panel panel2;
	}
}

