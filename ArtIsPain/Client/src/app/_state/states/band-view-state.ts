import { Injectable } from '@angular/core';
import { BandService } from 'src/app/_services/band.service';
import { Action, StateContext, State, Selector } from '@ngxs/store';
import { GetBandById } from '../actions/get-band-by-id';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { BandViewStateModel } from '../models/band-view-state-model';

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
        this.bandService.getById(action.Id).subscribe(
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
