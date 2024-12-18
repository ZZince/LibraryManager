using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;

public class Program
{
    static IHost CreateDefaultBuilder()
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Pour les livres
                services.AddSingleton<IGenericRepository<Book>, GenericRepository<Book>>();
                services.AddSingleton<IBookRepositoryManager, BookRepositoryManager>();

                // Pour les bibliothèques
                services.AddSingleton<IGenericRepository<Library>, GenericRepository<Library>>();
                services.AddSingleton<IRepositoryManager<Library>, RepositoryManager<Library>>();

                // Pour les auteurs
                services.AddSingleton<IGenericRepository<Author>, GenericRepository<Author>>();
                services.AddSingleton<IRepositoryManager<Author>, RepositoryManager<Author>>();
            });

        return builder.Build();
    }

    static void Main(string[] args)
    {
        var host = CreateDefaultBuilder();

        // Création des auteurs
        Author author1 = new Author(1, "Auteur", "Un");
        Author author2 = new Author(2, "Auteur", "Deux");

        // Création des livres
        Book book1 = new Book(1, "Les Aventures de Tintin", TypeLivre.Aventure, 320, 10, author1);
        Book book2 = new Book(2, "Science Fiction Épique", TypeLivre.ScienceFiction, 250, 5, author2);
        Book book3 = new Book(3, "Romance Tropicale", TypeLivre.Romance, 200, 7, author1);

        // Création de la bibliothèque
        Library library = new Library(1, "Bibliothèque Centrale", "123 Rue Principale");
        library.Books = new List<Book> { book1, book2, book3 };

        using (var serviceScope = host.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            try
            {
                var bookManager = services.GetRequiredService<IBookRepositoryManager>();
                var libraryManager = services.GetRequiredService<IRepositoryManager<Library>>();
                var authorManager = services.GetRequiredService<IRepositoryManager<Author>>();

                // Ajout des données
                libraryManager.Repository.Add(library);
                authorManager.Repository.Add(author1);
                authorManager.Repository.Add(author2);
                bookManager.Repository.Add(book1);
                bookManager.Repository.Add(book2);
                bookManager.Repository.Add(book3);

                // Affichage de toutes les bibliothèques
                List<Library> allLibraries = libraryManager.GetAll();
                Console.WriteLine("Toutes les bibliothèques:");
                foreach (var lib in allLibraries)
                {
                    Console.WriteLine($"ID: {lib.Id}, Nom: {lib.Name}, Adresse: {lib.Adress}");
                }

                // Affichage des livres d'aventure
                List<Book> adventureBooks = bookManager.GetCatalog(TypeLivre.Aventure);
                Console.WriteLine("\nLivres d'aventure:");
                foreach (var book in adventureBooks)
                {
                    Console.WriteLine(book);
                }

                // Recherche d'un livre spécifique par ID
                Book specificBook = bookManager.Find(1);
                Console.WriteLine($"\nLivre avec ID=1: {specificBook}");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                Console.ReadLine();
            }
        }
    }

}