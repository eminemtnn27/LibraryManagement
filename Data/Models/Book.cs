using System.ComponentModel.DataAnnotations;

namespace BilgiKutuphanesiWebApp.Data.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; } 
        public User User { get; set; }
        public int LendId { get; set; }
        public virtual BookType BookType { get; set; }
        public int BookTypeId { get; set; }
        public int UserId { get; set; }

        public DateTime LendTime { get; set; }
        public string time { get; set; }
    }
    public class BookType
    {
        [Key]
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
