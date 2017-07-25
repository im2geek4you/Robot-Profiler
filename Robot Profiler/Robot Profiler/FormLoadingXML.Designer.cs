namespace Robot_Profiler
{
    partial class FormLoadingXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadingXML));
            this.labelWorkDescription = new System.Windows.Forms.Label();
            this.backgroundWorkerXML2DB = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxXMLWorker = new System.Windows.Forms.PictureBox();
            this.buttonXMLWorkerCancel = new System.Windows.Forms.Button();
            this.progressBarXMLWorker = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMLWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWorkDescription
            // 
            this.labelWorkDescription.AutoSize = true;
            this.labelWorkDescription.Location = new System.Drawing.Point(82, 12);
            this.labelWorkDescription.Name = "labelWorkDescription";
            this.labelWorkDescription.Size = new System.Drawing.Size(79, 13);
            this.labelWorkDescription.TabIndex = 1;
            this.labelWorkDescription.Text = "Loading XML...";
            // 
            // backgroundWorkerXML2DB
            // 
            this.backgroundWorkerXML2DB.WorkerReportsProgress = true;
            this.backgroundWorkerXML2DB.WorkerSupportsCancellation = true;
            this.backgroundWorkerXML2DB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerXML2DB_DoWork);
            this.backgroundWorkerXML2DB.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerXML2DB_ProgressChanged);
            this.backgroundWorkerXML2DB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerXML2DB_RunWorkerCompleted);
            // 
            // pictureBoxXMLWorker
            // 
            this.pictureBoxXMLWorker.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxXMLWorker.Image")));
            this.pictureBoxXMLWorker.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxXMLWorker.Name = "pictureBoxXMLWorker";
            this.pictureBoxXMLWorker.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxXMLWorker.TabIndex = 2;
            this.pictureBoxXMLWorker.TabStop = false;
            // 
            // buttonXMLWorkerCancel
            // 
            this.buttonXMLWorkerCancel.Location = new System.Drawing.Point(250, 53);
            this.buttonXMLWorkerCancel.Name = "buttonXMLWorkerCancel";
            this.buttonXMLWorkerCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonXMLWorkerCancel.TabIndex = 3;
            this.buttonXMLWorkerCancel.Text = "Cancel";
            this.buttonXMLWorkerCancel.UseVisualStyleBackColor = true;
            this.buttonXMLWorkerCancel.Click += new System.EventHandler(this.buttonXMLWorkerCancel_Click);
            // 
            // progressBarXMLWorker
            // 
            this.progressBarXMLWorker.Location = new System.Drawing.Point(85, 37);
            this.progressBarXMLWorker.Name = "progressBarXMLWorker";
            this.progressBarXMLWorker.Size = new System.Drawing.Size(240, 10);
            this.progressBarXMLWorker.TabIndex = 4;
            // 
            // LoadingXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 86);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarXMLWorker);
            this.Controls.Add(this.buttonXMLWorkerCancel);
            this.Controls.Add(this.pictureBoxXMLWorker);
            this.Controls.Add(this.labelWorkDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingXML";
            this.ShowInTaskbar = false;
            this.Text = "LoadingXML";
            this.Shown += new System.EventHandler(this.LoadingXML_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXMLWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWorkDescription;
        private System.ComponentModel.BackgroundWorker backgroundWorkerXML2DB;
        private System.Windows.Forms.PictureBox pictureBoxXMLWorker;
        private System.Windows.Forms.Button buttonXMLWorkerCancel;
        private System.Windows.Forms.ProgressBar progressBarXMLWorker;
    }
}