using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.app
{
    public class Book
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Book(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"Book: {Name}, Type: {Type}";
        }
    }

}
