using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using PasswordsStashMobile.Model;

namespace PasswordsStashMobile.Controller
{
    public class MasterPasswordController
    {
        private SQLiteConnection sqliteConn;
        public string Status = "";

        public MasterPasswordController(string ConnectionPath)
        {
            sqliteConn = new SQLiteConnection(ConnectionPath);
            sqliteConn.CreateTable<MasterPasswordModel>(); // Creates table if does not exist.
        }

        // -------------------------------------------------------------------
        // Funciones CRUD.

        public IEnumerable<MasterPasswordModel> GetAllMasterPasswords()
        {
            try
            {
                return sqliteConn.Table<MasterPasswordModel>();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return Enumerable.Empty<MasterPasswordModel>();
        }

        public MasterPasswordModel GetMasterPassword(int id)
        {
            try
            {
                return sqliteConn.Table<MasterPasswordModel>()
                .Where(i => i.MasterPasswordId == id)
                .FirstOrDefault();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return null;
        }

        public int InsertMasterPassword(MasterPasswordModel MasterPassword)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Insert(MasterPassword);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int UpdateMasterPassword(MasterPasswordModel MasterPassword)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Update(MasterPassword);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int DeleteMasterPassword(MasterPasswordModel MasterPassword)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Delete<MasterPasswordModel>(MasterPassword);
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
