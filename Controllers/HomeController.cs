using BilgiKutuphanesiWebApp.Data;
using BilgiKutuphanesiWebApp.Data.Models;
using BilgiKutuphanesiWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BilgiKutuphanesiWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BilgiContext _context;

        public HomeController(BilgiContext context)
        {
           
            _context = context;
        }
        public IActionResult List()
        { 
            return View(_context.Book.ToList());
            
        } 

         
    }
}
