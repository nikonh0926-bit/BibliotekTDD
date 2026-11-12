
public class FakeBookRepository : IBookRepository
{
    private readonly List<Book> _bookShelf = new List<Book>();

    public Task AddBook(Book book)
    {
        _bookShelf.Add(book);
        return Task.CompletedTask;
    }
    public Task<IReadOnlyList<Book>> GetAll()
    {
        return Task.FromResult((IReadOnlyList<Book>)_bookShelf);
    }

    public Task<Book.BookStatus> CheckAvailability(Guid bookId) // returns true if the book is available to be borrowed
    {
        Book? book = _bookShelf.FirstOrDefault(x => x.Id == bookId);
        if(book == null)
            return Task.FromResult(Book.BookStatus.notFound);
        else if(book.Status == Book.BookStatus.Available)
            return Task.FromResult(Book.BookStatus.Available);
        else
            return Task.FromResult(Book.BookStatus.Unavailable);
    }
    public Task BorrowBook(Guid bookId)
    { 
        Book? book = _bookShelf.FirstOrDefault(x => x.Id == bookId);
        if(book == null)
        {
            throw new Exception("Book not found");
        }
        else if(book.Status == Book.BookStatus.Unavailable)
        {
            throw new Exception("Book is already borrowed");
        }
        else
            book.Status = Book.BookStatus.Unavailable;
        return Task.CompletedTask;
    }
    public Task ReturnBook(Guid bookId)
    {
        Book? book = _bookShelf.FirstOrDefault(x => x.Id == bookId);
        if(book != null)
            book.Status = Book.BookStatus.Available;
        return Task.CompletedTask;
    }
}