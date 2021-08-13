using System;
using System.ComponentModel.DataAnnotations;

namespace MusicAppApi.Model 
{
    public class Music 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string File { get; set; }
        [Required]
        public string Lyrics { get; set; }
        public int Time { get; set; }
        public int Played { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}