import { BandEditStateModel } from '../models/band-edit-state-model';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { State, Action, StateContext, Selector, NgxsOnInit } from '@ngxs/store';
import { BandService } from 'src/app/_services/band.service';
import { GetBandByIdForEdit } from '../actions/get-band-by-id-for-edit';
import { BandEditRules } from 'src/app/_rules/band/band-edit-rules';
import { UpsertBandFormBuilder } from 'src/app/_builders/form/upsert-band-form-builder';
import { ApplyBandEditValidationRules } from '../actions/apply-band-edit-validation-rules';
import { UpsertBand } from '../actions/upsert-band';
import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { BandViewModel } from 'src/app/models/band/BandViewModel';

@State<BandEditStateModel>({
    name: 'bandEdit',
    defaults: {
        UpsertCommand: new UpsertBandCommand(),
        BandEditForm: {
            model: { title: null, biography: null, formationDate: null, disbandDate: null },
            dirty: false,
            status: '',
            errors: {}
        },
        BandResponse: new BandViewModel()
    }
})

export class BandEditState implements NgxsOnInit {

    constructor(private bandService: BandService,
        public formBuilder: UpsertBandFormBuilder) {
    }
    ngxsOnInit(ctx?: StateContext<any>) {

    }

    @Selector()
    static getBand(state: BandEditStateModel) {
        return state.UpsertCommand;
    }

    @Selector()
    static getForm(state: BandEditStateModel) {
        return state.BandEditForm;
    }

    @Selector()
    static getBandResponse(state: BandEditStateModel) {
        return state.BandResponse;
    }

    @Action(GetBandByIdForEdit)
    getBandById(stateContext: StateContext<BandEditStateModel>, action: GetBandByIdForEdit) {

        const upsertBandCommand = new UpsertBandCommand();

        if (action.Id != null) {

            this.bandService.getById(action.Id).subscribe(
                data => {
                    upsertBandCommand.EntityId = data.Id;
                    upsertBandCommand.Description = data.Description;
                    upsertBandCommand.FormationDate = data.FormationDate ? new Date(data.FormationDate) : null;
                    upsertBandCommand.DisbandDate = data.DisbandDate ? new Date(data.DisbandDate) : null;
                    upsertBandCommand.Name = data.Name;

                    stateContext.patchState({ UpsertCommand: upsertBandCommand })
                });
        }
    }

    @Action(ApplyBandEditValidationRules)
    applyBandEditValidationRules(stateContext: StateContext<BandEditStateModel>, action: ApplyBandEditValidationRules) {

        const form = action.Form
        BandEditRules.GetRules(form).forEach(x => x.ApplySpecificControlRules());
    }

    @Action(UpsertBand)
    upsertBand(stateContext: StateContext<BandEditStateModel>, action: UpsertBand) {
        const currentState = stateContext.getState();

        const currentForm = currentState.BandEditForm;
        const bandToUpsert = currentForm.model;

        const upsertBandCommand = new UpsertBandCommand();

        upsertBandCommand.Name = bandToUpsert.title;
        upsertBandCommand.FormationDate = bandToUpsert.formationDate;
        upsertBandCommand.DisbandDate = bandToUpsert.disbandDate;
        upsertBandCommand.Description = bandToUpsert.biography;
        upsertBandCommand.EntityId = currentState.UpsertCommand.EntityId;

        this.bandService.upsert(upsertBandCommand).subscribe(data => {
            stateContext.patchState({ BandResponse: data });
        })
    }
}
