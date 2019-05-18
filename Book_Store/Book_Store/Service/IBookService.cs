using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Service
{
    public interface IBookService
    {
        Task<BookItems> AddItemsAsync(BookItems book);
        Task EditAsync(BookItems book);
        Task DeleteAsync(BookItems bookItems);
        Task<BookItems> GetBookAsync(Guid bookId);
        Task<IEnumerable< BookItems>> GetBooksAsync();
    }
}
