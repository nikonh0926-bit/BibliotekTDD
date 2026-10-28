public class Book(string name)
{
    public string Name {get; set;} = name;
    public bool IsBorrowed {get; set;} = false;
}

public class BookShelf
{
    List<Book> _bookShelf = new List<Book>();

    public void AddBook(Book book)
    {
        //TODO: finish function
    }
    public List<Book> GetAll()
    {
        // TODO: return correct list
        return new List<Book>();
    }
    public bool? CheckAvailability(Book book)
    {
        //TODO: give correct value
        return null;
    }
    public void BorrowBook(Book book)
    {
        //TODO: finish function
    }
    public void ReturnBook(Book book)
    {
        //TODO: finish function
    }
}