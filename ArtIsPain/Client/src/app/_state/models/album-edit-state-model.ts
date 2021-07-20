import { AlbumViewModel } from "../../models/album/AlbumViewModel";
import { UpsertAlbumCommand } from "../../commands/albums/upsert-album-command";

export class AlbumEditStateModel {
    UpsertCommand: UpsertAlbumCommand;
    AlbumEditForm: any;
  AlbumResponse: AlbumViewModel;
  IsReadyForUpsert: boolean;
}
