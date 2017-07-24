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
            foreach (DataGridViewRow row in dataGridViewRobotKWs.Rows)
            {                 
                List<TimeSpan> durations = null;
                ProfileDB db = new ProfileDB(Filename, false);
                //get all durations for each Name(kw, test or suite)
                durations = db.RetrieveDuration("robot", row.Cells["Name"].Value.ToString());
                //calculate average duration and set column Avg. Duration with that value
                double doubleAverageTicks = durations.Average(timeSpan => timeSpan.Ticks);
                long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

                row.Cells["Avg. Duration"].Value = new TimeSpan(longAverageTicks);
                if (row.Index % 10 == 0)
                {
                    backgroundWorkerCalcAverageDuration.ReportProgress((int)((float)row.Index / (float)dataGridViewRobotKWs.Rows.Count * 100));
                }
            }
        }



        private void backgroundWorkerCalcAverageDuration_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarCalcAvgDuration.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerCalcAverageDuration_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarCalcAvgDuration.Value = progressBarCalcAvgDuration.Maximum;
            labelCalcAvgStatus.Text = "Avg. Duration calculation complete.";
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
