using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Robot_Profiler
{
    public partial class FormGraphAll : Form
    {
        private DataGridView DGV;

        public FormGraphAll()
        {
            InitializeComponent();
        }

        public FormGraphAll(DataGridView dgv)
        {
            InitializeComponent();
            DGV = dgv;
        }

        private void FormGraphAll_Shown(object sender, EventArgs e)
        {
            chartGraphAll.Series.Clear();

            Series S = chartGraphAll.Series.Add("Keywords");
            S.ChartType = SeriesChartType.Line;
           
            S.LabelAngle = 45;

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (DGV[0,i].Value.ToString() == "kw")
                {
                    chartGraphAll.Series["Keywords"].Points.AddXY(DGV[1, i].Value.ToString(), DGV[2, i].Value);
                    
                }
            }

            this.chartGraphAll.GetToolTipText += this.chartGraphAll_GetToolTipText;

        }

        private void chartGraphAll_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Check selected chart element and set tooltip text for it
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    e.Text = string.Format("X:\t{0}\nY:\t{1}", dataPoint.AxisLabel, dataPoint.YValues[0]);
                    break;
            }
        }
    }
}
