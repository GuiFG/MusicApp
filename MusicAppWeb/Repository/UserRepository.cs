using System;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;


namespace MusicAppWeb.Repository
{
    public class UserRepository : IUserRepository
    {
        private HttpClient _client;
        private string _url;
        
        public UserRepository(IConfiguration  configuration)
        {
            _client = new HttpClient();
            _url = configuration["UrlApi"];
        }
        public async Task<User> Authenticate(User user)
        {
            try 
            {    
                string content = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        
                var response = await _client.PostAsync(_url + UrlApi.User.Authenticate, httpContent);
                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                   
                    return JsonConvert.DeserializeObject<User>(responseString);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;   
            }
        }

        public async Task<User> SignUp(User user)
        {
            try 
            {    
                string content = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(_url + UrlApi.User.SignUp, httpContent);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<User>(responseString);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;   
            }
        }
    }
}