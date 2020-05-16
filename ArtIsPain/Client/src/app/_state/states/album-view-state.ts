import { State, StateContext, Action, Selector } from '@ngxs/store';
import { AlbumViewStateModel } from '../models/album-view-state-model';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';
import { AlbumService } from 'src/app/_services/album.service';
import { GetAlbumById } from '../actions/get-album-by-id';

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
        this.albumService.getById(action.Id).subscribe(
            data => {
                stateContext.patchState({ Album: data })
            });
    }

    @Selector()
    static getAlbum(state: AlbumViewStateModel) {
        return state.Album;
    }
}
