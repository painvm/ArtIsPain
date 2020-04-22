import { Injectable } from '@angular/core';
import { BandService } from 'src/app/_services/band.service';
import { Action, StateContext, State } from '@ngxs/store';
import { GetBandById } from '../actions/get-band-by-id';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { BandViewStateModel } from '../models/band-view-state-model';

@State<BandViewStateModel>({
    name: 'bandView',
    defaults: {
        Band:  new BandViewModel()
    }
})

@Injectable()
export class BandViewState {
   
    constructor(private bandService: BandService) {
        
    }

    @Action(GetBandById)
    getBandById(stateContext: StateContext<BandViewStateModel>, action: GetBandById)
    {
        let band = new BandViewModel();

        this.bandService.getById(action.bandId).subscribe(
            data => band = data);

        stateContext.patchState({Band: band})
    }
}
