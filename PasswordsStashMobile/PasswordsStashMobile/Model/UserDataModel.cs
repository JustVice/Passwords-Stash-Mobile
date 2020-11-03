using SQLite;

namespace PasswordsStashMobile.Model
{
    [Table("UserData")]
    public class UserDataModel
    {
        [PrimaryKey][AutoIncrement]
        public int UserDataId { get; set; }
        public string Username { get; set; }
        public string DarkMode { get; set; }
        public string Language { get; set; }
        public string FirstTimeOpen { get; set; }
    }
}
