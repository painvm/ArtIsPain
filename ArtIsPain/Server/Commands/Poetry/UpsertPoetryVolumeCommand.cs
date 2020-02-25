using ArtIsPain.Server.ViewModels.Poetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands.Poetry
{
    public class UpsertPoetryVolumeCommand : IUpsertAuthorizedEntityCommand<PoetryVolumeViewModel>
    {
        public Guid? EntityId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime PublicationDate { get; set; }

        public IEnumerable<Guid> AuthorIds { get; set; }
    }
}