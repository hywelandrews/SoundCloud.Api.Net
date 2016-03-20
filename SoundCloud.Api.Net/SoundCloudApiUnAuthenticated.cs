using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using RestSharp.Authenticators;

namespace SoundCloud.Api.Net
{
    public class SoundCloudApiUnAuthenticated : ISoundCloudApiUnAuthenticated, ISoundCloudApiInternal
    {
        private readonly string _clientId;
        private readonly RestClient _client;

        internal SoundCloudApiUnAuthenticated(string clientId)
        {
            _clientId = clientId;
            _client = new RestClient
                {
                    BaseUrl = new System.Uri(Settings.BaseUrl), 
                    Authenticator = GetAuthenticator(_clientId),
                };
        }

        internal SoundCloudApiUnAuthenticated(string clientId, RestClient client)
        {
            _clientId = clientId;
            _client = client;
            _client.Authenticator = GetAuthenticator(_clientId);
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

        public IApps Apps()
        {
            return new Apps(this);
        }

        public IApp App(int appId)
        {
            return new App(appId, this);
        }

        private static IAuthenticator GetAuthenticator(string clientId)
        {
            return new SimpleAuthenticator(
                QueryParameter.ClientId, 
                clientId, 
                String.Empty,
                String.Empty);
        }

        public virtual T Execute<T>(IResource<T> resource) where T : new()
        {
            var response = _client.Execute<T>(resource.GetRequest());

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            CheckResponseStatusCode(response);
            
            return response.Data;
        }

        private static void CheckResponseStatusCode<T>(IRestResponse<T> response) where T : new()
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new Exceptions.ResourceNotFound(response.Request, response.ErrorMessage);
                case HttpStatusCode.InternalServerError:
                    throw new Exceptions.InternalServerError(response.Request, response.ErrorMessage);
                case HttpStatusCode.Forbidden:
                    throw new Exceptions.ResourceForbidden(response.Request, response.ErrorMessage);
                case HttpStatusCode.Unauthorized:
                    throw new Exceptions.Unauthorized(response.Request, response.ErrorMessage);
                case HttpStatusCode.BadRequest:
                    throw new Exceptions.ResourceBadRequest(response.Request, response.ErrorMessage);
            }
        }

        public virtual void ExecuteAsync<T>(IResource<T> resource, Action<T> callback) where T : new()
        {
            _client.ExecuteAsync<T>(resource.GetRequest(), (response) => {   CheckResponseStatusCode(response);
                                                                             callback(response.Data);
            });
        }

        public virtual List<T> Execute<T>(IEnumerable<IResource<T>> resources) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources(resources);
            
            return compositeBuilderResult.Result;
        }

        public virtual void ExecuteAsync<T>(IEnumerable<IResource<T>> resources, Action<List<T>> callback) where T : new()
        {
            var compositeBuilderResult = ExecuteMultipleResources(resources);
            callback(compositeBuilderResult.Result);
        }

        private Task<List<T>> ExecuteMultipleResources<T>(IEnumerable<IResource<T>> resources) where T : new()
        {
            var requests = new List<IRestRequest>((from resource in resources select resource.GetRequest()).ToList());

            var tasks = new List<Task<T>>();

            foreach (var request in requests)
            {
                var currentRequest = request;
                tasks.Add(Task.Factory.StartNew(() =>
                    {
                        var response = _client.Execute<T>(currentRequest);
                        CheckResponseStatusCode(response);
                        return response.Data;
                    } , TaskCreationOptions.LongRunning));
            }

            var compositeBuilderResult = Task.Factory.ContinueWhenAll<T, List<T>>(tasks.ToArray(), CompositeBuilder);
            return compositeBuilderResult;
        }

        private List<T> CompositeBuilder<T>(IEnumerable<Task<T>> taskResults)
        {
            return taskResults.Select(t => t.Result).ToList();
        }
    }
}
