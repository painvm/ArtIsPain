using ArtIsPain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Data.Repositories
{
    public class PoetryVolumeRepository : EntityRepository<PoetryVolume, DataContext>
    {
        public PoetryVolumeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}