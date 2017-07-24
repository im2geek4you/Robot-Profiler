﻿namespace Robot_Profiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRobotProfiler));
            this.dataGridViewRobotKWs = new System.Windows.Forms.DataGridView();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRobotKWs)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.statusStripMainForm.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRobotKWs
            // 
            this.dataGridViewRobotKWs.AllowUserToAddRows = false;
            this.dataGridViewRobotKWs.AllowUserToDeleteRows = false;
            this.dataGridViewRobotKWs.AllowUserToResizeRows = false;
            this.dataGridViewRobotKWs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRobotKWs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRobotKWs.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewRobotKWs.Name = "dataGridViewRobotKWs";
            this.dataGridViewRobotKWs.RowHeadersVisible = false;
            this.dataGridViewRobotKWs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRobotKWs.Size = new System.Drawing.Size(1000, 352);
            this.dataGridViewRobotKWs.TabIndex = 2;
            this.dataGridViewRobotKWs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRobotKWs_CellFormatting);
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
            this.openRobotXMLFileToolStripMenuItem.Click += new System.EventHandler(this.openRobotXMLFileToolStripMenuItem_Click);
            // 
            // openProfilerDatabaseToolStripMenuItem
            // 
            this.openProfilerDatabaseToolStripMenuItem.Name = "openProfilerDatabaseToolStripMenuItem";
            this.openProfilerDatabaseToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openProfilerDatabaseToolStripMenuItem.Text = "Open Profiler Database";
            this.openProfilerDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openProfilerDatabaseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch,
            this.toolStripButtonClearSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1025, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search Table";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearSearch.Image")));
            this.toolStripButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSearch.Name = "toolStripButtonClearSearch";
            this.toolStripButtonClearSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearSearch.Text = "Clear Search";
            this.toolStripButtonClearSearch.Click += new System.EventHandler(this.toolStripButtonClearSearch_Click);
            // 
            // FormRobotProfiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 429);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStripMainForm);
            this.Controls.Add(this.dataGridViewRobotKWs);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormRobotProfiler";
            this.Text = "Robot Profiler";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRobotKWs)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMainForm.ResumeLayout(false);
            this.statusStripMainForm.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewRobotKWs;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
    }
}

