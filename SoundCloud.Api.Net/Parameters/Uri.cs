﻿namespace SoundCloud.Api.Net.Parameters
{
    internal static class Uri
    {
        private const string SharedTo = "/shared-to/";

        internal const string Users             = "/users/";
        internal const string Comments          = "/comments/";
        internal const string Favorites         = "/favorites/";
        internal const string Followings        = "/followings/";
        internal const string Followers         = "/followers/";
        internal const string Tracks            = "/tracks/";
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
        internal const string Apps              = "/apps/";
        internal const string Moderators        = "/moderators/";
        internal const string Members           = "/members/";
        internal const string Contributors      = "/contributors/";
        internal const string PendingTracks     = "/pending_tracks/";
        internal const string Contributions     = "/contributions/";
    }
}
