import { AlbumPreviewModel } from '../album/AlbumPreviewModel';

export class BandViewModel {
    id: string;
    name: string;
    description: string;
    formationDate: Date;
    disbandDate: Date;
    albums: AlbumPreviewModel[];
}
