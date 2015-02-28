using System;
using Newtonsoft.Json;
using RestSharp.Serializers;
using SoundCloud.Api.Net.Models;

namespace SoundCloud.Api.Net.Serialization
{
    public sealed class SoundCloudJsonSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            ContentType = "text/json";

            if (obj.GetType() == typeof(Activity))
            {
                return JsonConvert.SerializeObject(new { activity = obj }); 
            }

            if (obj.GetType() == typeof(App))
            {
                return JsonConvert.SerializeObject(new { app = obj });
            }

            if (obj.GetType() == typeof(Comment))
            {
                return JsonConvert.SerializeObject(new { comment = obj });
            }

            if (obj.GetType() == typeof(Connection))
            {
                return JsonConvert.SerializeObject(new { connection = obj });
            }

            if (obj.GetType() == typeof(Email))
            {
                return JsonConvert.SerializeObject(new { email = obj });
            }

            if (obj.GetType() == typeof(Favoriting))
            {
                return JsonConvert.SerializeObject(new { favoriting = obj });
            }

            if (obj.GetType() == typeof(Group))
            {
                return JsonConvert.SerializeObject(new { group = obj });
            }

            if (obj.GetType() == typeof(Playlist))
            {
                return JsonConvert.SerializeObject(new { playlist = obj });
            }

            if (obj.GetType() == typeof(Track))
            {
                return JsonConvert.SerializeObject(new { track = obj });
            }

            if (obj.GetType() == typeof(User))
            {
                return JsonConvert.SerializeObject(new { user = obj });
            }

            if (obj.GetType() == typeof(WebProfile))
            {
                return JsonConvert.SerializeObject(new { web_profile = obj });
            }

            throw new Exception("Unable to serialize object type to SoundCloud API");
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
}
