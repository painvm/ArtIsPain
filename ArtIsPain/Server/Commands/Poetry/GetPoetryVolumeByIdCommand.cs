using System;
using ArtIsPain.Server.ViewModels.Poetry;

namespace ArtIsPain.Server.Commands.Poetry
{
    public class GetPoetryVolumeByIdCommand : IGetEntityByIdCommand<PoetryVolumeViewModel>
    {
        public Guid EntityId { get; set; }
    }
}