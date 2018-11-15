using System;
using System.Collections.Generic;
using System.Data;

namespace Robot_Profiler
{
    class ProfileDB
    {
        private SQLite conn;

        public ProfileDB(String dbfilename, Boolean createDB)
        {
            try
            {
                conn = new SQLite(dbfilename, createDB);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
     
        }

        private String dbfilename;

        public String DBFilename
        {
            get { return dbfilename; }
            set { dbfilename = value; }
        }

        public void CreateTableRobotKWs()
        {
            conn.CreateTableKWs();
        }

        public void CreateTableRobotStats()
        {
            conn.CreateTableStats();
        }


        public void StoreRobotElem(RobotElement elem)
        {
            conn.InsertElement(elem);
        }

        public void StoreRobotElemBulk(List<RobotElement> elemList)
        {
            conn.InsertElementBulk(elemList);
        }

        public DataTable RetrieveTableStats()
        {
            return conn.SelectQuery("SELECT * FROM robotStats;");
        }

        public DataTable RetrieveTableDistinctKWs()
        {
            return conn.SelectQuery("SELECT Type, Name, count(Name) FROM robotKWs GROUP BY Name;");
        }

        public List<TimeSpan> RetrieveDuration(String kwName)
        {
            List<String> durations = conn.SelectQueryDurations(kwName);
            List<TimeSpan> durationsTimeSpan = new List<TimeSpan>();
            foreach (String duration in durations)
            {
                durationsTimeSpan.Add(TimeSpan.Parse(duration));
            }
            return durationsTimeSpan;
        }

        public List<TimeSpan> RetrieveDuration(String kwName, String state)
        {
            DataTable dt = conn.SelectQueryDurationsPassFail(kwName);
            List<TimeSpan> durationsTimeSpan = new List<TimeSpan>();
            foreach (DataRow row in dt.Rows)
            {
                if (state == row["Status"].ToString())
                {
                    durationsTimeSpan.Add(TimeSpan.Parse(row["Duration"].ToString()));
                }else
                {
                    durationsTimeSpan.Add(TimeSpan.Zero);
                }                
            }
            return durationsTimeSpan;

        }

        public long RetrieveStatusCount(String kwName, String state)
        {
            long count = conn.SelectQueryCountStatus(kwName, state);
            return count;
        }

        public DataTable GetKwTable(String kwName)
        {
            return conn.GetKwTable(kwName);
        }

        public DataRow GetKwByID(String kwID)
        {
            return conn.GetKwByID(kwID);
        }

        public void SaveStats(DataTable stats)
        {
            conn.SaveTableStats(stats);
        }


    }
}
