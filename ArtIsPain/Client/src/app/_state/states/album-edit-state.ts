import { AlbumEditStateModel } from '../models/album-edit-state-model';
import { State, Action, StateContext, Selector } from '@ngxs/store';
import { GetAlbumByIdForEdit } from '../actions/get-album-by-id-for-edit';
import { ApplyAlbumEditValidationRules } from '../actions/apply-album-edit-validation-rules';
import { AlbumEditRuleService } from '../../_rules/album/album-edit-rule-service';
import { AlbumService } from '../../_services/album.service';
import { UpsertAlbumCommand } from '../../commands/albums/upsert-album-command';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { UpsertAlbum } from '../actions/upsert-album';
import { UpsertAlbumCommandBuilder } from '../../_builders/command/upsert-album-command-builder';

@State<AlbumEditStateModel>({
    name: 'albumEdit',
    defaults: {
        UpsertCommand: new UpsertAlbumCommand(),
        AlbumEditForm: {
            model: { title: null, biography: null, formationDate: null, disbandDate: null, songs:[] },
            dirty: false,
            status: '',
            errors: {}
        },
        AlbumResponse: new AlbumViewModel()
    }
})
export class AlbumEditState {


    constructor(private albumService: AlbumService,
                private ruleService: AlbumEditRuleService,
                private commandBuilder: UpsertAlbumCommandBuilder) {

    }

    @Selector()
    static getAlbumResponse(state: AlbumEditStateModel) {
        return state.AlbumResponse;
    }

    @Action(GetAlbumByIdForEdit)
    getAlbumForEdit(stateContext: StateContext<AlbumEditStateModel>, action: GetAlbumByIdForEdit) {
        if (action.Id != null) {

            this.albumService.GetById(action.Id).subscribe(
                data => {
                    stateContext.patchState({ AlbumResponse: data })
                });
        }
    }

    @Action(ApplyAlbumEditValidationRules)
    applyValidationRules(stateContext: StateContext<AlbumEditStateModel>, action: ApplyAlbumEditValidationRules) {
        const form = action.Form;
        this.ruleService.GetRules(form).forEach(x => x.ApplySpecificControlRules());
    }

    @Action(UpsertAlbum)
    upsertAlbum(stateContext: StateContext<AlbumEditStateModel>, action: UpsertAlbum){
        const currentState = stateContext.getState();
        const currentForm = currentState.AlbumEditForm;

        const upsertBandCommand = this.commandBuilder.Build(currentForm, action.EntityId);

        this.albumService.Upsert(upsertBandCommand).subscribe(data => {
            stateContext.patchState({ AlbumResponse: data });
        })
    }
}
