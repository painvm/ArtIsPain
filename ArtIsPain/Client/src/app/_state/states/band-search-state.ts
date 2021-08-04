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
import { SearchBandsCommandBuilder } from '../../_builders/command/search-bands-command-builder';
import { SearchBandsCommand } from '../../commands/bands/search.bands.command';

@State<BandSearchStateModel>({
    name: 'bandSearch',
    defaults: {
        Data:  new BandCollectionViewModel(),
        AreBandSearchResultsLoaded: false
    }
})

@Injectable()
export class BandSearchState {
   
    constructor(private bandCollectionService: BandCollectionService,
        private commandBuilder: SearchBandsCommandBuilder) {
        
    }

    @Action(SearchBand)
    getBands(stateContext: StateContext<BandSearchStateModel>, action: SearchBand)
    {
        stateContext.patchState({AreBandSearchResultsLoaded: false})

        const command = this.commandBuilder.Build(action.searchTerm);
        
        this.bandCollectionService.GetAll(command).pipe(take(1)).subscribe(
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
