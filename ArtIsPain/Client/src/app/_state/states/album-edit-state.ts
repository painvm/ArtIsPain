import { AlbumEditStateModel } from '../models/album-edit-state-model';
import { State, Action, StateContext, Selector, Store } from '@ngxs/store';
import { GetAlbumByIdForEdit } from '../actions/get-album-by-id-for-edit';
import { ApplyAlbumEditValidationRules } from '../actions/apply-album-edit-validation-rules';
import { AlbumEditRuleService } from '../../_rules/album/album-edit-rule-service';
import { AlbumService } from '../../_services/album.service';
import { UpsertAlbumCommand } from '../../commands/albums/upsert-album-command';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { UpsertAlbum } from '../actions/upsert-album';
import { UpsertAlbumCommandBuilder } from '../../_builders/command/upsert-album-command-builder';
import { Navigate } from '@ngxs/router-plugin';
import { BandViewState } from './band-view-state';
import { BandPreviewModel } from '../../models/band/BandPreviewModel';
import { tap, distinctUntilKeyChanged, distinctUntilChanged, map, take } from 'rxjs/operators';
import { GetAlbumById } from '../actions/get-album-by-id';
import { ResetAlbumEditResponse } from '../actions/reset-album-edit-response';


@State<AlbumEditStateModel>({
    name: 'albumEdit',
    defaults: {
        UpsertCommand: new UpsertAlbumCommand(),
        AlbumEditForm: {
            model: { title: null, biography: null, formationDate: null, disbandDate: null, bandId: null, songs: [] },
            dirty: false,
            status: '',
            errors: {}
        },
        AlbumResponse: new AlbumViewModel(),
        IsReadyForUpsert: false
    }
})
export class AlbumEditState {


    constructor(private albumService: AlbumService,
        private ruleService: AlbumEditRuleService,
        private commandBuilder: UpsertAlbumCommandBuilder,
        public store: Store) {

    }

    @Selector()
    static getAlbumResponse(state: AlbumEditStateModel) {
        return state.AlbumResponse;
    }

    @Selector()
    static isAlbumLoaded(state: AlbumEditStateModel) {
        return state.IsReadyForUpsert;
    }

    @Action(ResetAlbumEditResponse)
    resetAlbumEditResponse(stateContext: StateContext<AlbumEditStateModel>) {
        stateContext.patchState({ AlbumResponse: null });
    }

    @Action(GetAlbumByIdForEdit)
    getAlbumForEdit(stateContext: StateContext<AlbumEditStateModel>, action: GetAlbumByIdForEdit) {

        stateContext.patchState({ IsReadyForUpsert: false})

        if (action.Id != null) {

            return this.albumService.GetById(action.Id).pipe(take(1)).subscribe(data => {
                stateContext.patchState({ AlbumResponse: data, IsReadyForUpsert: true })
            })
        }

        else {
            const emptyAlbumModel = new AlbumViewModel();
            emptyAlbumModel.Band = new BandPreviewModel();

            this.store.select(BandViewState.getBandId).pipe(take(1)).subscribe(x => {
                emptyAlbumModel.Band.Id = x
            });
            stateContext.patchState({ AlbumResponse: emptyAlbumModel, IsReadyForUpsert: true, AlbumEditForm: null})
        }
    }

    @Action(ApplyAlbumEditValidationRules)
    applyValidationRules(stateContext: StateContext<AlbumEditStateModel>, action: ApplyAlbumEditValidationRules) {
        const form = action.Form;
        this.ruleService.GetRules(form).forEach(x => x.ApplySpecificControlRules());
    }

    @Action(UpsertAlbum)
    upsertAlbum(stateContext: StateContext<AlbumEditStateModel>, action: UpsertAlbum) {

        stateContext.patchState({ IsReadyForUpsert: false })

        const currentState = stateContext.getState();
        const currentForm = currentState.AlbumEditForm;

        const upsertBandCommand = this.commandBuilder.Build(currentForm, action.EntityId);

        this.albumService.Upsert(upsertBandCommand)
            .pipe(take(1)).subscribe(data => {
                stateContext.patchState({ AlbumResponse: data, IsReadyForUpsert: true })
            })
    }}
