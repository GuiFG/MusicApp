using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MusicAppWeb.Contracts;
using MusicAppWeb.Model;


namespace MusicAppWeb.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private HttpClient _client;
        private string _url;
        
        public MusicRepository(IConfiguration  configuration)
        {
            _client = new HttpClient();
            _url = configuration["UrlApi"];
        }
        
        public async Task<List<Music>> GetAll()
        {
            var musics = new List<Music>();
            try 
            {
                var response = await _client.GetAsync(_url + UrlApi.Music.GetAll);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var data = (JObject) JsonConvert.DeserializeObject(responseString);
                    
                    return data["data"].ToObject<List<Music>>();
                }

                return musics;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return musics;
            }
        }
        public async Task<Music> Upload(Music music)
        {
            try 
            {    
                string content = JsonConvert.SerializeObject(music);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        
                var response = await _client.PostAsync(_url + UrlApi.Music.Upload, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                   
                    return JsonConvert.DeserializeObject<Music>(responseString);
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