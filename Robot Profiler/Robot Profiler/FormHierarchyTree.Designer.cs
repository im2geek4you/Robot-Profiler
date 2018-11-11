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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHierarchyTree));
            this.treeViewKw = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewKw
            // 
            this.treeViewKw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewKw.Location = new System.Drawing.Point(12, 12);
            this.treeViewKw.Name = "treeViewKw";
            this.treeViewKw.Size = new System.Drawing.Size(694, 295);
            this.treeViewKw.TabIndex = 0;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewKw;
    }
}