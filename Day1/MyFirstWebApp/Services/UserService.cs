﻿using MyFirstWebApp.Models;

namespace MyFirstWebApp.Services
{
    public class UserService
    {
        private readonly IRepo<string, User> _repo;

        public UserService(IRepo<string,User> repo)
        {
            _repo = repo;
        }
        public bool Register(User user)
        {
            var result = false;
            result = _repo.Add(user)==null?false:true;
            return result;
        }
        public bool Login(User user)
        {
            var result = false;
            var myUser = _repo.Get(user.Username);
            if (myUser != null)
            {
                if (myUser.Password == user.Password)
                    result = true;
            }
            return result;
        }
    }
}