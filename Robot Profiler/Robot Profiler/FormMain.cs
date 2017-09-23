using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Robot_Profiler
{
    public partial class FormRobotProfiler : Form
    {
        public static DataTable table = null;
        private String datafile;

        public FormRobotProfiler()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(FormRobotProfiler_DragEnter);
            this.DragDrop += new DragEventHandler(FormRobotProfiler_DragDrop);
        }


        private void OpenRobotXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogXMLFile.InitialDirectory = ".";
            openFileDialogXMLFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialogXMLFile.FilterIndex = 1;
            openFileDialogXMLFile.RestoreDirectory = true;
            openFileDialogXMLFile.FileName = String.Empty;

            if (openFileDialogXMLFile.ShowDialog() == DialogResult.OK)
            {
                OpenRobotXMLFile(openFileDialogXMLFile.FileName);
            }
        }

        private void OpenRobotXMLFile(string filename)
        {
            datafile = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".db";
            dataGridViewRobotKWs.DataSource = null;
            dataGridViewRobotKWs.Rows.Clear();
            toolStripStatusLabelMainFormStatus.Text = "Robot output file loaded: " + filename;

            //launch XML processing thread
            using (Form loading = new FormLoadingXML(filename))
            {
                loading.StartPosition = FormStartPosition.CenterParent;
                loading.ShowDialog();
            }

            //launch Avg duration calculation thread
            using (Form formCalcAvg = new FormCalcAvg(datafile, dataGridViewRobotKWs))
            {
                formCalcAvg.StartPosition = FormStartPosition.CenterParent;
                formCalcAvg.ShowDialog();
            }
            dataGridViewRobotKWs.DataSource = table;
            dataGridViewRobotKWs.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenProfilerDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogDBFile.InitialDirectory = ".";
            openFileDialogDBFile.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
            openFileDialogDBFile.FilterIndex = 1;
            openFileDialogDBFile.RestoreDirectory = true;
            openFileDialogDBFile.FileName = String.Empty;

            if (openFileDialogDBFile.ShowDialog() == DialogResult.OK)
            {
                OpenRobotDBFile(openFileDialogDBFile.FileName);
            }
        }

        private void OpenRobotDBFile(string filename)
        {
            datafile = filename;
            ProfileDB db = new ProfileDB(filename, false);
            dataGridViewRobotKWs.DataSource = null;
            dataGridViewRobotKWs.Rows.Clear();
            toolStripStatusLabelMainFormStatus.Text = "Database file loaded: " + filename;
            dataGridViewRobotKWs.DataSource = db.RetrieveTableStats();
            dataGridViewRobotKWs.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Robot Profiler v0.0.0.4\nCarlos Santos");
        }

        private void ToolStripButtonSearch_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            dataGridViewRobotKWs.CurrentCell = null;
            foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
            {
                foreach(DataGridViewCell cell in line.Cells)
                {
                    if( line.Index !=0)
                    {
                        if (cell.Value.ToString().ToLower().Contains(toolStripTextBoxSearch.Text.ToLower())){
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

        private void ToolStripButtonClearSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
            {
                    dataGridViewRobotKWs.Rows[line.Index].Visible = true;
            }
        }

        private void DataGridViewRobotKWs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void ToolStripTextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)13))
            {
                ToolStripButtonSearch_Click(sender, e);
            }
        }

        private void ToolStripButtonGraphAll_Click(object sender, EventArgs e)
        {
            Form formGraphAll = new FormGraphAll(dataGridViewRobotKWs)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            formGraphAll.Show();
        }

        private void ContextMenuStripDGVMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridViewRobotKWs.SelectedRows.Count != 1)
            {
                contextMenuStripDGVMain.Items[0].Enabled = false;
            }
            else
            {
                contextMenuStripDGVMain.Items[0].Enabled = true;
            }
        }

        private void GraphPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach ( DataGridViewRow row in dataGridViewRobotKWs.SelectedRows)
            {
                Form formGraphKwPoints = new FormGraphKwPoints(datafile, row.Cells["Name"].Value.ToString())
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                formGraphKwPoints.Show();               
            }
            
        }

        void FormRobotProfiler_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void FormRobotProfiler_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                foreach (string file in files)
                {
                    if (file.ToLower().EndsWith(".xml"))
                    {
                        OpenRobotXMLFile(file);
                    }
                    if (file.ToLower().EndsWith(".db"))
                    {
                        OpenRobotDBFile(file);
                    }
                }
            }
            else
            {
                MessageBox.Show("Can only load one file at a time!");
            }

        }
    }
}
