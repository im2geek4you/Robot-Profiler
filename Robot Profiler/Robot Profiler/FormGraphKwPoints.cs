using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Robot_Profiler
{
    public partial class FormGraphKwPoints : Form
    {
        private String DataFile;
        private String KwName;

        public FormGraphKwPoints()
        {
            InitializeComponent();
        }
        public FormGraphKwPoints(String datafile, String kwName)
        {
            InitializeComponent();
            DataFile = datafile;
            KwName = kwName;
            this.Text = "Keyword:" + kwName + " - " + datafile;
        }

        private void FormGraphKwPoints_Shown(object sender, EventArgs e)
        {
            List<TimeSpan> Durations; 
            ProfileDB db = new ProfileDB(DataFile, false);
            Durations = db.RetrieveDuration(KwName);

            chartGraphKwPoints.Series.Clear();

            Series S = chartGraphKwPoints.Series.Add(KwName);
            S.ChartType = SeriesChartType.Line;
            chartGraphKwPoints.ChartAreas[0].AxisY.LabelStyle.Format = "{}ms";

            S.LabelAngle = 45;

            for (int i = 0; i < Durations.Count; i++)
            {
                chartGraphKwPoints.Series[KwName].Points.AddXY(i, Durations[i].TotalMilliseconds);
            }

        }

        private void toolStripButtonXGrid_Click(object sender, EventArgs e)
        {
            if (chartGraphKwPoints.ChartAreas[0].AxisX.MajorGrid.LineWidth == 1)
            {
                chartGraphKwPoints.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            }
            else
            {
                chartGraphKwPoints.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;
            }
        }

        private void toolStripButtonYGrid_Click(object sender, EventArgs e)
        {
            if (chartGraphKwPoints.ChartAreas[0].AxisY.MajorGrid.LineWidth == 1)
            {
                chartGraphKwPoints.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            }
            else
            {
                chartGraphKwPoints.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
            }
        }

        private void toolStripButtonPassOnly_Click(object sender, EventArgs e)
        {
            List<TimeSpan> Durations;
            ProfileDB db = new ProfileDB(DataFile, false);
            Durations = db.RetrieveDuration(KwName, "PASS");
            String seriesName = KwName + " (PASS)";

            if (chartGraphKwPoints.Series.IndexOf(seriesName) == -1) {
                Series S = chartGraphKwPoints.Series.Add(seriesName);
                S.ChartType = SeriesChartType.Point;
                S.Color = System.Drawing.Color.Green;
                chartGraphKwPoints.ChartAreas[0].AxisY.LabelStyle.Format = "{}ms";
                
                S.LabelAngle = 45;

                for (int i = 0; i < Durations.Count; i++)
                {
                    if (Durations[i] != TimeSpan.Zero)
                    {
                        chartGraphKwPoints.Series[seriesName].Points.AddXY(i, Durations[i].TotalMilliseconds);
                    }
                }
                
            }
            else
            {
                chartGraphKwPoints.Series.RemoveAt(chartGraphKwPoints.Series.IndexOf(seriesName));
            }
            
        }

        private void toolStripButtonFailOnly_Click(object sender, EventArgs e)
        {
            List<TimeSpan> Durations;
            ProfileDB db = new ProfileDB(DataFile, false);
            Durations = db.RetrieveDuration(KwName, "FAIL");
            String seriesName = KwName + " (FAIL)";

            if (chartGraphKwPoints.Series.IndexOf(seriesName) == -1)
            {
                Series S = chartGraphKwPoints.Series.Add(seriesName);
                S.ChartType = SeriesChartType.Point;
                S.Color = System.Drawing.Color.Red;
                chartGraphKwPoints.ChartAreas[0].AxisY.LabelStyle.Format = "{}ms";

                S.LabelAngle = 45;

                for (int i = 0; i < Durations.Count; i++)
                {
                    if (Durations[i] != TimeSpan.Zero)
                    {
                        chartGraphKwPoints.Series[seriesName].Points.AddXY(i, Durations[i].TotalMilliseconds);
                    }
                }

            }
            else
            {
                chartGraphKwPoints.Series.RemoveAt(chartGraphKwPoints.Series.IndexOf(seriesName));
            }
        }
    }
}
