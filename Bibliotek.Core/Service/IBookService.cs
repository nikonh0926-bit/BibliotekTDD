public interface IBookService
{
    public void AddBook(Book book);
    public List<Book> GetAll();
    public bool CheckAvailability(string bookName, out string message);
    public void BorrowBook(string bookName);
    public void ReturnBook(string bookName);
}