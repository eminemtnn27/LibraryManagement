using BilgiKutuphanesiWebApp.Data;
using BilgiKutuphanesiWebApp.Data.Models;
using BilgiKutuphanesiWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
 

namespace BilgiKutuphanesiWebApp.Controllers
{
    public class LendController : Controller
    {
        private readonly ILibraryRepository _LibraryRepository;

        private readonly BilgiContext _context;

        public LendController(BilgiContext context, ILibraryRepository LibraryRepository)
        {
           _LibraryRepository = LibraryRepository;
            _context = context;
        }
         public IActionResult Index()
         {
            ViewBag.User=_context.User.Select(n=> new SelectListItem
            {
                Text=n.Job,
                Value=n.Job  
            }).Distinct();
             return  View();
         } 
        public IActionResult LendBook(int bookId)
        {
            var lendVM = new LendModel()
            {
                Book = _LibraryRepository.GetById(bookId)
            };
            return View(lendVM);
        }

        [HttpPost]
        public IActionResult LendBook(LendModel lendModel)
        {
            var book = _LibraryRepository.GetById(lendModel.Book.BookId);
            _LibraryRepository.Update(book);
            return RedirectToAction("List");
        }

        [Route("Lend")]
        public IActionResult List()
        {
            var availableBooks = _context.User.Where(x=>x.UserId==0);
            
            if (availableBooks.Count()==0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
            return View();
        }
    }
}
