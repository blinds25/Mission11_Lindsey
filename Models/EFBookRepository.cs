using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission11_Lindsey.Models
{
    public class EFBookRepository : IBookRepository
    {
        private readonly BookstoreContext _context;

        public EFBookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<Book> Books, int TotalBooks)> GetBooksAsync(int pageNumber, int pageSize)
        {
            var totalBooks = await _context.Books.CountAsync();
            var books = await _context.Books
                                      .OrderBy(b => b.BookId)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();
            return (books, totalBooks);
        }

        // Additional implementations...
    }
}
