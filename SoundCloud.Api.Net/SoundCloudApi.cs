using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SoundCloud.Api.Net.Configuration;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources;
using SoundCloud.Api.Net.Resources.App;
using SoundCloud.Api.Net.Resources.Apps;
using SoundCloud.Api.Net.Resources.Comment;
using SoundCloud.Api.Net.Resources.Comments;
using SoundCloud.Api.Net.Resources.Group;
using SoundCloud.Api.Net.Resources.Groups;
using SoundCloud.Api.Net.Resources.Me;
using SoundCloud.Api.Net.Resources.Playlist;
using SoundCloud.Api.Net.Resources.Playlists;
using SoundCloud.Api.Net.Resources.Track;
using SoundCloud.Api.Net.Resources.Tracks;
using SoundCloud.Api.Net.Resources.User;
using SoundCloud.Api.Net.Resources.Users;

namespace SoundCloud.Api.Net
{
    public class SoundCloudApi : ISoundCloudApi, ISoundCloudApiInternal
    {
        private readonly string _clientId;
        private readonly string _secretKey;
        private readonly RestClient _client;

        internal SoundCloudApi(string clientId, string secretKey)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _client = new RestClient
                {
                    BaseUrl = Settings.BaseUrl,
                    Authenticator = GetAuthenticator(_clientId, _secretKey)
                };
        }

        internal SoundCloudApi(string clientId, string secretKey, RestClient client)
        {
            _clientId = clientId;
            _secretKey = secretKey;
            _client = client;
            _client.Authenticator = GetAuthenticator(_clientId, _secretKey);
        }
     
        public IUser User()
        {
            return new User(this);
        }

        public IUser User(int userId)
        {
            return new User(userId, this);
        }

        public IUsers Users()
        {
            return new Users(this);
        }

        public ITrack Track(int trackId)
        {
            return new Track(trackId, this);
        }

        public ITracks Tracks()
        {
            return new Tracks(this);
        }

        public IPlaylist Playlist(int playlistId)
        {
            return new Playlist(playlistId, this);
        }

        public IPlaylists Playlists()
        {
            return new Playlists(this);
        }

        public IGroups Groups()
        {
            return new Groups(this);
        }

        public IGroup Group(int groupId)
        {
            return new Group(groupId, this);
        }

        public IComments Comments()
        {
            return new Comments(this);
        }

        public IComment Comment(int commentId)
        {
            return new Comment(commentId, this);
        }

        public IMe Me()
        {
            return new Me(this);
        }

        public IApps Apps()
        {
            return new Apps(this);
        }

        public IApp App(int appId)
        {
            return new App(appId, this);
        }

        private static IAuthenticator GetAuthenticator(string clientId, string secretKey)
        {
            return new SimpleAuthenticator(QueryParameter.ClientId, clientId, QueryParameter.Consumerkey,
                                                            secretKey);
        }

        public T Execute<T>(IResource<T> resource) where T : new()
        {
            var response = _client.Execute<T>(resource.GetRequest());

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response.Data;
        }

        public void ExecuteAsync<T>(IResource<T> resource, Action<T> callback) where T : new()
        {
            _client.ExecuteAsync<T>(resource.GetRequest(), (response) => callback(response.Data));
        }

        public List<T> Execute<T>(IEnumerable<IResource<T>> resources) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources<T>(resources);

            return compositeBuilderResult.Result;
        }

        public void ExecuteAsync<T>(IEnumerable<IResource<T>> resources, Action<List<T>> callback) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources<T>(resources);
            callback(compositeBuilderResult.Result);
        }

        private Task<List<T>> ExecuteMultipleResources<T>(IEnumerable<IResource<T>> resources) where T : new()
        {
            var requests = new List<IRestRequest>((from resource in resources select resource.GetRequest()).ToList());

            var tasks = new List<Task<T>>();

            foreach (var request in requests)
            {
                IRestRequest currentRequest = request;
                tasks.Add(Task.Factory.StartNew(() => _client.Execute<T>(currentRequest).Data, TaskCreationOptions.LongRunning));
            }

            var compositeBuilderResult = Task.Factory.ContinueWhenAll<T, List<T>>(tasks.ToArray(), compositeBuilder);
            return compositeBuilderResult;
        }

        private List<T> compositeBuilder<T>(IEnumerable<Task<T>> taskResults)
        {
            return taskResults.Select(t => t.Result).ToList();
        }
    }
}
