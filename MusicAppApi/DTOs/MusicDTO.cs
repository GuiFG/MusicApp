using System;
using System.ComponentModel.DataAnnotations;

namespace MusicAppApi.Model 
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public int Time { get; set; }
        public int Played { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}