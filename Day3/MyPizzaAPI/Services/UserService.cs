using MyPizzaAPI.Models;
using MyPizzaAPI.Models.DTOs;

namespace MyPizzaAPI.Services
{
    public class UserService
    {
        private readonly IRepo<string, User> _repo;
        private readonly TokenService _tokenService;

        public UserService(IRepo<string, User> repo,TokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public UserDTO Register(User user)
        {
            var result = false;
            result = _repo.Add(user) == null ? false : true;
           if(result)
            {
                return new UserDTO { Username = user.Username, Token = _tokenService.CreateToken(user) };
            }
            return null;
        }
        public UserDTO Login(User user)
        {
            var result = false;
            var myUser = _repo.Get(user.Username);
            if (myUser != null)
            {
                if (myUser.Password == user.Password)
                    result = true;
                if (result)
                {
                    return new UserDTO { Username = user.Username, Token = _tokenService.CreateToken(user) };
                }
            }
            return null;
        }
    }
}
