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
        /// <param name="releaseDate">The release date.</param>
        public void AddBook(string bookName, int releaseYear)
        {
            using (var db = new AppContext())
            {
                db.Books.Add( new Book() { Name = bookName, ReleaseYear = releaseYear });
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
        /// <param name="newName">The new name.</param>
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
        /// <param name="updateYear">The update year.</param>
        public void UpdateBookNameById(int id, string bookName)
        {
            using (var db = new AppContext())
            {
                Book bookToUpdate = db.Books.FirstOrDefault(o => o.Id == id);

                if (bookToUpdate != null)
                {
                    bookToUpdate.Name = bookName;
                }
                db.SaveChanges();
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
                }
                db.SaveChanges();
            }
        }
    }
}
