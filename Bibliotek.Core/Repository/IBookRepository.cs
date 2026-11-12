public interface IBookRepository
{
    public Task AddBook(Book book);
    public Task<IReadOnlyList<Book>> GetAll();
    public Task<bool> CheckAvailability(Guid bookId, out string message);
    public Task BorrowBook(Guid bookId);
    public Task ReturnBook(Guid bookId);
}