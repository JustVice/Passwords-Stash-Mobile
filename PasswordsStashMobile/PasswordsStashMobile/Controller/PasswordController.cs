using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using PasswordsStashMobile.Model;

namespace PasswordsStashMobile.Controller
{
    public class PasswordController
    {
        private SQLiteConnection sqliteConn;
        public string Status = "";

        public PasswordController(string ConnectionPath)
        {
            sqliteConn = new SQLiteConnection(ConnectionPath);
            sqliteConn.CreateTable<PasswordModel>(); // Creates table if does not exist.
        }

        // -------------------------------------------------------------------
        // Funciones CRUD.

        public IEnumerable<PasswordModel> GetAllPasswords()
        {
            try
            {
                return sqliteConn.Table<PasswordModel>();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return Enumerable.Empty<PasswordModel>();
        }

        public PasswordModel GetPassword(int id)
        {
            try
            {
                return sqliteConn.Table<PasswordModel>()
                .Where(i => i.PasswordId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return null;
        }

        public int InsertPassword(PasswordModel password)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Insert(password);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int UpdatePassword(PasswordModel password)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Update(password);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int DeletePassword(PasswordModel password)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Delete<PasswordModel>(password);
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
