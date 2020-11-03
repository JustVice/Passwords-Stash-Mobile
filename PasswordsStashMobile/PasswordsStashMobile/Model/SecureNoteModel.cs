using SQLite;

namespace PasswordsStashMobile.Model
{
    [Table("SecureNote")]
    public class SecureNoteModel
    {
        [PrimaryKey][AutoIncrement]
        public int SecureNoteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Favorite { get; set; }
    }
}
