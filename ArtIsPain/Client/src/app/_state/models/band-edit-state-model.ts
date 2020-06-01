import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { BandViewModel } from 'src/app/models/band/BandViewModel';

export class BandEditStateModel {
    BandEditForm: any;
    BandResponse: BandViewModel;
}
