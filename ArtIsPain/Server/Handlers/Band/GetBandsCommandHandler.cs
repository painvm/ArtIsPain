namespace ArtIsPain.Server.Handlers.Band
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ArtIsPain.Server.Data.Interfaces;
    using ArtIsPain.Server.Handlers;
    using ArtIsPain.Shared.Models;
    using AutoMapper;
    using global::Server.Commands.Band;
    using global::Server.ViewModels.Band;
    using Server.Commands.Band;
    using Server.ViewModels.Band;

    public class GetBandsCommandHandler : BaseGetEntitiesHandler<Band, GetBandsCommand, BandViewModel, BandCollectionViewModel>
    {
        public GetBandsCommandHandler(IMapper autoMapper, IRepository<Band> albumRepository)
            : base(autoMapper, albumRepository)
        {

        }

        protected override async Task<BandCollectionViewModel> Send(GetBandsCommand request, CancellationToken cancellationToken)
        {
            BandCollectionViewModel result = await base.Send(request, cancellationToken);

            return result;

        }

       
    }
}