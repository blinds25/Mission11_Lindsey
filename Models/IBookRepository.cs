using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mission11_Lindsey.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task AddBookAsync(Book book);

        // New method for pagination
        Task<(IEnumerable<Book> Books, int TotalBooks)> GetBooksAsync(int pageNumber, int pageSize);
    }
}
