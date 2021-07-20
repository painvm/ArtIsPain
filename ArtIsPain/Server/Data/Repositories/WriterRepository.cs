using ArtIsPain.Shared.Models;

namespace ArtIsPain.Server.Data.Repositories
{
    public class WriterRepository : EntityRepository<Writer, DataContext>
    {
        public WriterRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}