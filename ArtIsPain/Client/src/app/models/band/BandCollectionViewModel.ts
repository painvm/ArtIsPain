import { IResponse } from '../../_interfaces/i-response';
import { IViewModel } from '../../_interfaces/i-view-model';
import { BandPreviewModel } from './BandPreviewModel';

export class BandCollectionViewModel implements IViewModel  {
    Id: string;
    Data: BandPreviewModel[];
}
