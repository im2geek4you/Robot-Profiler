namespace Robot_Profiler
{
    partial class FormCalcAvg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalcAvg));
            this.pictureBoxCalcAvgDuration = new System.Windows.Forms.PictureBox();
            this.labelCalcAvgStatus = new System.Windows.Forms.Label();
            this.progressBarCalcAvgDuration = new System.Windows.Forms.ProgressBar();
            this.buttonAvgCalcCancel = new System.Windows.Forms.Button();
            this.backgroundWorkerCalcAverageDuration = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalcAvgDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCalcAvgDuration
            // 
            this.pictureBoxCalcAvgDuration.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCalcAvgDuration.Image")));
            this.pictureBoxCalcAvgDuration.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCalcAvgDuration.Name = "pictureBoxCalcAvgDuration";
            this.pictureBoxCalcAvgDuration.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxCalcAvgDuration.TabIndex = 0;
            this.pictureBoxCalcAvgDuration.TabStop = false;
            // 
            // labelCalcAvgStatus
            // 
            this.labelCalcAvgStatus.AutoSize = true;
            this.labelCalcAvgStatus.Location = new System.Drawing.Point(82, 12);
            this.labelCalcAvgStatus.Name = "labelCalcAvgStatus";
            this.labelCalcAvgStatus.Size = new System.Drawing.Size(191, 13);
            this.labelCalcAvgStatus.TabIndex = 1;
            this.labelCalcAvgStatus.Text = "Calculating Avg duration. Please wait...";
            // 
            // progressBarCalcAvgDuration
            // 
            this.progressBarCalcAvgDuration.Location = new System.Drawing.Point(85, 37);
            this.progressBarCalcAvgDuration.Name = "progressBarCalcAvgDuration";
            this.progressBarCalcAvgDuration.Size = new System.Drawing.Size(240, 10);
            this.progressBarCalcAvgDuration.TabIndex = 2;
            // 
            // buttonAvgCalcCancel
            // 
            this.buttonAvgCalcCancel.Location = new System.Drawing.Point(250, 53);
            this.buttonAvgCalcCancel.Name = "buttonAvgCalcCancel";
            this.buttonAvgCalcCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonAvgCalcCancel.TabIndex = 3;
            this.buttonAvgCalcCancel.Text = "Cancel";
            this.buttonAvgCalcCancel.UseVisualStyleBackColor = true;
            this.buttonAvgCalcCancel.Click += new System.EventHandler(this.buttonAvgCalcCancel_Click);
            // 
            // backgroundWorkerCalcAverageDuration
            // 
            this.backgroundWorkerCalcAverageDuration.WorkerReportsProgress = true;
            this.backgroundWorkerCalcAverageDuration.WorkerSupportsCancellation = true;
            this.backgroundWorkerCalcAverageDuration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCalcAverageDuration_DoWork);
            this.backgroundWorkerCalcAverageDuration.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCalcAverageDuration_ProgressChanged);
            this.backgroundWorkerCalcAverageDuration.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCalcAverageDuration_RunWorkerCompleted);
            // 
            // FormCalcAvg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 86);
            this.Controls.Add(this.buttonAvgCalcCancel);
            this.Controls.Add(this.progressBarCalcAvgDuration);
            this.Controls.Add(this.labelCalcAvgStatus);
            this.Controls.Add(this.pictureBoxCalcAvgDuration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCalcAvg";
            this.ShowInTaskbar = false;
            this.Text = "FormCalcAvg";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalcAvgDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCalcAvgDuration;
        private System.Windows.Forms.Label labelCalcAvgStatus;
        private System.Windows.Forms.ProgressBar progressBarCalcAvgDuration;
        private System.Windows.Forms.Button buttonAvgCalcCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCalcAverageDuration;
    }
}