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
        public async Task<User> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                
            }
            return null;
        }

        public async Task<User> Delete(string key)
        {
            try
            {
                var user = await Get(key);
                if(user !=null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return null;
        }

        public async Task<User> Get(string key)
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

        public async Task<ICollection<User>> GetAll()
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

        public async Task<User> Update(User item)
        {
            try
            {
                var user = await Get(item.Username);
                if (user != null)
                {
                    user.Password = item.Password;
                    await _context.SaveChangesAsync();
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
