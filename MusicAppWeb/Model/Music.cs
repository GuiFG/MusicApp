using System;
using Newtonsoft.Json;

namespace MusicAppWeb.Model 
{
    public class Music 
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("file")]
        public string File { get; set; }
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("played")]
        public int Played { get; set; }
        [JsonProperty("likes")]
        public int Likes { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}