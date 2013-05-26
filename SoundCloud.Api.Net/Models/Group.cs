using System;

namespace SoundCloud.Api.Net.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Permalink { get; set; }
        public string PermalinkUrl { get; set; }
        public string ArtworkUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public User Creator { get; set; }
    }
}
