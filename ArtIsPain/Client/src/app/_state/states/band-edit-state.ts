import { BandEditStateModel } from '../models/band-edit-state-model';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { BandService } from 'src/app/_services/band.service';
import { GetBandByIdForEdit } from '../actions/get-band-by-id-for-edit';
import { FormGroup } from '@angular/forms';

@State<BandEditStateModel>({
    name: 'bandEdit',
    defaults: {
        Band: new UpsertBandCommand(),
        BandEditForm:
        {
            model: new UpsertBandCommand(),
            dirty: false,
            status: '',
            errors: {}
        }
    }
})

export class BandEditState {

    constructor(private bandService: BandService) {
    }

    @Action(GetBandByIdForEdit)
    getBandById(stateContext: StateContext<BandEditStateModel>, action: GetBandByIdForEdit) {
        if (action.Id != null) {

            this.bandService.getById(action.Id).subscribe(
                data => {
                    let upsertBandCommand = new UpsertBandCommand();
                    upsertBandCommand.EntityId = data.Id;
                    upsertBandCommand.Description = data.Description;
                    upsertBandCommand.FormationDate = data.FormationDate ? new Date(data.FormationDate) : null;
                    upsertBandCommand.DisbandDate = data.DisbandDate ? new Date(data.DisbandDate) : null;
                    upsertBandCommand.Name = data.Name;

                    stateContext.patchState({ Band: upsertBandCommand })
                });
        }
    }

    @Selector()
    static getBandToUpsert(state: BandEditStateModel) {
        return state.Band;
    }
}
