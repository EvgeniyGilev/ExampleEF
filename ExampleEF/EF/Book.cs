using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEF.EF
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        
        //название книги
        public string Name { get; set; }

        //год выхода
        public int ReleaseYear { get; set; }

        //внешний ключ на User
        //public int UserId { get; set; }

        public User User { get; set; }

        //внешний ключ на Author
        //public int AuthorId { get; set; }

        public Author Author { get; set; }

        //внешний ключ на Theme
        //public int ThemeId { get; set; }

        public Theme Theme { get; set; }
    }
}

