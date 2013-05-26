namespace SoundCloud.Api.Net.Models
{
    public class OAuth2
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public GrantType GrantType { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }

    public enum GrantType
    {
        authorization_code,
        refresh_token,
        password,
        client_credentials,
        oauth1_token
    }
}
