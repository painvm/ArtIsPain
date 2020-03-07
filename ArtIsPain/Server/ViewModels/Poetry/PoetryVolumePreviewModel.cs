using ArtIsPain.Server.ViewModels.Writer;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Poetry
{
    public class PoetryVolumePreviewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        public IEnumerable<WriterPreview> Authors { get; set; }
    }
}