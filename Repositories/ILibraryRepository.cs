using BilgiKutuphanesiWebApp.Data.Models; 
using Microsoft.AspNetCore.Mvc; 

namespace BilgiKutuphanesiWebApp.Repositories
{
    public interface ILibraryRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWithUser(); 
        IEnumerable<Book> FindWithUserAndBorrower(Func<Book, bool> books);
        void Update(Book book);
        
    }
}
