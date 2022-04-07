using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEF.EF
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        //имя читателя
        public string Name { get; set; }

        //электронный адрес
        public string Email { get; set; }

        //У читателя может быть у нескольких книг на руках, задаем связь
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
