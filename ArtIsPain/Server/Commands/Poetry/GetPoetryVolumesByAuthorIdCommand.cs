﻿using ArtIsPain.Server.ViewModels.Poetry;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands.Poetry
{
    public class GetPoetryVolumesByAuthorIdCommand : IGetEntitiesByAuthorIdCommand<IEnumerable<PoetryVolumeViewModel>>
    {
        public Guid AuthorId { get; set; }
    }
}