﻿namespace SoundCloud.Api.Net.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Permalink { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string FullName { get; set; }
        public string PermalinkUrl { get; set; }
        public string AvatarUrl { get; set; }
        public string Uri { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string DiscogsName { get; set; }
        public string MyspaceName { get; set; }
        public int FollowingsCount { get; set; }
        public int FollowersCount { get; set; }
        public string Website { get; set; }
        public string WebsiteTitle { get; set; }
        public bool Online { get; set; }
        public int TrackCount { get; set; }
        public int PlaylistCount { get; set; }
        public string Plan { get; set; }
        public int PublicFavoritesCount { get; set; }
        public byte[] AvatarData { get;  set; }
    }
}
