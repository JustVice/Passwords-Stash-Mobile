using SQLite;

namespace PasswordsStashMobile.Model
{
    [Table("Password")]
    public class PasswordModel
    {
        [PrimaryKey][AutoIncrement]
        public int PasswordId { get; set; }
        public string Service { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public string Favorite { get; set; }
    }
}
