using System;

namespace ArtIsPain.Server.Dtos.Band
{
    public class BandResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime FormationDate { get; set; }

        public DateTime? DisbandDate { get; set; }
    }
}