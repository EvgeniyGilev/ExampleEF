using ExampleEF.AppEFContext;
using ExampleEF.EF;
using System.Collections.Generic;
using System.Linq;
using System;
using AppContext = ExampleEF.AppEFContext.AppContext;

namespace ExampleEF.Repositories
{
    public class BookRepository
    {
        /// <summary>
        /// Добавляем книгу
        /// </summary>
        /// <param name="bookName">The book name.</param>
        /// <param name="releaseYear">The release date.</param>
        public void AddBook(string bookName, int releaseYear)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(new Book() { Name = bookName, ReleaseYear = releaseYear });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Выводим все книги в список
        /// </summary>
        /// <returns>A list of Books.</returns>
        public List<Book> SelectAllBooks()
        {
            using (var db = new AppContext())
            {
                List<Book> allBooks = db.Books.ToList();
                return allBooks;
            }
        }

        /// <summary>
        /// Выбираем книгу по ID
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Book.</returns>
        public Book SelectBookById(int id)
        {
            using (var db = new AppContext())
            {
                Book bookById = db.Books.Where(b => b.Id == id).FirstOrDefault();
                return bookById;
            }
        }


        /// <summary>
        /// Удаляем книгу
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteBookById(int id)
        {
            using (var db = new AppContext())
            {
                Book bookForDelete = db.Books.FirstOrDefault(b => b.Id == id);
                if (bookForDelete != null)
                {
                    db.Books.Remove(bookForDelete);
                    db.SaveChanges();
                }

            }
        }


        /// <summary>
        /// Обновляем название книги по ID
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="bookName">The book name.</param>
        public void UpdateBookNameById(int id, string bookName)
        {
            using (var db = new AppContext())
            {
                Book bookToUpdate = db.Books.FirstOrDefault(o => o.Id == id);

                if (bookToUpdate != null)
                {
                    bookToUpdate.Name = bookName;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Обновляем дату выпуска книги по id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="updateYear">The update year.</param>
        public void UpdateBookReleaseDateById(int id, int releaseYear)
        {
            using (var db = new AppContext())
            {
                Book bookToUpdate = db.Books.FirstOrDefault(o => o.Id == id);

                if (bookToUpdate != null)
                {
                    bookToUpdate.ReleaseYear = releaseYear;
                    db.SaveChanges();
                }

            }
        }


        /// <summary>
        /// 1. Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="themeName">The theme name.</param>
        /// <param name="beginYear">The begin year.</param>
        /// <param name="endYear">The end year.</param>
        public List<Book> SelectBookByThemeAndReleaseDate(string themeName, int beginYear, int endYear)
        {
            using (var db = new AppContext())
            {
                List<Book> bookByThemeAndReleadeDate = db.Books.Where(b => b.Theme.ThemeName == themeName && b.ReleaseYear >= beginYear && b.ReleaseYear <= endYear)
                                                                .ToList();
                return bookByThemeAndReleadeDate;
            }
        }

        /// <summary>
        /// 2. Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="authorName">The author name.</param>
        /// <returns>An int.</returns>
        public int CountBooksByAuthor(string authorName)
        {
            using (var db = new AppContext())
            {
                int booksByAuthor = db.Books.Count(b => b.Author.Name == authorName);
                return booksByAuthor;
            }
        }


        /// <summary>
        /// 3.	Получать количество книг определенного жанра в библиотеке
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <returns>An int.</returns>
        public int CountBooksByTheme(string theme)
        {
            using (var db = new AppContext())
            {
                int booksByTheme = db.Books.Count(b => b.Theme.ThemeName == theme);
                return booksByTheme;
            }
        }

        /// <summary>
        /// 4. Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="authorName">The author name.</param>
        /// <param name="bookName">The book name.</param>
        /// <returns>A bool.</returns>
        public bool CheckBookByAuthorAndName(string authorName, string bookName)
        {
            using (var db = new AppContext())
            {
                Book searchBook = db.Books.FirstOrDefault(b => b.Author.Name == authorName && b.Name == bookName);

                if (searchBook != null)
                    return true;
                else return false;
            }
        }

        /// <summary>
        /// 5. Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="bookName">The book name.</param>
        /// <param name="userName">The user name.</param>
        /// <returns>A bool.</returns>
        public bool CheckBookByUserAndName(string bookName, string userName)
        {
            using (var db = new AppContext())
            {
                Book searchBook = db.Books.FirstOrDefault(b => b.Name == bookName && b.User.Name == userName);

                if (searchBook != null)
                    return true;
                else return false;
            }
        }

        /// <summary>
        /// 6. Получать количество книг на руках у пользователя.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>An int.</returns>
        public int CountUserBooks(string userName)
        {
            using (var db = new AppContext())
            {
                int CountUserBooks = db.Books.Count(u => u.User.Name == userName);
                return CountUserBooks;
            }
        }

        /// <summary>
        /// 7. Получение последней вышедшей книги.
        /// </summary>
        /// <returns>A Book.</returns>
        public Book GetLastByReleaseYearBook()
        {
            using (var db = new AppContext())
            {
                var book = db.Books.OrderByDescending(b => b.ReleaseYear).First();
                return book;
            }
        }

        /// <summary>
        /// 8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns>A list of Books.</returns>
        public List<Book> GetBooksOrderByName()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderBy(b => b.Name).ToList();
                return books;
            }
        }

        // 9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> GetBooksOrderByDescendingYear()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderByDescending(b => b.ReleaseYear).ToList();
                return books;
            }
        }

    }
}
