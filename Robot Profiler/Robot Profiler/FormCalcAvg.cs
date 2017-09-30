using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Profiler
{
    public partial class FormCalcAvg : Form
    {
        private String Filename;
        DataTable stats;

        public FormCalcAvg()
        {
            InitializeComponent();
        }
        public FormCalcAvg(String filename, DataGridView dgv)
        {
            InitializeComponent();
            Filename = filename;
            backgroundWorkerCalcAverageDuration.RunWorkerAsync(dgv);
        }

        private void backgroundWorkerCalcAverageDuration_DoWork(object sender, DoWorkEventArgs e)
        {
            DataGridView dataGridViewRobotKWs = (DataGridView)e.Argument;
            ProfileDB db = new ProfileDB(Filename, false);
            db.CreateTableRobotStats();
            stats = db.RetrieveTableDistinctKWs();
            stats.Columns.Add("Avg. Duration");
            stats.Columns.Add("Total Duration");
            foreach (DataRow row in stats.Rows)
            {                 
                List<TimeSpan> durations = null;
                //get all durations for each Name(kw, test or suite)
                durations = db.RetrieveDuration(row["Name"].ToString());
                //calculate average duration and set column Avg. Duration with that value
                double doubleAverageTicks = durations.Average(timeSpan => timeSpan.Ticks);
                long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
                //calculate total duration and set column Total Duration with that value
                double doubleTotalTicks = durations.Sum(timeSpan => timeSpan.Ticks);
                long longTotalTicks = Convert.ToInt64(doubleTotalTicks);

                row["Avg. Duration"] = new TimeSpan(longAverageTicks);
                row["Total Duration"] = new TimeSpan(longTotalTicks);

                if (stats.Rows.IndexOf(row) % 10 == 0)
                {
                    backgroundWorkerCalcAverageDuration.ReportProgress((int)((float)stats.Rows.IndexOf(row) / (float)stats.Rows.Count * 100));
                }
            }
        }



        private void backgroundWorkerCalcAverageDuration_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarCalcAvgDuration.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerCalcAverageDuration_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelCalcAvgStatus.Text = "Avg. Duration calculation complete.";
            //save data
            ProfileDB db = new ProfileDB(Filename, false);
            db.SaveStats(stats);
            FormRobotProfiler.table = db.RetrieveTableStats();
            progressBarCalcAvgDuration.Value = progressBarCalcAvgDuration.Maximum;
            pictureBoxCalcAvgDuration.Image = null;
            Thread.Sleep(1000);
            this.Close();
        }

        private void buttonAvgCalcCancel_Click(object sender, EventArgs e)
        {
            backgroundWorkerCalcAverageDuration.CancelAsync();
            this.Close();
        }
    }
}
