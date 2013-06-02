﻿using System.Collections.Generic;

namespace SoundCloud.Api.Net.Resources.Interfaces
{
    public interface IGroups : ISearchFilter<IGroups>, IGet<List<Models.Group>>
    {
    }
}
