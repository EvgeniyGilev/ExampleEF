using System;
using ExampleEF.EF;
using ExampleEF.Repositories;
using System.Collections.Generic;

namespace ExampleEF
{
    class Program
    {
        static void Main(string[] args)
        {

            // заполняем данные в БД при необходимости
            //Init libraryDb = new Init();
            //libraryDb.InitializeDatabaseData();
            

            UserRepository userRep = new UserRepository();
            List<User> listUsers = userRep.SelectAllUsers();

            foreach (User user in listUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.ReadKey();

            //проверяем по заданиям:

            Console.WriteLine("1. Получать список книг определенного жанра и вышедших между определенными годами.");

            BookRepository bookRep = new BookRepository();

            List<Book> BookByThemeAndReleaseDate = bookRep.SelectBookByThemeAndReleaseDate("Сказки", 1900, 1970);
            foreach (Book book in BookByThemeAndReleaseDate)
            {
                Console.WriteLine(book.Name);
            }

            Console.WriteLine("2. Получать количество книг определенного автора в библиотеке.");

            int countBook = bookRep.CountBooksByAuthor("Льюис К.");
            Console.WriteLine(countBook);

            Console.WriteLine("3.	Получать количество книг определенного жанра в библиотеке");

            countBook = bookRep.CountBooksByTheme("Сказки");
            Console.WriteLine(countBook);

            Console.WriteLine("4.Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.");

            bool isBookExist = bookRep.CheckBookByAuthorAndName("Льюис К.", "Приключения Алисы в Стране чудес");
            Console.WriteLine(isBookExist);

            Console.WriteLine("5.Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.");

            isBookExist = bookRep.CheckBookByUserAndName("Приключения Алисы в Стране чудес", "Arthur");
            Console.WriteLine(isBookExist);

            Console.WriteLine("6.Получать количество книг на руках у пользователя.");

            countBook = bookRep.CountUserBooks("Arthur");
            Console.WriteLine(countBook);

            Console.WriteLine("7.Получение последней вышедшей книги.");

            Book lastbook = bookRep.GetLastByReleaseYearBook();
            Console.WriteLine(lastbook.Name + " " + lastbook.ReleaseYear.ToString());

            Console.WriteLine("8.Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
            List<Book> booksOrderByName = bookRep.GetBooksOrderByName();
            foreach (Book book in booksOrderByName)
            {
                Console.WriteLine(book.Name);
            }

            Console.WriteLine("9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.");
            List<Book> bookOrderByDescYearRelease = bookRep.GetBooksOrderByDescendingYear();
            foreach (Book book in bookOrderByDescYearRelease)
            {
                Console.WriteLine(book.Name + " " + book.ReleaseYear.ToString());
            }


            Console.ReadKey();


        }
    }
}
