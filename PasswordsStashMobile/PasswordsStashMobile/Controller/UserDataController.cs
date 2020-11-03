using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using PasswordsStashMobile.Model;

namespace PasswordsStashMobile.Controller
{
    public class UserDataController
    {
        private SQLiteConnection sqliteConn;
        public string Status = "";

        public UserDataController(string ConnectionPath)
        {
            sqliteConn = new SQLiteConnection(ConnectionPath);
            sqliteConn.CreateTable<UserDataModel>(); // Creates table if does not exist.
        }

        // -------------------------------------------------------------------
        // Funciones CRUD.

        public IEnumerable<UserDataModel> GetAllUserData()
        {
            try
            {
                return sqliteConn.Table<UserDataModel>();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return Enumerable.Empty<UserDataModel>();
        }

        public UserDataModel GetUserData(int id)
        {
            try
            {
                return sqliteConn.Table<UserDataModel>()
                .Where(i => i.UserDataId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return null;
        }

        public int InsertUserData(UserDataModel UserData)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Insert(UserData);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int UpdateUserdata(UserDataModel UserData)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Update(UserData);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int DeleteUserData(UserDataModel UserData)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Delete<UserDataModel>(UserData);
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
