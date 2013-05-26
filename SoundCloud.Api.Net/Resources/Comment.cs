using RestSharp;
using SoundCloud.Api.Net.Parameters;
using SoundCloud.Api.Net.Resources.Interfaces;

namespace SoundCloud.Api.Net.Resources
{
    internal class Comment : ResourceBase<Models.Comment>, IComment
    {
        internal Comment(RestRequest request, int commentId)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Comments + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, commentId, ParameterType.UrlSegment);
        }
    }
}
