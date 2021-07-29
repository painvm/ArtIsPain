using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels
{
    public interface ICollectionViewModel<TViewModel>: IResponse where TViewModel: IViewModel
    {
        IEnumerable<TViewModel> Data { get; set; }
    }
}
