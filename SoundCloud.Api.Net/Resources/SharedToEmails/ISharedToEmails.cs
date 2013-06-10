using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.SharedToEmails
{
    public interface ISharedToEmails : IGet<List<Models.Email>>, IPut<List<Models.Email>>, IDelete
    {
    }
}
