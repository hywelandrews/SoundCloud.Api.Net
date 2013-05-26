namespace SoundCloud.Api.Net.Parameters
{
    internal static class Uri
    {
        internal const string Users             = "/users/";
        internal const string Comments          = "/comments/";
        internal const string Favorites         = "/favorites/";
        internal const string Followings        = "/followings/";
        internal const string Followers         = "/followers/";
        internal const string Tracks            = "/tracks/";
        private const string SharedTo           = "/shared-to/";
        internal const string SharedToUsers     = SharedTo + "users/";
        internal const string SharedToEmails    = SharedTo + "emails/";
        internal const string WebProfiles       = "/web-profiles/";
        internal const string Groups            = "/groups/";
        internal const string Playlists         = "/playlists/";
        internal const string Connections       = "/connections/";
        internal const string Me                = "/me";
        internal const string Activities        = "/activities/";
        internal const string TracksAfiliated   = Tracks + "afiliated/";
        internal const string TracksExclusive   = Tracks + "exclusive/";
        internal const string AllOwn            = "all/own";
        internal const string Apps              = "apps";
    }
}
