using SQLite;

namespace PasswordsStashMobile.Model
{
    [Table("MasterPassword")]
    public class MasterPasswordModel
    {
        [PrimaryKey][AutoIncrement]
        public int MasterPasswordId { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Hint { get; set; }
    }
}
