import { BandEditStateModel } from '../models/band-edit-state-model';
import { State, Action, StateContext, Selector, NgxsOnInit } from '@ngxs/store';
import { GetBandByIdForEdit } from '../actions/get-band-by-id-for-edit';
import { ApplyBandEditValidationRules } from '../actions/apply-band-edit-validation-rules';
import { UpsertBand } from '../actions/upsert-band';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BandService } from '../../_services/band.service';
import { UpsertBandCommandBuilder } from '../../_builders/command/upsert-band-command-builder';
import { BandEditRuleService } from '../../_rules/band/band-edit-rule-service';
import { UpsertBandFormBuilder } from '../../_builders/form/upsert-band-form-builder';

@State<BandEditStateModel>({
    name: 'bandEdit',
    defaults: {
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
        private commandBuilder: UpsertBandCommandBuilder,
        private ruleService: BandEditRuleService,
        public formBuilder: UpsertBandFormBuilder) {
    }
    ngxsOnInit(ctx?: StateContext<any>) {

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

        if (action.Id != null) {

            this.bandService.GetById(action.Id).subscribe(
                data => {
                    stateContext.patchState({ BandResponse: data })
                });
        }
    }

    @Action(ApplyBandEditValidationRules)
    applyBandEditValidationRules(stateContext: StateContext<BandEditStateModel>, action: ApplyBandEditValidationRules) {

        const form = action.Form;
        this.ruleService.GetRules(form).forEach(x => x.ApplySpecificControlRules());
    }

    @Action(UpsertBand)
    upsertBand(stateContext: StateContext<BandEditStateModel>, action: UpsertBand) {
        const currentState = stateContext.getState();
        const currentForm = currentState.BandEditForm;

        const upsertBandCommand = this.commandBuilder.Build(currentForm, action.EntityId);

        this.bandService.Upsert(upsertBandCommand).subscribe(data => {
            stateContext.patchState({ BandResponse: data });
        })
    }
}
