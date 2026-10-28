class Book(string name)
{
    public string Name {get; set;} = name;
    public bool IsBorrowed {get; set;} = false;
}

class BookShelf
{
    List<Book> _bookShelf = new List<Book>();

    void AddBook()
    {
    
    }
    void CheckAvailability()
    {
        
    }
    void BorrowBook()
    {
        
    }
    void ReturnBook()
    {
        
    }
}