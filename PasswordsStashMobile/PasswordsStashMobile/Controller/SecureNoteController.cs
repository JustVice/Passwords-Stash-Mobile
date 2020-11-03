using System;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using PasswordsStashMobile.Model;

namespace PasswordsStashMobile.Controller
{
    public class SecureNoteController
    {
        private SQLiteConnection sqliteConn;
        public string Status = "";

        public SecureNoteController(string ConnectionPath)
        {
            sqliteConn = new SQLiteConnection(ConnectionPath);
            sqliteConn.CreateTable<SecureNoteModel>(); // Creates table if does not exist.
        }

        // -------------------------------------------------------------------
        // Funciones CRUD.

        public IEnumerable<SecureNoteModel> GetAllSecureNotes()
        {
            try
            {
                return sqliteConn.Table<SecureNoteModel>();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return Enumerable.Empty<SecureNoteModel>();
        }

        public SecureNoteModel GetSecureNote(int id)
        {
            try
            {
                return sqliteConn.Table<SecureNoteModel>()
                .Where(i => i.SecureNoteId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return null;
        }

        public int InsertSecureNote(SecureNoteModel SecureNote)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Insert(SecureNote);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int UpdateSecureNote(SecureNoteModel SecureNote)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Update(SecureNote);
                Status = string.Format("Affected rows: {0}", AffectedRows);
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
            return AffectedRows;
        }

        public int DeleteSecureNote(SecureNoteModel SecureNote)
        {
            int AffectedRows = 0;
            try
            {
                AffectedRows = sqliteConn.Delete<SecureNoteModel>(SecureNote);
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
