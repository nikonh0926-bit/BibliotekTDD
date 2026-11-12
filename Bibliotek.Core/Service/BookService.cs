
public class BookService(IBookRepository repository) : IBookService
{

    public async Task AddBook(Book book)
    {
       await repository.AddBook(book);
    }
    public async Task<IReadOnlyList<Book>> GetAll()
    {
        List<Book> books = new (await repository.GetAll());
        return books;
    }

    public async Task<Book.BookStatus> CheckAvailability(Guid bookId) // returns the status of the book
    {
        return await repository.CheckAvailability(bookId);
    }
    public async Task BorrowBook(Guid bookId)
    {
        await repository.BorrowBook(bookId);
    }
    public async Task ReturnBook(Guid bookId)
    {
        await repository.ReturnBook(bookId);
    }
}