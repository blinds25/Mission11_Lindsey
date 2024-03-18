namespace Mission11_Lindsey.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
