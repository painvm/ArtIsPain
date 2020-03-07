using ArtIsPain.Server.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.Commands.Writers
{
    public class GetWriterByIdCommand : IGetEntityByIdCommand<WriterViewModel>
    {
        public Guid EntityId { get; set; }
    }
}