
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

    public Task<bool> CheckAvailability(Guid bookId, out string message) // returns true if the book is available to be borrowed
    {/*
        message = "";
        return ReturnWantedBook(bookId.ToString()).ContinueWith(task =>
        {
            Book? _book = task.Result;
            if(_book != null)
            {
                return _book.IsBorrowed;
            }
        message = "Book does not exist in bookshelf.";
        return Task.FromResult(false);
        });*/
        message = "";
        return null;
    }
    public Task BorrowBook(Guid bookId)
    { /*
        Book wantedBook = _bookShelf.FirstOrDefault(x => x.Id == bookId);
        if(wantedBook != null && wantedBook.IsBorrowed)
            wantedBook.IsBorrowed = false;
        return Task.CompletedTask;*/
        return null;
    }
    public Task ReturnBook(Guid bookId)
    {/*
        Book wantedBook = _bookShelf.FirstOrDefault(x => x.Id == bookId);
        if(wantedBook != null)
            wantedBook.IsBorrowed = true;
        return Task.CompletedTask;*/
        return null;
    }
}