using System;

namespace SoundCloud.Api.Net.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Uri { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public int Timestamp { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TrackId { get; set; }
    }
}
