using System;
using System.ComponentModel.DataAnnotations;

namespace BilgiKutuphanesiWebApp.Data.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public virtual ICollection<Book> Books  { get; set; }
        public virtual ICollection<Magazines> Magazines { get; set; }
        public virtual ICollection<Dvds> Dvds { get; set; }
         
    }    
    
    public class Magazines
    {
        [Key]
        public int MagazineId { get; set; }
        public string MagazineName { get; set; }
    }
    public class Dvds
    {
        [Key]
        public int DvdId { get; set; }
        public string DvdName { get; set; }
    }
}
