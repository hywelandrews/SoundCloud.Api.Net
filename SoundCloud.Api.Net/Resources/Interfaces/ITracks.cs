using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface ITracks : 
        IResource<List<Models.Track>>, 
        ISearchFilter<ITracks>, 
        ITagsFilter<ITracks>, 
        IFilterFilter<ITracks>, 
        ILicenseFilter<ITracks>,
        IGet<List<Models.Track>>
    {
    }
}
