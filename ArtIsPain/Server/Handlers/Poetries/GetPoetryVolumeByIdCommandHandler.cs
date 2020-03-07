using ArtIsPain.Server.Commands.Poetry;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.ViewModels.Poetry;
using ArtIsPain.Shared.Models;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Handlers.Poetries
{
    public class GetPoetryVolumeByIdCommandHandler : BaseGetEntityByIdHandler<PoetryVolume, GetPoetryVolumeByIdCommand, PoetryVolumeViewModel>
    {
        public GetPoetryVolumeByIdCommandHandler(
            IMapper autoMapper,
            IRepository<PoetryVolume> entityRepository) : base(autoMapper, entityRepository)
        {
        }

        public override async Task<PoetryVolumeViewModel> Handle(GetPoetryVolumeByIdCommand request, CancellationToken cancellationToken)
        {
            PoetryVolumeViewModel result = await base.Handle(request, cancellationToken);

            return result;
        }
    }
}