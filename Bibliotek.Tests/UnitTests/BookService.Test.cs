namespace Bibliotek.Tests;

public class BibliotekTests
{
    [Fact]
    public async Task TestAddBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);

        Book book1 = new Book("Hunger games");
        Book book2 = new Book("Fifty shades of gray");

        await bookService.AddBook(book1);
        await bookService.AddBook(book2);

        IReadOnlyList<Book> books = await bookService.GetAll();

        Assert.True(books.Count == 2);
    }
    [Fact]
    public async Task TestCheckAvailability()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await bookService.AddBook(book1);

        Assert.True(await bookService.CheckAvailability(book1.Id));

        Assert.False(await bookService.CheckAvailability(Guid.NewGuid()));
    }
    [Fact]
    public async Task TestBorrowBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await fakeBookRepository.AddBook(book1);

        Assert.True(await bookService.CheckAvailability(book1.Id));
        
        await bookService.BorrowBook(book1.Id);

        Assert.False(await bookService.CheckAvailability(book1.Id));

    }
    [Fact]
    public async Task TestReturnBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await bookService.AddBook(book1);
        await bookService.BorrowBook(book1.Id);

        Assert.False(await bookService.CheckAvailability(book1.Id));

        await bookService.ReturnBook(book1.Id);

        Assert.True(await bookService.CheckAvailability(book1.Id));
    }
}
