﻿using System.Collections.Generic;
using SoundCloud.Api.Net.Resources.Filters;

namespace SoundCloud.Api.Net.Resources.Tracks
{
    public interface ITracks : 
        IResource<List<Models.Track>>, 
        ISearchFilter<ITracks>, 
        ITagsFilter<ITracks>, 
        IFilterFilter<ITracks>, 
        ILicenseFilter<ITracks>,
        IBpmFilter<ITracks>,
        IDurationFilter<ITracks>,
        ICreatedFilter<ITracks>,
        IIdFilter<ITracks>,
        IGenresFilter<ITracks>,
        ITypesFilter<ITracks>,
        IGet<List<Models.Track>>
    {
    }
}
