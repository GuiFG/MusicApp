using System.ComponentModel.DataAnnotations;

namespace MusicAppApi.Model 
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    
    }
}