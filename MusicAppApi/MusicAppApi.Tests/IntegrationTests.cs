using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using MusicAppApi;

namespace MusicAppApi.Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient httpClient;
        private string token;
        public IntegrationTests(WebApplicationFactory<Api.Startup> factory)
        {
            httpClient = factory.CreateClient();
        }

        [Fact]
        private async Task GetToken()
        {
            var response = await httpClient.GetAsync("Users/login");
            
            Console.WriteLine("Ola que tal?");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(stringResponse);

            Assert.Equal("fdsalkjfhasdlkfjhasdlkjfhasdl", stringResponse);
        }

        [Fact]
        private async Task GetToken2()
        {
            var response = await httpClient.GetAsync("Users/login");
            
            Console.WriteLine("Ola que tal?");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(stringResponse);

            Assert.Equal("fdsalkjfhasdlkfjhasdlkjfhasdl", stringResponse);
        }
    }
}
