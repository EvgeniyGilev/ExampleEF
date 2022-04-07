using System;
using ExampleEF.EF;
using ExampleEF.Repositories;
using System.Collections.Generic;

namespace ExampleEF
{
    public class Init
    {
        public void InitializeDatabaseData()
        {

            using (var db = new AppEFContext.AppContext())
            {
                var user1 = new User { Name = "Arthur", Email = "Arthur@gmail.com" };
                var user2 = new User { Name = "Evgeniy", Email = "Evgeniy@gmail.com" };

                db.Users.Add(user1);
                db.Users.Add(user2);


                var author1 = new Author { Name = "Носов Н. Н." };
                var author2 = new Author { Name = "Хант Э." };
                var author4 = new Author { Name = "Ассанов М.О." };
                var author5 = new Author { Name = "Льюис К." };

                db.Authors.AddRange(author1, author2, author4, author5);


                var theme1 = new Theme { ThemeName = "Учебная литература" };
                var theme2 = new Theme { ThemeName = "Сказки" };

                db.Themes.AddRange(theme1, theme2);

                var book1 = new Book { Name = "Незнайка на Луне", ReleaseYear = 1965 };
                var book2 = new Book { Name = "Программист-прагматик. Путь от подмастерья к мастеру", ReleaseYear = 2009 };
                var book3 = new Book { Name = "Дискретная математика: графы, матроиды, алгоритмы. Учебное пособие", ReleaseYear = 2010 };
                var book4 = new Book { Name = "Приключения Алисы в Стране чудес", ReleaseYear = 1865 };

                db.Books.AddRange(book1, book2, book4, book4);

                book1.Author = author1;
                book2.Author = author2;
                book3.Author = author4;
                book4.Author = author5;

                book1.Theme = theme2;
                book4.Theme = theme2;

                book2.Theme = theme1;
                book3.Theme = theme1;

                user1.Books.Add(book3);
                user2.Books.Add(book2);

                db.SaveChanges();
            }
        }
    }
}
