using ArtIsPain.Server.ViewModels.Writer;
using System;

namespace ArtIsPain.Server.Commands.Writers
{
    public class UpsertWriterCommand : IUpsertEntityCommand<WriterViewModel>
    {
        public Guid? EntityId { get; set; }

        public string Title { get; set; }

        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public string Biography { get; set; }
    }
}