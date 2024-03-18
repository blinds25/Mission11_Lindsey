using Microsoft.AspNetCore.Mvc;
using Mission11_Lindsey.Models;
using System.Diagnostics;

namespace Mission11_Lindsey.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var (Books, TotalBooks) = await _bookRepository.GetBooksAsync(pageNumber, pageSize);
            var totalPages = (int)Math.Ceiling(TotalBooks / (double)pageSize);

            var viewModel = new BooksListViewModel
            {
                Books = Books,
                PageInfo = new PageInfo
                {
                    CurrentPage = pageNumber,
                    TotalPages = totalPages,
                    TotalItems = TotalBooks
                }
            };

            return View(viewModel);
        }


    }
}
