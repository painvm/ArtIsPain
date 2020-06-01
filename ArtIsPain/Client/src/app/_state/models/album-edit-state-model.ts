import { UpsertAlbumCommand } from 'src/app/commands/albums/upsert-album-command';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';

export class AlbumEditStateModel {
    UpsertCommand: UpsertAlbumCommand;
    AlbumEditForm: any;
    AlbumResponse: AlbumViewModel;
}
