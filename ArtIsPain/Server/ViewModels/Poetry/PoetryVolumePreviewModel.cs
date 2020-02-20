using ArtIsPain.Server.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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