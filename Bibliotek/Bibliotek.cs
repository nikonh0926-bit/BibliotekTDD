public class Book(string name)
{
    public string Name {get; set;} = name;
    public bool IsBorrowed {get; set;} = false; // true == not available
}

public class BookShelf
{
    List<Book> _bookShelf = new List<Book>();

    public void AddBook(Book book)
    {
        _bookShelf.Add(book);
    }
    Book? ReturnWantedBook(string bookName)
    {
        foreach(Book books in _bookShelf)
        {
            if(books.Name == bookName)
            {
                return books;
            }
        }
        return null;
    }
    public List<Book> GetAll()
    {
        return new (_bookShelf);
    }
    
    public bool CheckAvailability(string bookName)
    {
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
        {
            return _book.IsBorrowed;
        }
        return true;
    }
    public void BorrowBook(string bookName)
    {
        if(CheckAvailability(bookName))
            return;
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
            _book.IsBorrowed = true;
            
    }
    public void ReturnBook(string bookName)
    {
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
            _book.IsBorrowed = false;
    }
}