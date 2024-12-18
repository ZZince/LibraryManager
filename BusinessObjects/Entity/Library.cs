namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Book>? Books { get; set; }

        public Library(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;

        }

    }
}
