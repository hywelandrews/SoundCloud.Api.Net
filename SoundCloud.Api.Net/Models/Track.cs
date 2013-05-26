using System;

namespace SoundCloud.Api.Net.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public int PlaybackCount { get; set; }
        public int FavoritingsCount { get; set; }
        public bool Downloadable { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Permalink { get; set; }
        public string PermalinkUrl { get; set; }
        public string Uri { get; set; }
        public string Sharing { get; set; }
        public string EmbeddableBy { get; set; }
        public string PurchaseUrl { get; set; }
        public string ArtworkUrl { get; set; }
        public string Description { get; set; }
        public User Label { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int SharedToCount { get; set; }
        public string TagList { get; set; }
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public string Release { get; set; }
        public int ReleaseDay { get; set; }
        public int ReleaseMonth { get; set; }
        public int ReleaseYear { get; set; }
        public bool Streamable { get; set; }
        public string State { get; set; }
        public string License { get; set; }
        public string TrackType { get; set; }
        public string WaveformUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string StreamUrl { get; set; }
        public string VideoUrl { get; set; }
        public int Bpm { get; set; } 
        public bool Commentable { get; set; }
        public string Isrc { get; set; }
        public string KeySignature { get; set; }
        public int CommentCount { get; set; }
        public int DownloadCount { get; set; }
        public string OriginalFormat { get; set; }
        public Int64 OriginalContentSize { get; set; }
        public App CreatedWith { get; set; }
        public byte[] AssetData { get; set; }
        public byte[] ArtworkData { get; set; }
        public bool UserFavorite { get; set; }
    }
}
