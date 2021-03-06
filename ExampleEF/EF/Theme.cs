using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEF.EF
{
    /// <summary>
    /// Тема книги
    /// </summary>
    public class Theme
    {
        public int Id { get; set; }

        //название темы книги
        public string ThemeName { get; set; }

        //Тема может быть у нескольких книг, задаем связь
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
