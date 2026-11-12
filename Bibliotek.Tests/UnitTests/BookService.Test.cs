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

        Assert.Equal(2, (await bookService.GetAll()).Count);
    }
    [Fact]
    public async Task TestCheckAvailability()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await bookService.AddBook(book1);

        Assert.Equal(Book.BookStatus.Available, await bookService.CheckAvailability(book1.Id));

        Assert.Equal(Book.BookStatus.notFound, await bookService.CheckAvailability(Guid.NewGuid()));
    }
    [Fact]
    public async Task TestBorrowBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await fakeBookRepository.AddBook(book1);

        Assert.Equal(Book.BookStatus.Available, await bookService.CheckAvailability(book1.Id));

        await bookService.BorrowBook(book1.Id);

        Assert.Equal(Book.BookStatus.Unavailable, await bookService.CheckAvailability(book1.Id));


    }
    [Fact]
    public async Task TestReturnBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await bookService.AddBook(book1);
        await bookService.BorrowBook(book1.Id);

        Assert.Equal(Book.BookStatus.Unavailable, await bookService.CheckAvailability(book1.Id));

        await bookService.ReturnBook(book1.Id);

        Assert.Equal(Book.BookStatus.Available, await bookService.CheckAvailability(book1.Id));
    }
    [Fact]
    public async Task TestBorrowBookNotFound()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        BookService bookService = new BookService(fakeBookRepository);
        Book book1 = new Book("Hunger games");

        await bookService.AddBook(book1);

        Assert.Equal(Book.BookStatus.Available, await bookService.CheckAvailability(book1.Id));

        await Assert.ThrowsAsync<Exception>(async () => await bookService.BorrowBook(Guid.NewGuid()));
    }
}
