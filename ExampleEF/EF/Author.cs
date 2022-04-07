using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEF.EF
{
    public class Author
    {
        public int Id { get; set; }

        //автор книги
        public string Name { get; set; }

        //автор может быть у нескольких книг, задаем связь
        public List<Book> Books { get; set; } = new List<Book>();

    }
}
