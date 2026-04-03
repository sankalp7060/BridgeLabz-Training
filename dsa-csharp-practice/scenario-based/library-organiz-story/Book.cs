public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }

    public Book(int id, string title, string author, string genre)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"{Id}, {Title}, {Author}, {Genre}";
    }
}
