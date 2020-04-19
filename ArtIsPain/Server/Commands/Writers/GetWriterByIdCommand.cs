using ArtIsPain.Server.ViewModels.Writer;
using System;

namespace ArtIsPain.Server.Commands.Writers
{
    public class GetWriterByIdCommand : IGetEntityByIdCommand<WriterViewModel>
    {
        public Guid EntityId { get; set; }
    }
}