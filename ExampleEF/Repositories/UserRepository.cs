using ExampleEF.AppEFContext;
using ExampleEF.EF;
using System.Collections.Generic;
using System.Linq;

namespace ExampleEF.Repositories
{
    public class UserRepository
    {
        /// <summary>
        /// Добавляем пользователя в БД
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        public void AddUser(string name, string email)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(new User() { Name = name, Email = email });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// вывести всех пользователей в список
        /// </summary>
        /// <returns>A list of Users.</returns>
        public List<User> SelectAllUsers()
        {
            using (var db = new AppContext())
            {
                List<User> allUsers = db.Users.ToList();
                return allUsers;
            }
        }

        /// <summary>
        /// вывести пользователя по его id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An User.</returns>
        public User SelectUserById(int id)
        {
            using (var db = new AppContext())
            {
                User userById = db.Users.Where(u => u.Id == id).FirstOrDefault();
                return userById;
            }
        }

        /// <summary>
        /// Изменяем имя пользователя
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="newName">The new name.</param>
        public void UpdateUserNameById(int id, string newName)
        {
            using (var db = new AppContext())
            {
                User userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);
                if (userToUpdate != null)
                {
                    userToUpdate.Name = newName;
                    db.SaveChanges();
                }
                
            }
        }

        /// <summary>
        /// Удаляем пользователя
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="newName">The new name.</param>
        public void DeleteUserById(int id, string newName)
        {
            using (var db = new AppContext())
            {
                User userForDelete = db.Users.FirstOrDefault(u => u.Id == id);
                if (userForDelete != null)
                {
                    db.Users.Remove(userForDelete);
                    db.SaveChanges();
                }
                
            }
        }
    }
}
