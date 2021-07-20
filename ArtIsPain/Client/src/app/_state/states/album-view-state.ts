import { State, StateContext, Action, Selector, Store } from '@ngxs/store';
import { AlbumViewStateModel } from '../models/album-view-state-model';
import { GetAlbumById } from '../actions/get-album-by-id';
import { AlbumService } from '../../_services/album.service';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { Navigate } from '@ngxs/router-plugin';
import { AlbumEditState } from './album-edit-state';
import { ResetAlbumEditResponse } from '../actions/reset-album-edit-response';

@State<AlbumViewStateModel>({
    name: 'albumView',
    defaults: {
        Album: new AlbumViewModel(),
        IsAlbumLoaded: false
    }
})

export class AlbumViewState {

    constructor(private albumService: AlbumService, private store: Store) {

    }

    @Action(GetAlbumById)
    getAlbumById(stateContext: StateContext<AlbumViewStateModel>, action: GetAlbumById) {

        stateContext.patchState({IsAlbumLoaded: false})

        this.albumService.GetById(action.Id).subscribe(
            data => {
                stateContext.patchState({ Album: data, IsAlbumLoaded: true })
            });
    }

    @Selector()
    static getAlbum(state: AlbumViewStateModel) {
        return state.Album;
    }

    @Selector()
    static isAlbumLoaded(state: AlbumViewStateModel) {
        return state.IsAlbumLoaded;
    }

    @Selector()
    static getAlbumId(state: AlbumViewStateModel) {
        return state.Album.Id;
    }
}
