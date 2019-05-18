using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Service
{
    public static class BookServiceExtensions
    {
        public static IServiceCollection AddBook(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}
