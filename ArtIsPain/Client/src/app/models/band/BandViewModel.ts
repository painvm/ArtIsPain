import { MusicalAlbumPreviewModel } from '../album/MusicalAlbumPreviewModel';

export class BandViewModel {
    id: string;
    name: string;
    description: string;
    formationDate: Date;
    disbandDate: Date;
    albums: MusicalAlbumPreviewModel[];
}
