using MyFirstWebApp.Models;
using MyFirstWebApp.Models.DTOs;
using Newtonsoft.Json;

namespace MyFirstWebApp.Services
{
    public class UserAPIRepo : IRepo<string, User>
    {
        HttpClient client;
        public UserAPIRepo()
        {
            client = new HttpClient();

        }
        public async Task<User> Add(User item)
        {
            using(client)
            {
                using(var response = await client.PostAsJsonAsync("http://localhost:5298/api/User/Register", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<UserDTO>(responseText);
                        return user;
                    }
                }
            }
            return null;
        }

        public Task<User> Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string key)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
