using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources.Comment
{
    internal class Comment : ResourceBase<Models.Comment, IComment>, IComment
    {
        internal Comment(RestRequest request, int commentId, ISoundCloudApiInternal soundCloudApi) : base(soundCloudApi)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Comments + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, commentId, ParameterType.UrlSegment);
        }
    }
}
