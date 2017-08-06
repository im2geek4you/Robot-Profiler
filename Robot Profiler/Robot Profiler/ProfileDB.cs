using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Robot_Profiler
{
    class ProfileDB
    {
        private SQLite conn;

        public ProfileDB(String dbfilename, Boolean createDB)
        {
            conn = new SQLite(dbfilename, createDB);     
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

        public void SaveStats(DataTable stats)
        {
            conn.SaveTableStats(stats);
        }


    }
}
