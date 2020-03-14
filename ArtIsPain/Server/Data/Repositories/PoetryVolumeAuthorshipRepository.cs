using ArtIsPain.Shared.Models;
using System;
using System.Linq;
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

        public override IQueryable<PoetryVolumeAuthorship> GetById(Guid id, Func<IQueryable<PoetryVolumeAuthorship>, IQueryable<PoetryVolumeAuthorship>> include = null)
        {
            throw new NotImplementedException();
        }

        public override Task<PoetryVolumeAuthorship> Upsert(PoetryVolumeAuthorship entity, Func<IQueryable<PoetryVolumeAuthorship>, IQueryable<PoetryVolumeAuthorship>> addJoinStatement = null)
        {
            throw new NotImplementedException();
        }
    }
}