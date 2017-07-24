using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Robot_Profiler
{
    public class RobotElement
    {
        public RobotElement(String type, String name, long id, long parentid)
        {
            Type = type;
            Name = name;
            ID = id;
            ParentID = parentid;
        }
        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }


        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }


        private DateTime starttime;

        public DateTime Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }


        private DateTime endtime;

        public DateTime Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }


        private long parentID;

        public long ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        private TimeSpan duration;

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }


    }

}
