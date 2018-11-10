namespace Robot_Profiler
{
    partial class FormGraphKwPoints
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphKwPoints));
            this.chartGraphKwPoints = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonXGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonYGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPassOnly = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFailOnly = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraphKwPoints)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartGraphKwPoints
            // 
            this.chartGraphKwPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartGraphKwPoints.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartGraphKwPoints.Legends.Add(legend2);
            this.chartGraphKwPoints.Location = new System.Drawing.Point(12, 28);
            this.chartGraphKwPoints.Name = "chartGraphKwPoints";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartGraphKwPoints.Series.Add(series2);
            this.chartGraphKwPoints.Size = new System.Drawing.Size(756, 356);
            this.chartGraphKwPoints.TabIndex = 0;
            this.chartGraphKwPoints.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonXGrid,
            this.toolStripButtonYGrid,
            this.toolStripSeparator1,
            this.toolStripButtonPassOnly,
            this.toolStripButtonFailOnly});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonXGrid
            // 
            this.toolStripButtonXGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonXGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXGrid.Image")));
            this.toolStripButtonXGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXGrid.Name = "toolStripButtonXGrid";
            this.toolStripButtonXGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonXGrid.Text = "X Grid";
            this.toolStripButtonXGrid.Click += new System.EventHandler(this.toolStripButtonXGrid_Click);
            // 
            // toolStripButtonYGrid
            // 
            this.toolStripButtonYGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonYGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonYGrid.Image")));
            this.toolStripButtonYGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonYGrid.Name = "toolStripButtonYGrid";
            this.toolStripButtonYGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonYGrid.Text = "Y Grid";
            this.toolStripButtonYGrid.Click += new System.EventHandler(this.toolStripButtonYGrid_Click);
            // 
            // toolStripButtonPassOnly
            // 
            this.toolStripButtonPassOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPassOnly.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPassOnly.Image")));
            this.toolStripButtonPassOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPassOnly.Name = "toolStripButtonPassOnly";
            this.toolStripButtonPassOnly.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPassOnly.ToolTipText = "Overlay PASS results";
            this.toolStripButtonPassOnly.Click += new System.EventHandler(this.toolStripButtonPassOnly_Click);
            // 
            // toolStripButtonFailOnly
            // 
            this.toolStripButtonFailOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFailOnly.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFailOnly.Image")));
            this.toolStripButtonFailOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFailOnly.Name = "toolStripButtonFailOnly";
            this.toolStripButtonFailOnly.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFailOnly.ToolTipText = "Overlay FAIL results";
            this.toolStripButtonFailOnly.Click += new System.EventHandler(this.toolStripButtonFailOnly_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FormGraphKwPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 392);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chartGraphKwPoints);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGraphKwPoints";
            this.Text = "FormGraphKwPoints";
            this.Shown += new System.EventHandler(this.FormGraphKwPoints_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chartGraphKwPoints)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraphKwPoints;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonXGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonYGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonPassOnly;
        private System.Windows.Forms.ToolStripButton toolStripButtonFailOnly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}