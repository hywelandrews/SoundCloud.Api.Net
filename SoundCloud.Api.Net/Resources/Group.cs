using RestSharp;
using SoundCloud.Api.Net.Parameters;

namespace SoundCloud.Api.Net.Resources
{
    internal class Group : ResourceBase<Models.Group>
    { 
        internal Group(RestRequest request, string groupId)
        {
            Request = request;
            Request.Resource = Request.Resource + string.Format(Uri.Groups + "{{{0}}}", UrlParameter.Id);
            Request.AddParameter(UrlParameter.Id, groupId, ParameterType.UrlSegment);
        }
    }
}
