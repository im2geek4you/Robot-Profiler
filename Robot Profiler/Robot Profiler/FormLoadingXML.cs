using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Robot_Profiler
{
    public partial class FormLoadingXML : Form
    {
        private string FileName;
        Stack KWStack = new Stack();

        public FormLoadingXML()
        {
            InitializeComponent();
        }

        public FormLoadingXML(string filename)
        {
            InitializeComponent();
            FileName = filename;
        }

        private void LoadingXML_Shown(object sender, EventArgs e)
        {
            backgroundWorkerXML2DB.RunWorkerAsync();
        }


        private void backgroundWorkerXML2DB_DoWork(object sender, DoWorkEventArgs e)
        {
            List<RobotElement> robotList = new List<RobotElement>();
            int lineCount = File.ReadLines(FileName).Count();
            ProfileDB db = new ProfileDB(Path.GetFileNameWithoutExtension(FileName)+".db", true);
            db.CreateTableRobotKWs();
            using (XmlReader reader = XmlReader.Create(FileName))
            {
                long count = 0;
                IXmlLineInfo xli = (IXmlLineInfo)reader;
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name
                        if (reader.Name == "suite" || reader.Name == "test" || reader.Name == "kw")
                        {
                            RobotElement elem = new RobotElement(reader.Name, reader["name"], count, 0);
                            KWStack.Push(elem); //store element on the stack
                        }
                        else if (reader.Name == "status")
                        {
                            if (reader["starttime"] != "N/A" && reader["endtime"] != "N/A")
                            {
                                DateTime starttime = DateTime.ParseExact(reader["starttime"], "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                DateTime endtime = DateTime.ParseExact(reader["endtime"], "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                                TimeSpan duration = endtime.Subtract(starttime);
                                try
                                {
                                    //retrieve status, element and store them in database
                                    RobotElement elem = (RobotElement)KWStack.Pop();
                                    elem.Status = reader["status"];
                                    elem.Starttime = starttime;
                                    elem.Endtime = endtime;
                                    elem.Duration = duration;
                                    try
                                    {
                                        RobotElement tempElem = (RobotElement)KWStack.Peek();
                                        if (tempElem != null) elem.ParentID = tempElem.ID;
                                    }
                                    catch (Exception)
                                    {
                                        elem.ParentID = 0; //first element has ParentID = 0
                                    }
                                    robotList.Add(elem);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error occurred @XMl line:" + xli.LineNumber + "\n" + ex.Message);
                                }
                            }
                            else {
                                //starttime and endtime not available. but elapsedtime is present?
                                try
                                {
                                    //retrieve status, element and store them in database
                                    RobotElement elem = (RobotElement)KWStack.Pop();
                                    elem.Status = reader["status"];
                                    elem.Starttime = DateTime.MinValue;
                                    elem.Endtime = DateTime.MinValue;
                                    elem.Duration = new TimeSpan((long)(Convert.ToDouble(reader["elapsedtime"])*10));
                                    try
                                    {
                                        RobotElement tempElem = (RobotElement)KWStack.Peek();
                                        if (tempElem != null) elem.ParentID = tempElem.ID;
                                    }
                                    catch (Exception)
                                    {
                                        elem.ParentID = 0; //first element has ParentID = 0
                                    }
                                    robotList.Add(elem);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error occurred @XMl line:" + xli.LineNumber + "\n" + ex.Message);
                                }
                            }

                        }
                        if (count % 1000 == 0)
                        {
                            backgroundWorkerXML2DB.ReportProgress((int)((double)xli.LineNumber/(double)lineCount*100), "Processed "+ xli.LineNumber + " lines out of "+ lineCount + " in XML.");
                        }
                        count++;
                    }

                }
            }
            backgroundWorkerXML2DB.ReportProgress(100, "Storing data on Database... Please wait!");
            db.StoreRobotElemBulk(robotList);
        }

        private void backgroundWorkerXML2DB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxXMLWorker.Image = null;
            Thread.Sleep(1000);
            this.Close();
        }

        private void backgroundWorkerXML2DB_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarXMLWorker.Value = e.ProgressPercentage;
            labelWorkDescription.Text = e.UserState.ToString();
        }

        private void buttonXMLWorkerCancel_Click(object sender, EventArgs e)
        {
            backgroundWorkerXML2DB.CancelAsync();
            this.Close();
        }
    }
}
