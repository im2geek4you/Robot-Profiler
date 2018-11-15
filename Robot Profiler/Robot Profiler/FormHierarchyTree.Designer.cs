namespace Robot_Profiler
{
    partial class FormHierarchyTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHierarchyTree));
            this.treeViewKw = new System.Windows.Forms.TreeView();
            this.imageListType = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripTreeNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.graphAllPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTreeNodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewKw
            // 
            this.treeViewKw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewKw.ContextMenuStrip = this.contextMenuStripTreeNodes;
            this.treeViewKw.ImageIndex = 0;
            this.treeViewKw.ImageList = this.imageListType;
            this.treeViewKw.Location = new System.Drawing.Point(12, 12);
            this.treeViewKw.Name = "treeViewKw";
            this.treeViewKw.SelectedImageIndex = 0;
            this.treeViewKw.Size = new System.Drawing.Size(694, 295);
            this.treeViewKw.TabIndex = 0;
            // 
            // imageListType
            // 
            this.imageListType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListType.ImageStream")));
            this.imageListType.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListType.Images.SetKeyName(0, "Setup_Green.png");
            this.imageListType.Images.SetKeyName(1, "Setup_Red.png");
            this.imageListType.Images.SetKeyName(2, "Suite_Green.png");
            this.imageListType.Images.SetKeyName(3, "Suite_Red.png");
            this.imageListType.Images.SetKeyName(4, "Test_Green.png");
            this.imageListType.Images.SetKeyName(5, "Test_Red.png");
            this.imageListType.Images.SetKeyName(6, "Keyword_Green.png");
            this.imageListType.Images.SetKeyName(7, "Keyword_Red.png");
            this.imageListType.Images.SetKeyName(8, "Teardown_Green.png");
            this.imageListType.Images.SetKeyName(9, "Teardown_Red.png");
            this.imageListType.Images.SetKeyName(10, "Pass.png");
            this.imageListType.Images.SetKeyName(11, "Fail.png");
            // 
            // contextMenuStripTreeNodes
            // 
            this.contextMenuStripTreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphAllPointsToolStripMenuItem});
            this.contextMenuStripTreeNodes.Name = "contextMenuStripTreeNodes";
            this.contextMenuStripTreeNodes.Size = new System.Drawing.Size(181, 48);
            // 
            // graphAllPointsToolStripMenuItem
            // 
            this.graphAllPointsToolStripMenuItem.Name = "graphAllPointsToolStripMenuItem";
            this.graphAllPointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.graphAllPointsToolStripMenuItem.Text = "Graph all points";
            this.graphAllPointsToolStripMenuItem.Click += new System.EventHandler(this.graphAllPointsToolStripMenuItem_Click);
            // 
            // FormHierarchyTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 319);
            this.Controls.Add(this.treeViewKw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHierarchyTree";
            this.Text = "Hierarchy Tree";
            this.Shown += new System.EventHandler(this.FormHierarchyTree_Shown);
            this.contextMenuStripTreeNodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewKw;
        private System.Windows.Forms.ImageList imageListType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeNodes;
        private System.Windows.Forms.ToolStripMenuItem graphAllPointsToolStripMenuItem;
    }
}