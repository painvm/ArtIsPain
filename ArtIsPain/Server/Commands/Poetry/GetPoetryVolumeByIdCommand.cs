using ArtIsPain.Server.ViewModels.Poetry;
using System;

namespace ArtIsPain.Server.Commands.Poetry
{
    public class GetPoetryVolumeByIdCommand : IGetEntityByIdCommand<PoetryVolumeViewModel>
    {
        public Guid EntityId { get; set; }
    }
}