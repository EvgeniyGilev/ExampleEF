using System;
using ExampleEF.EF;
using ExampleEF.Repositories;

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
        }
    }
}
