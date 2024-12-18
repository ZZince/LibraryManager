using BusinessObjects.Enum;
namespace BusinessObjects.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeLivre Type { get; set; }
        public int Page { get; set; }
        public int Rate { get; set; }
        public Author Author { get; set; }

        public Book(int id, string name, TypeLivre type, int page, int rate, Author author)
        {
            Id = id;
            Name = name;
            Type = type;
            Page = page;
            Rate = rate;
            Author = author;
        }

        public override string ToString()
        {
            return $"Book: {Name} - Type: {Type} - Page: {Page} - Rate: {Rate} - Author: {Author}";
        }
    }
}
