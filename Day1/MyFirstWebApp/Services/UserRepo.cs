using MyFirstWebApp.Models;
using System.Diagnostics;

namespace MyFirstWebApp.Services
{
    public class UserRepo : IRepo<string, User>
    {
        readonly PizzaStroreContext _context;
        public UserRepo(PizzaStroreContext context)
        {
            _context = context;
        }
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                
            }
            return null;
        }

        public User Delete(string key)
        {
            try
            {
                var user = Get(key);
                if(user !=null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return null;
        }

        public User Get(string key)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == key);
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return null;
        }

        public ICollection<User> GetAll()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count == 0)
                    return null;
                return users;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return null;
        }

        public User Update(User item)
        {
            try
            {
                var user = Get(item.Username);
                if (user != null)
                {
                    user.Password = item.Password;
                    _context.SaveChanges();
                    return item;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return null;
        }
    }
}
