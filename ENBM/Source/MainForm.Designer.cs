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
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Uninstall = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Install = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_Language = new System.Windows.Forms.ToolStripLabel();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_Reload = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ゲームフォルダを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.プリセットフォルダを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.プリセットを削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.共通enblocaliniでリセットするToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wINDOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iNPUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.panel2.SuspendLayout();
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
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 4, 2);
			this.splitContainer1.Size = new System.Drawing.Size(674, 342);
			this.splitContainer1.SplitterDistance = 234;
			this.splitContainer1.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.FullRowSelect = true;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(4, 2);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowLines = false;
			this.treeView1.Size = new System.Drawing.Size(230, 338);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "ゲームの無料アイコン.png");
			this.imageList1.Images.SetKeyName(1, "スライドボタンアイコン4.png");
			this.imageList1.Images.SetKeyName(2, "スライドボタンアイコン1.png");
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.listView3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.listView2);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 338);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(4, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(420, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "選択したファイルを展開する";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(168, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "Presets";
			// 
			// listView3
			// 
			this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView3.CheckBoxes = true;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
			this.listView3.GridLines = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView3.HideSelection = false;
			this.listView3.Location = new System.Drawing.Point(170, 47);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(254, 259);
			this.listView3.TabIndex = 8;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.View = System.Windows.Forms.View.Details;
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "ENBSeries";
			// 
			// listView2
			// 
			this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listView2.CheckBoxes = true;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.listView2.GridLines = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(4, 47);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(160, 259);
			this.listView2.TabIndex = 4;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(143, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(156, 16);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "共通enblocal.iniを使用する";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
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
			this.listView1.Location = new System.Drawing.Point(0, 2);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(432, 338);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Visible = false;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ファイルパス";
			this.columnHeader1.Width = 371;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Uninstall,
            this.toolStripButton_Install,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel_Language,
            this.toolStripComboBox1,
            this.toolStripSeparator2,
            this.toolStripButton_Reload});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(674, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton_Uninstall
			// 
			this.toolStripButton_Uninstall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_Uninstall.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Uninstall.Image")));
			this.toolStripButton_Uninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Uninstall.Name = "toolStripButton_Uninstall";
			this.toolStripButton_Uninstall.Size = new System.Drawing.Size(98, 22);
			this.toolStripButton_Uninstall.Text = "アンインストール";
			this.toolStripButton_Uninstall.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton_Install
			// 
			this.toolStripButton_Install.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_Install.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Install.Image")));
			this.toolStripButton_Install.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Install.Name = "toolStripButton_Install";
			this.toolStripButton_Install.Size = new System.Drawing.Size(80, 22);
			this.toolStripButton_Install.Text = "インストール";
			this.toolStripButton_Install.Click += new System.EventHandler(this.toolStripButton_Install_Click);
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			this.toolStripButton_Reload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Reload.Image")));
			this.toolStripButton_Reload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Reload.Name = "toolStripButton_Reload";
			this.toolStripButton_Reload.Size = new System.Drawing.Size(118, 22);
			this.toolStripButton_Reload.Text = "最新の情報に更新";
			this.toolStripButton_Reload.Click += new System.EventHandler(this.toolStripButton_Reload_Click);
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
			this.statusStrip1.Size = new System.Drawing.Size(674, 22);
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
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(439, 17);
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
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ゲームフォルダを開くToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
			// 
			// ゲームフォルダを開くToolStripMenuItem
			// 
			this.ゲームフォルダを開くToolStripMenuItem.Name = "ゲームフォルダを開くToolStripMenuItem";
			this.ゲームフォルダを開くToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.ゲームフォルダを開くToolStripMenuItem.Text = "ゲームフォルダを開く";
			this.ゲームフォルダを開くToolStripMenuItem.Click += new System.EventHandler(this.ゲームフォルダを開くToolStripMenuItem_Click);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.プリセットフォルダを開くToolStripMenuItem,
            this.プリセットを削除ToolStripMenuItem,
            this.toolStripSeparator3,
            this.共通enblocaliniでリセットするToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(223, 76);
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
			// panel2
			// 
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(674, 342);
			this.panel2.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 389);
			this.Controls.Add(this.panel2);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_Language;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripButton toolStripButton_Reload;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ゲームフォルダを開くToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem プリセットフォルダを開くToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem プリセットを削除ToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStripMenuItem 共通enblocaliniでリセットするToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wINDOWToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iNPUTToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

