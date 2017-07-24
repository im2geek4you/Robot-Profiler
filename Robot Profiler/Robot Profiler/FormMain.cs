using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Robot_Profiler
{
    public partial class FormRobotProfiler : Form
    {
        public static DataTable table = null;

        public FormRobotProfiler()
        {
            InitializeComponent();
        }


        private void openRobotXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogXMLFile.InitialDirectory = ".";
            openFileDialogXMLFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialogXMLFile.FilterIndex = 1;
            openFileDialogXMLFile.RestoreDirectory = true;
            openFileDialogXMLFile.FileName = String.Empty;

            if (openFileDialogXMLFile.ShowDialog() == DialogResult.OK)
            {
                dataGridViewRobotKWs.DataSource = null;
                dataGridViewRobotKWs.Rows.Clear();
                toolStripStatusLabelMainFormStatus.Text = "Robot output file loaded: " + openFileDialogXMLFile.FileName;

                using (Form loading = new LoadingXML(openFileDialogXMLFile.FileName))
                {
                    loading.StartPosition = FormStartPosition.CenterParent;
                    loading.ShowDialog();
                }
                table.Columns.Add("Avg. Duration");
                dataGridViewRobotKWs.DataSource = table;
                dataGridViewRobotKWs.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //launch Avg duration calculation thread
                using (Form formCalcAvg = new FormCalcAvg(Path.GetFileNameWithoutExtension(openFileDialogXMLFile.FileName) + ".db", dataGridViewRobotKWs))
                {
                    formCalcAvg.StartPosition = FormStartPosition.CenterParent;
                    formCalcAvg.ShowDialog();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openProfilerDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogDBFile.InitialDirectory = ".";
            openFileDialogDBFile.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            openFileDialogDBFile.FilterIndex = 1;
            openFileDialogDBFile.RestoreDirectory = true;
            openFileDialogDBFile.FileName = String.Empty;

            if (openFileDialogDBFile.ShowDialog() == DialogResult.OK)
            {
                ProfileDB db = new ProfileDB(openFileDialogDBFile.FileName, false);
                table = db.RetrieveTable("robot");
                dataGridViewRobotKWs.DataSource = null;
                dataGridViewRobotKWs.Rows.Clear();
                toolStripStatusLabelMainFormStatus.Text = "Database file loaded: " + openFileDialogDBFile.FileName;
                table.Columns.Add("Avg. Duration");
                dataGridViewRobotKWs.DataSource = table;
                dataGridViewRobotKWs.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //launch Avg duration calculation thread
                using (Form formCalcAvg = new FormCalcAvg(openFileDialogDBFile.FileName, dataGridViewRobotKWs))
                {
                    formCalcAvg.StartPosition = FormStartPosition.CenterParent;
                    formCalcAvg.ShowDialog();
                }

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Robot Profiler v0.0.0.1\nCarlos Santos");
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            dataGridViewRobotKWs.CurrentCell = null;
            foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
            {
                foreach(DataGridViewCell cell in line.Cells)
                {
                    if( line.Index !=0)
                    {
                        if (cell.Value.ToString().ToLower().Contains(toolStripTextBoxSearch.Text)){
                            found = true;
                        }
                    }
                }
                if (found)
                {
                    dataGridViewRobotKWs.Rows[line.Index].Visible = true;
                }
                else
                {
                        dataGridViewRobotKWs.Rows[line.Index].Visible = false;
                }
                found = false;
            }
        }

        private void toolStripButtonClearSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
            {
                    dataGridViewRobotKWs.Rows[line.Index].Visible = true;
            }
        }

        private void dataGridViewRobotKWs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            switch (dataGridViewRobotKWs.Rows[e.RowIndex].Cells["Type"].Value.ToString())
            {
                case "kw":
                    e.CellStyle.BackColor = Color.LightSkyBlue;
                    break;
                case "test":
                    e.CellStyle.BackColor = Color.LightYellow;
                    break;
                case "suite":
                    e.CellStyle.BackColor = Color.LightSeaGreen;
                    break;
                default:
                    break;
            }
        }
    }
}
