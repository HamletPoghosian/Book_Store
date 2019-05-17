using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;
using Book_Store.ViewModels;

namespace Book_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDBContext _context;
        public HomeController(BookDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Book> book = _context.BookItems.ToList();
           
            List<BookView> booklist=new List<BookView>();
            for (int i = 0; i < book.Count; i++)
            {
                booklist[i].Id=book[i].Id;
                booklist[i].Name = book[i].Name;
                booklist[i].Author = book[i].Author;
                booklist[i].Popular = book[i].Popular;
                booklist[i].Price = book[i].Price;
            }
            return View(booklist);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
