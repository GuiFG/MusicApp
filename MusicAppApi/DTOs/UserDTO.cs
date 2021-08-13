using System.ComponentModel.DataAnnotations;

namespace MusicAppApi.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}