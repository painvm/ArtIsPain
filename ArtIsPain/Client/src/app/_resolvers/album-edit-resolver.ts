import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { BaseEditResolver } from './base-edit-resolver';
import { Store } from '@ngxs/store';
import { GetAlbumById } from '../_state/actions/get-album-by-id';

export class AlbumEditResolver extends BaseEditResolver<AlbumViewModel>
{
    constructor(store: Store) {
        super(store, new GetAlbumById());
    }
}
