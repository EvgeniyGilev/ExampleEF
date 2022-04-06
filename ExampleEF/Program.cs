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
            using (var db = new AppEFContext.AppContext())
            {
                var user1 = new User { Name = "Arthur", Email ="Arthur@gmail.com" };
                var user2 = new User { Name = "Evgeniy", Email = "Evgeniy@gmail.com" };
                
                db.Users.Add(user1);
                db.Users.Add(user2);

                db.SaveChanges();
            }

            //проверяем вывод пользователей
            UserRepository userRep = new UserRepository();
            List<User> listUsers = userRep.SelectAllUsers();

            foreach (User _listUser in listUsers)
            {
                Console.WriteLine(_listUser.Name);
            }

            Console.ReadKey();

        }
    }
}
