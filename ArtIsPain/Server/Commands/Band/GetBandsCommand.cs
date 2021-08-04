using System;
using ArtIsPain.Server.Commands;
using ArtIsPain.Server.ViewModels.Band;
using Server.ViewModels.Band;

namespace Server.Commands.Band
{
    public class GetBandsCommand : IGetEntitiesCommand<BandViewModel, BandCollectionViewModel>
    {
        public string SearchTerm {get; set;}
    }
}