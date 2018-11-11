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
            openFileDialogXMLFile.Multiselect = true;

            if (openFileDialogXMLFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialogXMLFile.FileNames)
                {
                    OpenRobotXMLFile(filename);
                }
            }
        }

        private void OpenRobotXMLFile(string filename)
        {
            datafile = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".db";
            TabPage newProfilerTab = new TabPage(filename + "   ");
            DataGridView dataGridViewRobotKWs = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ContextMenuStrip = contextMenuStripDGVMain,
                Location = new Point(3, 3),
                Name = "dataGridViewRobotKWs",
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                TabIndex = 2,
                Dock = DockStyle.Fill,
                Tag = datafile
            };
            dataGridViewRobotKWs.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridViewRobotKWs_CellFormatting);

            newProfilerTab.Controls.Add(dataGridViewRobotKWs);
            tabControlMain.Controls.Add(newProfilerTab);

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
            openFileDialogDBFile.Multiselect = true;

            if (openFileDialogDBFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialogDBFile.FileNames)
                {
                    OpenRobotDBFile(filename);
                }
            }
        }

        private void OpenRobotDBFile(string filename)
        {
            datafile = filename;
            ProfileDB db = new ProfileDB(filename, false);
            TabPage newProfilerTab = new TabPage(filename + "   ");
            DataGridView dataGridViewRobotKWs = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ContextMenuStrip = contextMenuStripDGVMain,
                Location = new Point(3, 3),
                Name = "dataGridViewRobotKWs",
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                TabIndex = 2,
                Dock = DockStyle.Fill,
                Tag = datafile
            };
            dataGridViewRobotKWs.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridViewRobotKWs_CellFormatting);
            dataGridViewRobotKWs.MouseUp += DataGridViewRobotKWs_MouseUp;

            newProfilerTab.Controls.Add(dataGridViewRobotKWs);
            tabControlMain.Controls.Add(newProfilerTab);


            dataGridViewRobotKWs.DataSource = null;
            dataGridViewRobotKWs.Rows.Clear();
            toolStripStatusLabelMainFormStatus.Text = "Database file loaded: " + filename;
            dataGridViewRobotKWs.DataSource = db.RetrieveTableStats();
            dataGridViewRobotKWs.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DataGridViewRobotKWs_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tabControlMain.SelectedTab != null)
                {
                    DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];

                    var rowClicked = dataGridViewRobotKWs.HitTest(e.Location.X, e.Location.Y).RowIndex;
                    if (rowClicked > -1)
                    {
                        dataGridViewRobotKWs.ClearSelection();
                        dataGridViewRobotKWs.Rows[rowClicked].Selected = true;
                    }
                }
            } 
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Robot Profiler v0.0.0.8\nCarlos Santos");
        }

        private void ToolStripButtonSearch_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            if (tabControlMain.SelectedTab != null)
            {
                DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];

                dataGridViewRobotKWs.CurrentCell = null;
                foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
                {
                    foreach (DataGridViewCell cell in line.Cells)
                    {
                        if (line.Index != 0)
                        {
                            if (cell.Value.ToString().ToLower().Contains(toolStripTextBoxSearch.Text.ToLower()))
                            {
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
        }

        private void ToolStripButtonClearSearch_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab != null)
            {
                DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];
                foreach (DataGridViewRow line in dataGridViewRobotKWs.Rows)
                {
                    dataGridViewRobotKWs.Rows[line.Index].Visible = true;
                }
            }
        }

        private void DataGridViewRobotKWs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];
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
            if (tabControlMain.SelectedTab != null)
            {
                DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];
                Form formGraphAll = new FormGraphAll(dataGridViewRobotKWs)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                formGraphAll.Show();
            }
        }

        private void ContextMenuStripDGVMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];
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
            DataGridView dataGridViewRobotKWs = (DataGridView)tabControlMain.SelectedTab.Controls["dataGridViewRobotKWs"];
            foreach ( DataGridViewRow row in dataGridViewRobotKWs.SelectedRows)
            {
                Form formGraphKwPoints = new FormGraphKwPoints(dataGridViewRobotKWs.Tag.ToString(), row.Cells["Name"].Value.ToString())
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

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl TC = (TabControl)sender;
            Rectangle TabRec = TC.GetTabRect(e.Index);

            Color Clr = e.State == DrawItemState.Selected ? Color.White : Color.LightGray;

            e.Graphics.FillRectangle(new SolidBrush(Clr), TabRec);

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap
            };
            
            if (e.State == DrawItemState.Selected)
            {
                Rectangle BTNRec = new Rectangle(TabRec.X + TabRec.Width - 15, 6, 10, 10);
                e.Graphics.DrawImage(Properties.Resources.Actions_application_exit_icon, BTNRec);
            }

            e.Graphics.DrawString(TC.TabPages[e.Index].Text, this.Font, Brushes.Black, TabRec, sf);

            TabRec.Inflate(-2, -2);

            Pen Pn = e.State == DrawItemState.Selected ? new Pen(Color.LightBlue, 1) : new Pen(Color.Empty, 1);

            e.Graphics.DrawRectangle(Pn, TabRec);
            e.DrawFocusRectangle();

        }

        private void tabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            toolStripStatusLabelMainFormStatus.Text = "File loaded: " + e.TabPage.Text;
            else
                toolStripStatusLabelMainFormStatus.Text = "";
        }

        private void tabControlMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Rectangle r = tabControlMain.GetTabRect(this.tabControlMain.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 16, r.Top + 4, 16, 16);
            if (closeButton.Contains(e.Location))
            {
                TabPage tabToRemove = this.tabControlMain.SelectedTab; 
                if (tabControlMain.TabPages.Count >1) this.tabControlMain.SelectedIndex = 0; //TabControl bug workarround to prevent disapearing of tabpage header
                this.tabControlMain.TabPages.Remove(tabToRemove);

            }
        }
    }
}
