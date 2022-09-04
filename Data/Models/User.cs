using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BilgiKutuphanesiWebApp.Data.Models
{
    public class User 
    {
        [Key]
         public int UserId  { get; set; }
         public string UserName { get; set; }    
         public string Job { get; set; }
        public ICollection<Book> Book { get; set; }
        public int LendId { get; set; }
    }
    public class LendModel
    {
       // public Library Library { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
       
    }
    

}
