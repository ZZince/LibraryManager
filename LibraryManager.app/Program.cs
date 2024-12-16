using LibraryManager.app;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Book> books = new List<Book>();
        books.Add(new Book("Le Hobbit", "Fantaisie"));
        books.Add(new Book("L'île au trésor", "Aventure"));
        books.Add(new Book("Le tour du monde en 80 jours", "Aventure"));
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }

        IEnumerable<Book> aventureBooks = from book in books
                                          where book.Type == "Aventure"
                                          select book;

        foreach (Book book in aventureBooks)
        {
            Console.WriteLine(book);
        }
    }
}