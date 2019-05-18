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

        public async Task EditAsync(BookItems bookItems)
        {
            var entity = await _context.BookItems.SingleOrDefaultAsync(e => e.Id == bookItems.Id);
            entity.Id = bookItems.Id;
            entity.Name = bookItems.Name;
            entity.Popular = bookItems.Popular;
            entity.Price = bookItems.Price;
            entity.Author = bookItems.Author;

            _context.BookItems.Update(entity);
          await  _context.SaveChangesAsync();
        }

        

        public async Task<BookItems> GetBooksAsync(Guid bookId)
        {
            var entity = await _context.BookItems.SingleOrDefaultAsync(e => e.Id == bookId);
            return new BookItems
            {
                Id = entity.Id,
                Author=entity.Author,
                Name=entity.Name,
                Popular=entity.Popular,
                Price=entity.Price
            };
        }
        public Task<BookItems> GetBookAsync(BookItems book)
        {
            throw new NotImplementedException();
        }
    }
}
