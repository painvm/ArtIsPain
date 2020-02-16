using ArtIsPain.Server.Dtos.Band;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands.Band
{
    public class UpsertBandCommand : IRequest<BandResult>
    {
        public Guid? Id { get; set; }

        public string Description { get; set; }

        public DateTime FormationDate { get; set; }

        public DateTime? DisbandDate { get; set; }

        public string Name { get; set; }
    }
}