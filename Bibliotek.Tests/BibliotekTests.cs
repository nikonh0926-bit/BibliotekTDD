namespace Bibliotek.Tests;

public class BibliotekTests
{
    [Fact]
    public void TestAddBook()
    {
        BookShelf _bookShelf = new BookShelf();
        Book book1 = new Book("Hunger games");
        Book book2 = new Book("Fifty shades of gray");

        _bookShelf.AddBook(book1);
        _bookShelf.AddBook(book2);

        Assert.True(_bookShelf.GetAll().Count == 2);
    }
    [Fact]
    public void TestCheckAvailability()
    {
        BookShelf _bookShelf = new BookShelf();
        Book book1 = new Book("Hunger games");

        _bookShelf.AddBook(book1);

        Assert.True(_bookShelf.CheckAvailability(book1.Name, out string message));

        Assert.True(!_bookShelf.CheckAvailability("denne boken existerer ikke", out string message2));
        Assert.NotEmpty(message2);
    }
    [Fact]
    public void TestBorrowBook()
    {
        BookShelf _bookShelf = new BookShelf();
        Book book1 = new Book("Hunger games");

        _bookShelf.AddBook(book1);

        Assert.True(_bookShelf.CheckAvailability(book1.Name, out string message));
        
        _bookShelf.BorrowBook(book1.Name);

        Assert.True(!_bookShelf.CheckAvailability(book1.Name, out string message2));

    }
    [Fact]
    public void TestReturnBook()
    {
        BookShelf _bookShelf = new BookShelf();
        Book book1 = new Book("Hunger games");

        _bookShelf.AddBook(book1);
        _bookShelf.BorrowBook(book1.Name);

        Assert.True(!_bookShelf.CheckAvailability(book1.Name, out string message));

        _bookShelf.ReturnBook(book1.Name);

        Assert.True(_bookShelf.CheckAvailability(book1.Name, out string message2));
    }
}
