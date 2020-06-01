import { Injectable } from '@angular/core';
import { Action, StateContext, State, Selector } from '@ngxs/store';
import { GetBandById } from '../actions/get-band-by-id';
import { BandViewStateModel } from '../models/band-view-state-model';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BandService } from '../../_services/band.service';

@State<BandViewStateModel>({
    name: 'bandView',
    defaults: {
        Band:  new BandViewModel(),
        BandId: null
    }
})

@Injectable()
export class BandViewState {
   
    constructor(private bandService: BandService) {
        
    }

    @Action(GetBandById)
    getBandById(stateContext: StateContext<BandViewStateModel>, action: GetBandById)
    {
        this.bandService.GetById(action.Id).subscribe(
            data => 
            {
                stateContext.patchState({Band: data, BandId: data.Id})
            });
    }

    @Selector()
    static getBand(state: BandViewStateModel){
        return state.Band;
    }

    @Selector()
    static getBandId(state: BandViewStateModel){
        return state.BandId;
    }
}
