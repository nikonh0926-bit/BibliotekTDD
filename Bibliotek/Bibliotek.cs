public class Book(string name)
{
    public string Name {get; set;} = name;
    public bool IsBorrowed {get; set;} = true; // false == not available
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
    
    public bool CheckAvailability(string bookName, out string message) // returns true if the book is available to be borrowed
    {
        message = "";
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
        {
            return _book.IsBorrowed;
        }
        message = "Book does not exist in bookshelf.";
        return false;
    }
    public void BorrowBook(string bookName)
    {
        if(!CheckAvailability(bookName, out string message))
            return;
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
            _book.IsBorrowed = false;
            
    }
    public void ReturnBook(string bookName)
    {
        Book? _book = ReturnWantedBook(bookName);
        if(_book != null)
            _book.IsBorrowed = true;
    }
}