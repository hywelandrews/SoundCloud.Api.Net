using System;

namespace SoundCloud.Api.Net.Models
{
    public class Connection
    {
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public int Id { get; set; }
        public bool PostFavorite { get; set; }
        public bool PostPublish { get; set; }
        public string Service { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
