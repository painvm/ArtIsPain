import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { BaseEditResolver } from './base-edit-resolver';
import { Store, Select } from '@ngxs/store';
import { GetAlbumById } from '../_state/actions/get-album-by-id';
import { GetAlbumByIdForEdit } from '../_state/actions/get-album-by-id-for-edit';
import { AlbumViewState } from '../_state/states/album-view-state';
import { Observable } from 'rxjs';

export class AlbumEditResolver extends BaseEditResolver<AlbumViewModel>
{
    @Select(AlbumViewState.getAlbumId) entityId$ : Observable<string>;

    constructor(store: Store) {
        super(store, new GetAlbumByIdForEdit());
    }
}
