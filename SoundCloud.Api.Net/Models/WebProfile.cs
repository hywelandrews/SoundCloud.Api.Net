using Newtonsoft.Json;

namespace SoundCloud.Api.Net.Models
{
    [JsonObject(MemberSerialization.OptIn, Title = "web_profile")]
    public class WebProfile
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "network")]
        public string Service { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        public string UserName { get; set; }
        public string CreatedAt { get; set; }
    }
}
