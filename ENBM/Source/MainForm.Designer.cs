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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Uninstall = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Install = new System.Windows.Forms.ToolStripButton();
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
			this.splitContainer1.Size = new System.Drawing.Size(674, 309);
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
			this.treeView1.Size = new System.Drawing.Size(230, 305);
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
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 305);
			this.panel1.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(3, 6);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(156, 16);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "共通enblocal.iniを使用する";
			this.checkBox1.UseVisualStyleBackColor = true;
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
			this.listView1.Size = new System.Drawing.Size(432, 305);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 334);
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
            this.プリセットを削除ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(186, 48);
			// 
			// プリセットフォルダを開くToolStripMenuItem
			// 
			this.プリセットフォルダを開くToolStripMenuItem.Name = "プリセットフォルダを開くToolStripMenuItem";
			this.プリセットフォルダを開くToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.プリセットフォルダを開くToolStripMenuItem.Text = "プリセットフォルダを開く";
			this.プリセットフォルダを開くToolStripMenuItem.Click += new System.EventHandler(this.プリセットフォルダを開くToolStripMenuItem_Click);
			// 
			// プリセットを削除ToolStripMenuItem
			// 
			this.プリセットを削除ToolStripMenuItem.Name = "プリセットを削除ToolStripMenuItem";
			this.プリセットを削除ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.プリセットを削除ToolStripMenuItem.Text = "プリセットフォルダを削除";
			this.プリセットを削除ToolStripMenuItem.Click += new System.EventHandler(this.プリセットを削除ToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.splitContainer1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(674, 309);
			this.panel2.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 356);
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
	}
}

