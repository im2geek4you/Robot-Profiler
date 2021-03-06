﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Robot_Profiler
{
    public partial class FormGraphKwPoints : Form
    {
        private String DataFile;
        private String KwName;
        DataGridView KwDGV = new DataGridView();
        private String ID = null;

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

        public FormGraphKwPoints(String datafile, String kwName, String ID)
        {
            InitializeComponent();
            DataFile = datafile;
            KwName = kwName;
            this.Text = "Keyword:" + kwName + " - " + datafile;
            this.ID = ID;
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
            chartGraphKwPoints.Series[KwName].ToolTip = "x= #VALX, y= #VAL ms";

            S.LabelAngle = 45;
            toolStripStatusLabelStatus.Text = "PASS: " + db.RetrieveStatusCount(KwName, "PASS") + " FAIL: " + db.RetrieveStatusCount(KwName, "FAIL");

            for (int i = 0; i < Durations.Count; i++)
            {
                chartGraphKwPoints.Series[KwName].Points.AddXY(i, Durations[i].TotalMilliseconds);
            }

            if (ID != null)
            {
                showTable();
                KwDGV.ClearSelection();
                int line = 0;
                foreach (DataGridViewRow row in KwDGV.Rows)
                {
                    if (row.Cells["ID"].Value.ToString() == ID) line = row.Index;
                }
                KwDGV.Rows[line].Selected = true;
                if ((KwDGV.Rows[line].Displayed == false) && (KwDGV.Rows[line].Visible))
                {
                    KwDGV.FirstDisplayedScrollingRowIndex = line;
                }
                overlayGraphKw(line, ID);
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
            overlayGraphPoints("PASS");
        }

        private void toolStripButtonFailOnly_Click(object sender, EventArgs e)
        {
            overlayGraphPoints("FAIL");
        }

        private void toolStripButtonTable_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void ChartGraphKwPoints_MouseClick(object sender, MouseEventArgs e)
        {
            if (splitContainerGraphTable.Panel2Collapsed == false && KwDGV.SortOrder == SortOrder.None && KwDGV.SortedColumn == null)
            {
                var pos = e.Location;
                var results = chartGraphKwPoints.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var point = result.Object as DataPoint;
                        var line = (int)point.XValue;

                        this.KwDGV.ClearSelection();

                        KwDGV.Rows[line].Selected = true;
                        if ( (KwDGV.Rows[line].Displayed == false) && (KwDGV.Rows[line].Visible))
                        {
                            KwDGV.FirstDisplayedScrollingRowIndex = line;
                        }

                    }
                }
            }

        }


        private void KwDGV_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowClicked = KwDGV.HitTest(e.Location.X, e.Location.Y).RowIndex;
                if (rowClicked > -1)
                {
                    if (KwDGV.SelectedRows.Count >= 1 && ! KwDGV.SelectedRows.Contains(KwDGV.Rows[KwDGV.HitTest(e.Location.X, e.Location.Y).RowIndex]))
                    {
                        KwDGV.ClearSelection();
                        KwDGV.Rows[rowClicked].Selected = true;
                    }

                }
            }
        }

        private void KwDGVMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (DataGridViewRow row in KwDGV.SelectedRows)
            {
                FormHierarchyTree FormKwTreeView = new FormHierarchyTree(DataFile, KwName, row.Cells["ID"].Value.ToString());
                FormKwTreeView.Show();
            }
        }

        private void KwDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView KwDGV = (DataGridView)sender;
            KwDGV.Columns["ID"].Visible = false;
            KwDGV.Columns["ParentID"].Visible = false;
            KwDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            KwDGV.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            KwDGV.ReadOnly = true;
            KwDGV.AllowUserToAddRows = false;
            KwDGV.AllowUserToResizeRows = false;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new System.Drawing.Font(KwDGV.Font.FontFamily, 8, System.Drawing.FontStyle.Bold);
            KwDGV.Columns["Status"].DefaultCellStyle = style;
            foreach (DataGridViewRow row in KwDGV.Rows)
                if (row.Cells["Status"].Value.ToString() == "FAIL")
                {
                    row.Cells["Status"].Style = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Red };
                }else
                {
                    row.Cells["Status"].Style = new DataGridViewCellStyle { ForeColor = System.Drawing.Color.Green };
                }


        }

        private void overlayGraphPoints(String status)
        {
            List<TimeSpan> Durations;
            ProfileDB db = new ProfileDB(DataFile, false);
            Durations = db.RetrieveDuration(KwName, status);
            String seriesName = KwName + " ("+ status + ")";

            if (chartGraphKwPoints.Series.IndexOf(seriesName) == -1)
            {
                Series S = chartGraphKwPoints.Series.Add(seriesName);
                S.ChartType = SeriesChartType.Point;
                if (status == "PASS")
                {
                    S.Color = System.Drawing.Color.Green;
                }
                else
                {
                    S.Color = System.Drawing.Color.Red;
                }
                chartGraphKwPoints.ChartAreas[0].AxisY.LabelStyle.Format = "{}ms";
                chartGraphKwPoints.MouseClick += new MouseEventHandler(ChartGraphKwPoints_MouseClick);
                chartGraphKwPoints.Series[seriesName].ToolTip = "x= #VALX, y= #VAL ms";

                S.LabelAngle = 45;

                for (int i = 0; i < Durations.Count; i++)
                {
                    if (Durations[i] != TimeSpan.Zero)
                    {
                        chartGraphKwPoints.Series[seriesName].Points.AddXY(i, Durations[i].TotalMilliseconds);
                    }
                }
                //workarround for bug in chart when only one point exists at x=0
                if (chartGraphKwPoints.Series[seriesName].Points.Count == 1)
                {
                    DataPoint dp = new DataPoint(1, 0);
                    dp.Color = System.Drawing.Color.Transparent;
                    chartGraphKwPoints.Series[seriesName].Points.Add(dp);
                }

            }
            else
            {
                chartGraphKwPoints.Series.RemoveAt(chartGraphKwPoints.Series.IndexOf(seriesName));
            }
        }

        private void overlayGraphKw(int index, String KwID)
        {
            System.Data.DataRow KwData;
            ProfileDB db = new ProfileDB(DataFile, false);
            KwData = db.GetKwByID(KwID);
            String seriesName = KwName + " (Selected)";

            if (chartGraphKwPoints.Series.IndexOf(seriesName) == -1)
            {
                Series S = chartGraphKwPoints.Series.Add(seriesName);
                S.ChartType = SeriesChartType.Point;
                S.Color = System.Drawing.Color.DarkBlue;
                chartGraphKwPoints.ChartAreas[0].AxisY.LabelStyle.Format = "{}ms";
                chartGraphKwPoints.MouseClick += new MouseEventHandler(ChartGraphKwPoints_MouseClick);
                chartGraphKwPoints.Series[seriesName].ToolTip = "x= #VALX, y= #VAL ms";
                S.LabelAngle = 45;
                chartGraphKwPoints.Series[seriesName].Points.AddXY(index, TimeSpan.Parse(KwData["Duration"].ToString()).TotalMilliseconds);
                //workarround for bug in chart when only one point exists at x=0
                if (index == 0)
                {
                    DataPoint dp = new DataPoint(1,0);
                    dp.Color = System.Drawing.Color.Transparent;
                    chartGraphKwPoints.Series[seriesName].Points.Add(dp);
                }

            }
            else
            {
                chartGraphKwPoints.Series.RemoveAt(chartGraphKwPoints.Series.IndexOf(seriesName));
            }
        }


        private void showTable()
        {
            if (splitContainerGraphTable.Panel2Collapsed)
            {
                splitContainerGraphTable.Panel2Collapsed = false;
                ProfileDB db = new ProfileDB(DataFile, false);

                ContextMenuStrip KwDGVMenu = new ContextMenuStrip();
                KwDGVMenu.Items.Add("Show Hierarchy Tree");
                KwDGVMenu.ItemClicked += new ToolStripItemClickedEventHandler(KwDGVMenu_ItemClicked);
                KwDGV.ContextMenuStrip = KwDGVMenu;
                KwDGV.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(KwDGV_DataBindingComplete);
                KwDGV.Dock = DockStyle.Fill;
                KwDGV.RowHeadersVisible = false;
                KwDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                KwDGV.DataSource = db.GetKwTable(KwName);
                KwDGV.MouseUp += new MouseEventHandler(KwDGV_MouseUp);

                splitContainerGraphTable.Panel2.Controls.Add(KwDGV);
            }
        }


    }
}
