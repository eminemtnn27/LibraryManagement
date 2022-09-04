using BilgiKutuphanesiWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace BilgiKutuphanesiWebApp.Data
{
    public class BilgiContext : DbContext 
    {
        public BilgiContext(DbContextOptions<BilgiContext> options) : base(options)
        {
            
        }
        public  DbSet<Library> Library { get; set; } 
        public  DbSet<Book> Book { get; set; }
        public  DbSet<Magazines> Magazines { get; set; }
        public  DbSet<Dvds> Dvds { get; set; }
        public  DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Seed();
        }      
    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<User>().HasData(
            new User() { UserId = 4, UserName = "Seda", Job = "Student" },
            new User() { UserId = 8, UserName = "Haluk", Job = "Lecturer" },
            new User() { UserId = 6, UserName = "Pınar", Job = "Consultant" });

            modelBuilder.Entity<Book>().HasData(
            new Book() { BookId = 1, BookName = "Fizik", LendId = 4, LendTime = DateTime.Now, time = "2",BookTypeId=1 },
            new Book() { BookId = 3, BookName = "Suç ve Ceza",  LendId = 4, LendTime = DateTime.Now, time = "3", BookTypeId = 2 },
            new Book() { BookId = 2, BookName = "Tutunamayanlar",  LendId = 6, LendTime = DateTime.Now, time = "2", BookTypeId = 2 },
            new Book() { BookId = 4, BookName = "Matematik",  LendId = 8, LendTime = DateTime.Now, time = "1", BookTypeId = 1 });

            modelBuilder.Entity<Library>().HasData(
            new Library() {LibraryId= 1,LibraryName= "Bilgi Kütüphanesi"  } );

            modelBuilder.Entity<Magazines>().HasData(
            new Magazines() { MagazineId = 1,MagazineName = "John" },
            new Magazines() { MagazineId = 2, MagazineName = "Mukesh" });

            modelBuilder.Entity<Dvds>().HasData(
            new Dvds() {DvdId =1, DvdName = "Bilgi Felsefesi" });
            
            modelBuilder.Entity<BookType>().HasData(
            new {BookTypeId =1, BookTypeName = "Lesson Book" },
            new {BookTypeId =2, BookTypeName = "Novel" });
        }
    }
 
}


 
