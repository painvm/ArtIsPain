using ArtIsPain.Server.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.Commands
{
    public interface IGetEntitiesCommand<TViewModel, TResponse> : IRequest<TResponse> where TResponse : ICollectionViewModel<TViewModel>
                                                                                      where TViewModel: IViewModel
    {
        string SearchTerm { get; set; }
    }
}