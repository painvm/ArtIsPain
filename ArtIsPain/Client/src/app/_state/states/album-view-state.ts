import { State, StateContext, Action, Selector } from '@ngxs/store';
import { AlbumViewStateModel } from '../models/album-view-state-model';
import { GetAlbumById } from '../actions/get-album-by-id';
import { AlbumService } from '../../_services/album.service';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';

@State<AlbumViewStateModel>({
    name: 'albumView',
    defaults: {
        Album: new AlbumViewModel()
    }
})

export class AlbumViewState {

    constructor(private albumService: AlbumService) {

    }

    @Action(GetAlbumById)
    getBandById(stateContext: StateContext<AlbumViewStateModel>, action: GetAlbumById) {
        this.albumService.GetById(action.Id).subscribe(
            data => {
                stateContext.patchState({ Album: data })
            });
    }

    @Selector()
    static getAlbum(state: AlbumViewStateModel) {
        return state.Album;
    }

    @Selector()
    static getAlbumId(state: AlbumViewStateModel) {
        return state.Album.Id;
    }
}
