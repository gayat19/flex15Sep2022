using MyFirstWebApp.Models;
using MyFirstWebApp.Models.DTOs;

namespace MyFirstWebApp.Services
{
    public class UserService
    {
        private readonly IRepo<string, User> _repo;

        public UserService(IRepo<string,User> repo)
        {
            _repo = repo;
        }
        public  async Task<UserDTO>Register(User user)
        {
            var result = await _repo.Add(user);
            return (UserDTO)result;
        }
        public async Task<bool> Login(User user)
        {
            var result = false;
            var myUser = await _repo.Get(user.Username);
            if (myUser != null)
            {
                if (myUser.Password == user.Password)
                    result = true;
            }
            return result;
        }
    }
}
