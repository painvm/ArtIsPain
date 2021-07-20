import { Injectable } from '@angular/core';
import { Action, StateContext, State, Selector } from '@ngxs/store';
import { GetBandById } from '../actions/get-band-by-id';
import { BandViewStateModel } from '../models/band-view-state-model';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BandService } from '../../_services/band.service';
import { take } from 'rxjs/operators';

@State<BandViewStateModel>({
    name: 'bandView',
    defaults: {
        Band:  new BandViewModel(),
        BandId: null,
        IsBandLoaded: false
    }
})

@Injectable()
export class BandViewState {
   
    constructor(private bandService: BandService) {
        
    }

    @Action(GetBandById)
    getBandById(stateContext: StateContext<BandViewStateModel>, action: GetBandById)
    {
        stateContext.patchState({IsBandLoaded: false})
        
        this.bandService.GetById(action.Id).pipe(take(1)).subscribe(
            data => 
            {
                stateContext.patchState({Band: data, BandId: data.Id, IsBandLoaded: true})
            });
    }

    @Selector()
    static getBand(state: BandViewStateModel){
        return state.Band;
    }

    @Selector()
    static isBandLoaded(state: BandViewStateModel){
        return state.IsBandLoaded;
    }

    @Selector()
    static getBandId(state: BandViewStateModel){
        return state.BandId;
    }
}
