import { BandEditStateModel } from '../models/band-edit-state-model';
import { State, Action, StateContext, Selector, NgxsOnInit, Store } from '@ngxs/store';
import { GetBandByIdForEdit } from '../actions/get-band-by-id-for-edit';
import { ApplyBandEditValidationRules } from '../actions/apply-band-edit-validation-rules';
import { UpsertBand } from '../actions/upsert-band';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BandService } from '../../_services/band.service';
import { UpsertBandCommandBuilder } from '../../_builders/command/upsert-band-command-builder';
import { BandEditRuleService } from '../../_rules/band/band-edit-rule-service';
import { UpsertBandFormBuilder } from '../../_builders/form/upsert-band-form-builder';
import { catchError, tap, take } from 'rxjs/operators';
import { Navigate } from '@ngxs/router-plugin';

@State<BandEditStateModel>({
    name: 'bandEdit',
    defaults: {
        BandEditForm: {
            model: { title: null, biography: null, formationDate: null, disbandDate: null },
            dirty: false,
            status: '',
            errors: {}
        },
        BandResponse: new BandViewModel(),
        IsBandLoaded: false
    }
})

export class BandEditState implements NgxsOnInit {

    constructor(private bandService: BandService,
        private commandBuilder: UpsertBandCommandBuilder,
        private ruleService: BandEditRuleService,
        public formBuilder: UpsertBandFormBuilder,
        public store: Store) {
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

    @Selector()
    static isBandLoaded(state: BandEditStateModel) {
        return state.IsBandLoaded;
    }

    @Action(GetBandByIdForEdit)
    getBandById(stateContext: StateContext<BandEditStateModel>, action: GetBandByIdForEdit) {

        stateContext.patchState({ IsBandLoaded: false})

        if (action.Id != null) {

            this.bandService.GetById(action.Id).pipe(take(1)).subscribe(
                data => {
                    stateContext.patchState({ BandResponse: data, IsBandLoaded: true})
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

        stateContext.patchState({ IsBandLoaded: false})

        const upsertBandCommand = this.commandBuilder.Build(currentForm, action.EntityId);

        return this.bandService.Upsert(upsertBandCommand).pipe(
            catchError(() =>{throw Error()}), tap(data => {
            stateContext.patchState({ BandResponse: data});
        }))
}}
