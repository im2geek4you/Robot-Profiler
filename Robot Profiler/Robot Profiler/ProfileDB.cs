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

        public void CreateTable(String tablename)
        {
            conn.CreateTable(tablename);
        }
        
        public void StoreRobotElem(RobotElement elem)
        {
            conn.InsertElement(elem);
        }

        public void StoreRobotElemBulk(List<RobotElement> elemList)
        {
            conn.InsertElementBulk(elemList);
        }

        public DataTable RetrieveTable(String tablename)
        {
            return conn.SelectQuery("SELECT Type, Name, count(Name) FROM robot GROUP BY Name;");
        }

        public List<TimeSpan> RetrieveDuration(String table, String Name)
        {
            List<String> durations = conn.SelectQueryDurations(table, Name);
            List<TimeSpan> durationsTimeSpan = new List<TimeSpan>();
            foreach (String duration in durations)
            {
                durationsTimeSpan.Add(TimeSpan.Parse(duration));
            }
            return durationsTimeSpan;
        }

    }
}
