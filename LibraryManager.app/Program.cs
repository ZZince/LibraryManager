using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Services.Services;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Création des auteurs
        Author author1 = new Author(1, "Auteur 1", "Nom 1");
        Author author2 = new Author(2, "Auteur 2", "Nom 2");

        // Création des livres
        Book book1 = new Book(1, "Livre d'aventure", TypeLivre.Aventure, 300, 5, author1);
        Book book2 = new Book(2, "Livre de science-fiction", TypeLivre.ScienceFiction, 250, 4, author2);
        Book book3 = new Book(3, "Livre de romance", TypeLivre.Romance, 200, 3, author1);

        // Création de la bibliothèque
        Library library = new Library(1, "Bibliothèque Centrale", "123 Rue Principale");
        library.Books = new List<Book> { book1, book2, book3 };

        // Utilisation de la méthode GetAll
        List<Library> allLibraries = LibraryRepository.GetAll();
        Console.WriteLine("Toutes les bibliothèques:");
        foreach (var lib in allLibraries)
        {
            Console.WriteLine(lib);
        }

        // Utilisation de la méthode Get avec l'ID
        try
        {
            Library specificLibrary = LibraryRepository.Get(1);
            Console.WriteLine($"\nBibliothèque avec ID 1: Nom: {specificLibrary.Name}, Adresse: {specificLibrary.Adress}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Utilisation de CatalogManager

        // Récupérer tout le catalogue
        List<Book> catalog = CatalogManager.GetCatalog();
        Console.WriteLine("\nCatalogue complet:");
        foreach (var book in catalog)
        {
            Console.WriteLine(book);
        }

        // Récupérer les livres d'un type spécifique
        List<Book> adventureBooks = CatalogManager.GetBooks(TypeLivre.Aventure);
        Console.WriteLine("\nLivres d'aventure:");
        foreach (var book in adventureBooks)
        {
            Console.WriteLine(book);
        }

        // Trouver un livre par ID
        Console.WriteLine("\nLivre avec ID 1:");
        Book specificBook = CatalogManager.FindBook(1);
        Console.WriteLine(specificBook);
    }
}