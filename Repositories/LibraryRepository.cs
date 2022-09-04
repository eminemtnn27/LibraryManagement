using BilgiKutuphanesiWebApp.Data;
using BilgiKutuphanesiWebApp.Data.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace BilgiKutuphanesiWebApp.Repositories
{
    public class LibraryRepository : Repository<Book>, ILibraryRepository
    {
        public LibraryRepository(BilgiContext context) : base(context)
        {
        }

        public IEnumerable<Book> FindWithUser(Func<Book, bool> books)
        {
            return _context.Book
                .Include(a => a.BookType.BookTypeName)
                .Where(books);
        }

        public IEnumerable<Book> FindWithUserAndBorrower(Func<Book, bool> books)
        {
            return _context.Book
                .Include(a => a.BookType.BookTypeName)
                .Include(a => a.LendId)
                .Where(books);
        }

        public IEnumerable<Book> FindWithUserr(Func<Book, bool> books)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllWithUser()
        {
            return _context.Book.Include(a => a.BookType.BookTypeName);
        }

        public User GetWithBooks(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
