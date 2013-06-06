using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.App
{
    internal class App : ResourceBase<Models.App, IApp>, IApp
    {
        private readonly ISoundCloudApiInternal _soundCloudApi;
        public App(int appId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            _soundCloudApi = soundCloudApi;
            Request.Resource = Request.Resource + string.Format(Uri.Apps + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, appId, ParameterType.UrlSegment);
        }

        public Tracks.Tracks Tracks()
        {
            return new Tracks.Tracks(Request, _soundCloudApi);
        }
    }
}
