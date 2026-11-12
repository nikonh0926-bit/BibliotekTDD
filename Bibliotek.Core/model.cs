public class Book(string name)
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Name {get; set;} = name;
    public enum BookStatus { Available, Unavailable }
    public BookStatus Status {get; set;} = BookStatus.Available;
}