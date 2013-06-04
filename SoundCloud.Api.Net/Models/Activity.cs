using System;

namespace SoundCloud.Api.Net.Models
{
    public class Activity
    {
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Tags { get; set; }
        public Track Track { get; set; }
        public Comment Comment { get; set; }
        public Favoriting Favoriting { get; set; }
    }
}