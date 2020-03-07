using ArtIsPain.Shared.Models;
using System;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class PoetryVolumeAuthorshipRepository : MultiAuthorizedEntityRepository<PoetryVolumeAuthorship, DataContext>
    {
        public PoetryVolumeAuthorshipRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override Task<PoetryVolumeAuthorship> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<PoetryVolumeAuthorship> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<PoetryVolumeAuthorship> Upsert(PoetryVolumeAuthorship entity)
        {
            throw new NotImplementedException();
        }
    }
}