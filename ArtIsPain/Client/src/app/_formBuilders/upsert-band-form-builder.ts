import { FormGroup, FormControl } from '@angular/forms';
import { UpsertBandCommand } from '../commands/bands/upsert.band.command';

export class UpsertBandFormBuilder 
{
    static CreateNewForm(upsertBandCommand: UpsertBandCommand) : FormGroup
    {
        const title = new FormControl(upsertBandCommand.Name);
        const biography = new FormControl(upsertBandCommand.Description);
        const formationDate = new FormControl(upsertBandCommand.FormationDate);
        const disbandDate = new FormControl(upsertBandCommand.DisbandDate);

        let form = new FormGroup({
            title: title,
            biography: biography,
            formationDate: formationDate,
            disbandDate: disbandDate,
        });

        return form;
    }
}
