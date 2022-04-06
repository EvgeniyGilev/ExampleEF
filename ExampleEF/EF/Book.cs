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

        //пользователь у кого книга на руках
        public User User { get; set; }

        //авторы книги
        public Author Author { get; set; }

        //тема книги
        public Theme Theme { get; set; }
    }
}
}
