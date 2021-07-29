using System;

namespace ArtIsPain.Server.ViewModels
{
    public interface IViewModel: IResponse
    {
        public Guid Id { get; set; }
    }
}