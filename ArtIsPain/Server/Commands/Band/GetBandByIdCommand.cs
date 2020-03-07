using ArtIsPain.Server.ViewModels.Band;
using System;

namespace ArtIsPain.Server.Commands.Band
{
    public class GetBandByIdCommand : IGetEntityByIdCommand<BandViewModel>
    {
        public Guid EntityId { get; set; }
    }
}