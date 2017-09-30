namespace Robot_Profiler
{
    partial class FormRobotProfiler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRobotProfiler));
            this.contextMenuStripDGVMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.graphPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogXMLFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRobotXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProfilerDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMainForm = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMainFormStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialogDBFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMainForm = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonGraphAll = new System.Windows.Forms.ToolStripButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.contextMenuStripDGVMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.statusStripMainForm.SuspendLayout();
            this.toolStripMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDGVMain
            // 
            this.contextMenuStripDGVMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphPointsToolStripMenuItem});
            this.contextMenuStripDGVMain.Name = "contextMenuStripDGVMain";
            this.contextMenuStripDGVMain.Size = new System.Drawing.Size(158, 26);
            this.contextMenuStripDGVMain.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripDGVMain_Opening);
            // 
            // graphPointsToolStripMenuItem
            // 
            this.graphPointsToolStripMenuItem.Name = "graphPointsToolStripMenuItem";
            this.graphPointsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.graphPointsToolStripMenuItem.Text = "Graph all points";
            this.graphPointsToolStripMenuItem.Click += new System.EventHandler(this.GraphPointsToolStripMenuItem_Click);
            // 
            // openFileDialogXMLFile
            // 
            this.openFileDialogXMLFile.FileName = "openFileDialog1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1025, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRobotXMLFileToolStripMenuItem,
            this.openProfilerDatabaseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openRobotXMLFileToolStripMenuItem
            // 
            this.openRobotXMLFileToolStripMenuItem.Name = "openRobotXMLFileToolStripMenuItem";
            this.openRobotXMLFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openRobotXMLFileToolStripMenuItem.Text = "Open Robot Output XML";
            this.openRobotXMLFileToolStripMenuItem.Click += new System.EventHandler(this.OpenRobotXMLFileToolStripMenuItem_Click);
            // 
            // openProfilerDatabaseToolStripMenuItem
            // 
            this.openProfilerDatabaseToolStripMenuItem.Name = "openProfilerDatabaseToolStripMenuItem";
            this.openProfilerDatabaseToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openProfilerDatabaseToolStripMenuItem.Text = "Open Profiler Database";
            this.openProfilerDatabaseToolStripMenuItem.Click += new System.EventHandler(this.OpenProfilerDatabaseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStripMainForm
            // 
            this.statusStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMainFormStatus});
            this.statusStripMainForm.Location = new System.Drawing.Point(0, 407);
            this.statusStripMainForm.Name = "statusStripMainForm";
            this.statusStripMainForm.Size = new System.Drawing.Size(1025, 22);
            this.statusStripMainForm.TabIndex = 4;
            this.statusStripMainForm.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMainFormStatus
            // 
            this.toolStripStatusLabelMainFormStatus.Name = "toolStripStatusLabelMainFormStatus";
            this.toolStripStatusLabelMainFormStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialogDBFile
            // 
            this.openFileDialogDBFile.FileName = "openFileDialog1";
            // 
            // toolStripMainForm
            // 
            this.toolStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch,
            this.toolStripButtonClearSearch,
            this.toolStripSeparator1,
            this.toolStripButtonGraphAll});
            this.toolStripMainForm.Location = new System.Drawing.Point(0, 24);
            this.toolStripMainForm.Name = "toolStripMainForm";
            this.toolStripMainForm.Size = new System.Drawing.Size(1025, 25);
            this.toolStripMainForm.TabIndex = 5;
            this.toolStripMainForm.Text = "toolStrip1";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToolStripTextBoxSearch_KeyPress);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search Table";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.ToolStripButtonSearch_Click);
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearSearch.Image")));
            this.toolStripButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSearch.Name = "toolStripButtonClearSearch";
            this.toolStripButtonClearSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearSearch.Text = "Clear Search";
            this.toolStripButtonClearSearch.Click += new System.EventHandler(this.ToolStripButtonClearSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonGraphAll
            // 
            this.toolStripButtonGraphAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGraphAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGraphAll.Image")));
            this.toolStripButtonGraphAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGraphAll.Name = "toolStripButtonGraphAll";
            this.toolStripButtonGraphAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonGraphAll.Text = "Graph all";
            this.toolStripButtonGraphAll.Click += new System.EventHandler(this.ToolStripButtonGraphAll_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMain.Location = new System.Drawing.Point(12, 52);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(21, 3);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1001, 352);
            this.tabControlMain.TabIndex = 6;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlMain_Selected);
            this.tabControlMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControlMain_MouseDoubleClick);
            // 
            // FormRobotProfiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 429);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolStripMainForm);
            this.Controls.Add(this.statusStripMainForm);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormRobotProfiler";
            this.Text = "Robot Profiler";
            this.contextMenuStripDGVMain.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMainForm.ResumeLayout(false);
            this.statusStripMainForm.PerformLayout();
            this.toolStripMainForm.ResumeLayout(false);
            this.toolStripMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialogXMLFile;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRobotXMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProfilerDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMainForm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMainFormStatus;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDBFile;
        private System.Windows.Forms.ToolStrip toolStripMainForm;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonGraphAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDGVMain;
        private System.Windows.Forms.ToolStripMenuItem graphPointsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
    }
}

