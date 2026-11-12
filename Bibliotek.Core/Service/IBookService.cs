public interface IBookService
{
    public Task AddBook(Book book);
    public Task<IReadOnlyList<Book>> GetAll();
    public Task<Book.BookStatus> CheckAvailability(Guid bookId);
    public Task BorrowBook(Guid bookId);
    public Task ReturnBook(Guid bookId);
}