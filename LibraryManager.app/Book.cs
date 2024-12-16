using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.app
{
    public class Book
    {
        private string _Name { get; set; }
        private string _Type { get; set; }

        public Book(string name, string type)
        {
            _Name = name;
            _Type = type;
        }

        public override string ToString()
        {
            return $"Book: {_Name}, Type: {_Type}";
        }
    }

}
