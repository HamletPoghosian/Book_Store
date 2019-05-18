using Book_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Service
{
    public class BookService : IBookService
    {
        BookDBContext _context;
        public BookService(BookDBContext context)
        {
            _context = context;
        }
        public async Task<BookItems> AddItemsAsync(BookItems book)
        {
            var entity = new Book
            {
                Id = book.Id,
                Author = book.Author,
                Name = book.Name,
                Popular = book.Popular,
                Price = book.Price
            };
            await _context.BookItems.AddAsync(entity);
            await _context.SaveChangesAsync();
            book.Id = entity.Id;
            return book;
        }

        public async Task DeleteAsync(BookItems bookItems)
        {
            var entity = await _context.BookItems.SingleOrDefaultAsync(e => e.Id == bookItems.Id);
            _context.BookItems.Remove(entity);
            await _context.SaveChangesAsync();


        }

        public Task EditAsync(BookItems book)
        {
            throw new NotImplementedException();
        }

        public Task<BookItems> GetBookAsync(BookItems book)
        {
            throw new NotImplementedException();
        }
    }
}
