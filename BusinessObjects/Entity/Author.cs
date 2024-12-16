namespace BusinessObjects.Entity
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public static List<Author> _allAuthors = new List<Author>();

        public Author(int id, string lastName, string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;

            _allAuthors.Add(this);
        }
    }

}
