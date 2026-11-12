
public class BookService(IBookRepository repository) : IBookService
{
    private readonly IBookRepository _repository = repository;

    public async Task AddBook(Book book)
    {
       await _repository.AddBook(book);
    }
    public async Task<IReadOnlyList<Book>> GetAll()
    {
        return new List<Book>();
    }

    public async Task<bool> CheckAvailability(Guid bookId) // returns true if the book is available to be borrowed
    {
        return false;
    }
    public async Task BorrowBook(Guid bookId)
    { 
    }
    public async Task ReturnBook(Guid bookId)
    {
        
    }
}