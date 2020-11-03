using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using PasswordsStashMobile.Model;

namespace PasswordsStashMobile.Controller
{
    public class LogController
    {
        private SQLiteConnection sqliteConn;
        public string Status = "";

        public LogController(string ConnectionPath)
        {
            sqliteConn = new SQLiteConnection(ConnectionPath);
            sqliteConn.CreateTable<LogModel>(); // Creates table if does not exist.
        }

        // -------------------------------------------------------------------
        // Funciones CRUD.

        public IEnumerable<LogModel> GetAllLogs()
        {
            try
            {
                return sqliteConn.Table<LogModel>();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return Enumerable.Empty<LogModel>();
        }

        public LogModel GetLog(int id)
        {
            try
            {
                return sqliteConn.Table<LogModel>()
                .Where(i => i.LogId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return null;
        }

        public int InsertLog(LogModel log)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Insert(log);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int UpdateLog(LogModel log)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Update(log);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int DeleteLog(LogModel log)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Delete<LogModel>(log);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }
    }
}
