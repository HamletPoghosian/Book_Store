using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Store.Models;
using Book_Store.Service;
using Book_Store.ViewModels;

namespace Book_Store.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDBContext _context;
        private readonly IBookService _addBook;


        public BooksController(BookDBContext context,IBookService book)
        {
            _context = context;
            _addBook = book;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookItems> items = Enumerable.Empty<BookItems>();
             items = await _addBook.GetBooksAsync();
            
            var result = items.Select(p => new BookView
            {
                Id = p.Id,
                Author = p.Author,
                Name = p.Name,
                Popular = p.Popular,
                Price = p.Price
            });
            return View(result);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _addBook.GetBookAsync(id.Value);
            var bookView = new BookView
            {
                Id = book.Id,
                Author = book.Author,
                Name = book.Name,
                Popular = book.Popular,
                Price = book.Price
            };
            if (book == null)
            {
                return NotFound();
            }

            return View(bookView);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,Price,Popular")]BookCreateViewModel book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                var result = new BookItems
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Popular = book.Popular,
                    Price = book.Price
                };
                 await  _addBook.AddItemsAsync(result);
               
               
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.BookItems.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Author,Price,Popular")] BookView book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = new BookItems
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Name = book.Name,
                        Popular = book.Popular,
                        Price = book.Price
                    };
                   await _addBook.EditAsync(editBook);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _addBook.GetBookAsync(id.Value);
            var viewBook = new BookView
            {
                Id = book.Id,
                Author = book.Author,
                Name = book.Name,
                Popular = book.Popular,
                Price = book.Price
            };
            if (book == null)
            {
                return NotFound();
            }

            return View(viewBook);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {

            var book = await _addBook.GetBookAsync(id.Value);
            await _addBook.DeleteAsync(book);
           
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            return _context.BookItems.Any(e => e.Id == id);
        }
    }
}
