using ArtIsPain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class WriterRepository : EntityRepository<Writer, DataContext>
    {
        public WriterRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}