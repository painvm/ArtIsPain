using ArtIsPain.Server.ViewModels.Writer;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Poetry
{
    public class PoetryVolumeViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime PublicationDate { get; set; }

        public IEnumerable<WriterPreview> Authors { get; set; }
    }
}