using SQLite;

namespace PasswordsStashMobile.Model
{
    [Table("Log")]
    public class LogModel
    {
        [PrimaryKey][AutoIncrement]
        public int LogId { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
