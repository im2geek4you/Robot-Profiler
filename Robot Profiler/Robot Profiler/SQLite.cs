using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Robot_Profiler
{
    class SQLite
    {
        private String sqlfilename;

        public SQLite(String FileName, Boolean createDB)
        {
            try
            {
                if (createDB) { SQLiteConnection.CreateFile(FileName); };
                sqlfilename = FileName;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        public DataTable SelectQuery(string query)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                try
                {
                    SQLiteCommand cmd;
                    sqlite.Open();  //Initiate connection to the db
                    cmd = sqlite.CreateCommand();
                    cmd.CommandText = query;  //set the passed query
                    da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt); //fill the datasource
                }
                catch (SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sqlite.Close();
                    sqlite.Dispose();
                }
            }
            return dt;
        }

        public List<String> SelectQueryDurations(String kwName)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand query = new SQLiteCommand("SELECT Name,Duration FROM robotKWs WHERE Name=@Name", sqlite))
                {
                    try
                    {
                        query.Parameters.AddWithValue("@Name", kwName);
                        sqlite.Open();  //Initiate connection to the db
                        da = new SQLiteDataAdapter(query);
                        da.Fill(dt); //fill the datasource
                    }
                    catch (SQLiteException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        sqlite.Close();
                        sqlite.Dispose();
                    }
                }
            }
            return dt.Rows.OfType<DataRow>().Select(dr => dr.Field<String>("Duration")).ToList();
        }

        public DataTable SelectQueryDurationsPassFail(String kwName)
        {
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand query = new SQLiteCommand("SELECT Name,Duration,Status FROM robotKWs WHERE Name=@Name", sqlite))
                {
                    try
                    {
                        query.Parameters.AddWithValue("@Name", kwName);
                        sqlite.Open();  //Initiate connection to the db
                        da = new SQLiteDataAdapter(query);
                        da.Fill(dt); //fill the datasource
                    }
                    catch (SQLiteException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        sqlite.Close();
                        sqlite.Dispose();
                    }
                }
            }
            return dt;
        }


        public void CreateTableKWs()
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand createTable = new SQLiteCommand("CREATE TABLE robotKWs ( `Type` TEXT NOT NULL, `Name` TEXT NOT NULL, `Status` TEXT NOT NULL, `StartTime` TEXT, `EndTime` TEXT, `Duration` TEXT, `ID` INTEGER, `ParentID` INTEGER, PRIMARY KEY(ID))", sqlite))
                {
                    try
                    {
                        sqlite.Open();
                        createTable.ExecuteNonQuery();
                        sqlite.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

        }

        public void CreateTableStats()
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand createTable = new SQLiteCommand("CREATE TABLE robotStats ( `Type` TEXT NOT NULL, `Name` TEXT NOT NULL, `count(Name)` INTEGER NOT NULL, `Avg. Duration` TEXT NOT NULL, `Total Duration` TEXT NOT NULL, PRIMARY KEY(Name))", sqlite))
                {
                    try
                    {
                        sqlite.Open();
                        createTable.ExecuteNonQuery();
                        sqlite.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }


        public void InsertElement(RobotElement elem)
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO robotKWs (Type, Name, Status, StartTime, EndTime, Duration, ID, ParentID) VALUES (@Type, @Name, @Status, @StartTime, @EndTime, @Duration, @ID, @ParentID)", sqlite))
                {
                    insertSQL.Parameters.AddWithValue("@Type", elem.Type);
                    insertSQL.Parameters.AddWithValue("@Name", elem.Name);
                    insertSQL.Parameters.AddWithValue("@Status", elem.Status);
                    insertSQL.Parameters.AddWithValue("@StartTime", elem.Starttime);
                    insertSQL.Parameters.AddWithValue("@EndTime", elem.Endtime);
                    insertSQL.Parameters.AddWithValue("@Duration", elem.Duration);
                    insertSQL.Parameters.AddWithValue("@ID", elem.ID);
                    insertSQL.Parameters.AddWithValue("@ParentID", elem.ParentID);
                    try
                    {
                        sqlite.Open();
                        insertSQL.ExecuteNonQuery();
                        sqlite.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public void InsertElementBulk(List<RobotElement> elemList)
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO robotKWs (Type, Name, Status, StartTime, EndTime, Duration, ID, ParentID) VALUES (@Type, @Name, @Status, @StartTime, @EndTime, @Duration, @ID, @ParentID)", sqlite))
                {
                    try
                    {
                        sqlite.Open();
                        foreach (RobotElement elem in elemList)
                        {
                            insertSQL.Parameters.AddWithValue("@Type", elem.Type);
                            insertSQL.Parameters.AddWithValue("@Name", elem.Name);
                            insertSQL.Parameters.AddWithValue("@Status", elem.Status);
                            insertSQL.Parameters.AddWithValue("@StartTime", elem.Starttime);
                            insertSQL.Parameters.AddWithValue("@EndTime", elem.Endtime);
                            insertSQL.Parameters.AddWithValue("@Duration", elem.Duration);
                            insertSQL.Parameters.AddWithValue("@ID", elem.ID);
                            insertSQL.Parameters.AddWithValue("@ParentID", elem.ParentID);
                            try
                            {
                                insertSQL.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sqlite.Close();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        sqlite.Close();
                    }
                }       
            }            
        }

        public void SaveTableStats(DataTable stats)
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO robotStats (Type, Name, [count(Name)], [Avg. Duration], [Total Duration]) VALUES (@Type, @Name, @count, @AvgDuration, @TotalDuration)", sqlite))
                {
                    try
                    {
                        sqlite.Open();
                        foreach (DataRow row in stats.Rows)
                        {
                            insertSQL.Parameters.AddWithValue("@Type", row["Type"]);
                            insertSQL.Parameters.AddWithValue("@Name", row["Name"]);
                            insertSQL.Parameters.AddWithValue("@count", row["count(Name)"]);
                            insertSQL.Parameters.AddWithValue("@AvgDuration", row["Avg. Duration"]);
                            insertSQL.Parameters.AddWithValue("@TotalDuration", row["Total Duration"]);
                            try
                            {
                                insertSQL.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sqlite.Close();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        sqlite.Close();
                    }
                }
            }
        }


        public void UpdateElement(RobotElement elem)
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand updateSQL = new SQLiteCommand("UPDATE robotKWs SET Type=@Type, Name=@Name, Status=@Status, StartTime=@StartTime, EndTime=@EndTime, Duration=@Duration, ParentID=@ParentID WHERE ID=@ID;", sqlite))
                {
                    updateSQL.Parameters.AddWithValue("@Type", elem.Type);
                    updateSQL.Parameters.AddWithValue("@Name", elem.Name);
                    updateSQL.Parameters.AddWithValue("@Status", elem.Status);
                    updateSQL.Parameters.AddWithValue("@StartTime", elem.Starttime);
                    updateSQL.Parameters.AddWithValue("@EndTime", elem.Endtime);
                    updateSQL.Parameters.AddWithValue("@Duration", elem.Duration);
                    updateSQL.Parameters.AddWithValue("@ParentID", elem.ParentID);
                    try
                    {
                        sqlite.Open();
                        updateSQL.ExecuteNonQuery();
                        sqlite.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                    
            }
                
        }


        public void DeleteElement(RobotElement elem)
        {
            using (SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + sqlfilename + ";Version=3;Pooling=True;Max Pool Size=10;Synchronous=off;FailIfMissing=True;Journal Mode=Off;"))
            {
                using (SQLiteCommand deleteSQL = new SQLiteCommand("DELETE FROM robotKWs WHERE ID=@ID ;", sqlite))
                {
                    deleteSQL.Parameters.AddWithValue("@ID", elem.ID);
                    try
                    {
                        sqlite.Open();
                        deleteSQL.ExecuteNonQuery();
                        sqlite.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }                    
            }     
        }

    }
}
