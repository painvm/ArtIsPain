using System;

namespace ArtIsPain.Server.ViewModels.Band
{
    public class BandPreviewModel : IViewModel
    {
        ///<example>71F08087-D04A-4007-ECFD-08D80D2E91AD</example>
        public Guid Id { get; set; }

        /// <example>David Bowie</example>
        public string Title { get; set; }

        public string TimePeriod { get; set; }
    }
}