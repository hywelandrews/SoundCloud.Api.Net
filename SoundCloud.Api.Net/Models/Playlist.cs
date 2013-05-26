using System;

namespace SoundCloud.Api.Net.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public DateTime  CreatedAt { get; set; }     
        public int Userid { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string PermalinkUrl { get; set; }
        public string Uri { get; set; }
        public string Sharing { get; set; }
        public string EmbeddableBy { get; set; }
        public string PurchaseUrl { get; set; }	
        public string ArtworkUrl { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int SharedToCount { get; set; }
        public string TagList { get; set; }
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public int Release { get; set; }
        public int ReleaseDay { get; set; }
        public int ReleaseMonth { get; set; }
        public int ReleaseYear { get; set; }
        public Boolean Streamable { get; set; }
        public Boolean Downloadable { get; set; }
        public string Ean { get; set; }
        public string PlaylistType { get; set; }
    }
}
