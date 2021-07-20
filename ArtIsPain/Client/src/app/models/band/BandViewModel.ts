import { AlbumPreviewModel } from '../album/AlbumPreviewModel';
import { IViewModel } from '../../_interfaces/i-view-model';

export class BandViewModel implements IViewModel {
    Id: string;
    Name: string;
    Description: string;
    FormationDate: Date;
    DisbandDate: Date;
    Albums: AlbumPreviewModel[];
}
