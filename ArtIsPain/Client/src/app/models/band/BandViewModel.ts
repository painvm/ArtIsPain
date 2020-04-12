import { AlbumPreviewModel } from '../album/AlbumPreviewModel';
import { IViewModel } from 'src/app/_interfaces/i-view-model';

export class BandViewModel implements IViewModel {
    Id: string;
    Name: string;
    Description: string;
    FormationDate: Date;
    DisbandDate: Date;
    Albums: AlbumPreviewModel[];
}
