
public class BookService : IBookService
{
    List<Book> _bookShelf = new List<Book>();

    public void AddBook(Book book)
    {
        _bookShelf.Add(book);
    }
    Book? ReturnWantedBook(string bookName)
    {
        return _bookShelf.FirstOrDefault(x => x.Name == bookName);
    }
    public List<Book> GetAll()
    {
        return new (_bookShelf);
    }
    
    public bool CheckAvailability(string bookName, out string message) // returns true if the book is available to be borrowed
    {
        message = "";
        return false;
    }
    public void BorrowBook(string bookName)
    { 
    }
    public void ReturnBook(string bookName)
    {
        
    }
}