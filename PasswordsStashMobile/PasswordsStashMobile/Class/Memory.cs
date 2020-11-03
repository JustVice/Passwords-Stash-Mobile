using System;
using System.IO;

namespace PasswordsStashMobile.Class
{
    public class Memory
    {
        public static string AppVersion = "0.0.1-dev";
        public static string SQLiteDatabasePath = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                ,"PasswordsStashMobile.db");
    }
}
