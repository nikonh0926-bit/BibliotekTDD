namespace Bibliotek.Tests;

public class BibliotekTests
{
    [Fact]
    public async Task TestAddBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();

        Book book1 = new Book("Hunger games");
        Book book2 = new Book("Fifty shades of gray");

        await fakeBookRepository.AddBook(book1);
        await fakeBookRepository.AddBook(book2);
        
        IReadOnlyList<Book> books = await fakeBookRepository.GetAll();

        Assert.True(books.Count == 2);
    }
    [Fact]
    public async Task TestCheckAvailability()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        Book book1 = new Book("Hunger games");

        await fakeBookRepository.AddBook(book1);

        Assert.True(await fakeBookRepository.CheckAvailability(book1.Id, out string message));

        Assert.False(await fakeBookRepository.CheckAvailability(Guid.NewGuid(), out string message2));
        Assert.NotEmpty(message2);
    }
    [Fact]
    public async Task TestBorrowBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        Book book1 = new Book("Hunger games");

        await fakeBookRepository.AddBook(book1);

        Assert.True(await fakeBookRepository.CheckAvailability(book1.Id, out string message));
        
        await fakeBookRepository.BorrowBook(book1.Id);

        Assert.False(await fakeBookRepository.CheckAvailability(book1.Id, out string message2));

    }
    [Fact]
    public async Task TestReturnBook()
    {
        FakeBookRepository fakeBookRepository = new FakeBookRepository();
        Book book1 = new Book("Hunger games");

        await fakeBookRepository.AddBook(book1);
        await fakeBookRepository.BorrowBook(book1.Id);

        Assert.False(await fakeBookRepository.CheckAvailability(book1.Id, out string message));

        await fakeBookRepository.ReturnBook(book1.Id);

        Assert.True(await fakeBookRepository.CheckAvailability(book1.Id, out string message2));
    }
}
