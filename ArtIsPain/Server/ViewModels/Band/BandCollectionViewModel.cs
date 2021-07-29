using System.Collections.Generic;
using ArtIsPain.Server.ViewModels;
using ArtIsPain.Server.ViewModels.Band;

namespace Server.ViewModels.Band
{
    public class BandCollectionViewModel : ICollectionViewModel<BandViewModel>
    {
        public IEnumerable<BandViewModel> Data {get; set;}
    }
}