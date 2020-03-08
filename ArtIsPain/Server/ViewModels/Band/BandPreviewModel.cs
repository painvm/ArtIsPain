using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.ViewModels.Band
{
    public class BandPreviewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TimePeriod { get; set; }
    }
}