using System.ComponentModel.DataAnnotations.Schema;
using BusinessObjects.Enum;
namespace BusinessObjects.Entity
{
    [Table("book")]
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeLivre Type { get; set; }
        public int Pages { get; set; }
        public int Rate { get; set; }

        [ForeignKey("id_author")]
        public Author Author { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
        public int id_author { get; set; }

        public Book()
        {
            
        }

        public Book(int id, string name, TypeLivre type, int page, int rate, Author author)
        {
            Id = id;
            Name = name;
            Type = type;
            Pages = page;
            Rate = rate;
            Author = author;
        }

        public override string ToString()
        {
            return $"Book: {Name} - Type: {Type} - Page: {Pages} - Rate: {Rate} - Author: {Author}";
        }
    }
}
