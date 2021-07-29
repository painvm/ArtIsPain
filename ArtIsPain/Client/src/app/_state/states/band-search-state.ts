import { Injectable } from '@angular/core';
import { Action, StateContext, State, Selector } from '@ngxs/store';
import { GetBandById } from '../actions/get-band-by-id';
import { BandViewStateModel } from '../models/band-view-state-model';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BandService } from '../../_services/band.service';
import { BandSearchStateModel } from '../models/band-search-state-model';
import { take } from 'rxjs/operators';
import { BandCollectionViewModel } from '../../models/band/BandCollectionViewModel';
import { SearchBand } from '../actions/search-bands';
import { BandCollectionService } from '../../_services/band-collection-service';

@State<BandSearchStateModel>({
    name: 'bandSearch',
    defaults: {
        Data:  new BandCollectionViewModel(),
        AreBandSearchResultsLoaded: false
    }
})

@Injectable()
export class BandSearchState {
   
    constructor(private bandCollectionService: BandCollectionService) {
        
    }

    @Action(SearchBand)
    getBands(stateContext: StateContext<BandSearchStateModel>, action: SearchBand)
    {
        stateContext.patchState({AreBandSearchResultsLoaded: false})
        
        this.bandCollectionService.GetAll().pipe(take(1)).subscribe(
            data => 
            {
                stateContext.patchState({Data: data, AreBandSearchResultsLoaded: true})
            });
    }

    @Selector()
    static getBandSearchResults(state: BandSearchStateModel){
        return state.Data;
    }

    @Selector()
    static areBandSearchResultsLoaded(state: BandSearchStateModel){
        return state.AreBandSearchResultsLoaded;
    }
}
