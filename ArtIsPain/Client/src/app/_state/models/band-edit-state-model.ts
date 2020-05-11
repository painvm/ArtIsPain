import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { FormGroup } from '@angular/forms';

export class BandEditStateModel 
{
    Band: UpsertBandCommand;
    BandEditForm: any;
}
