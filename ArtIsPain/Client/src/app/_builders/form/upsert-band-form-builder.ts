import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class UpsertBandFormBuilder {


    constructor(public formBuilder: FormBuilder) {

    }

    public Initialize(): FormGroup {
        const title = this.formBuilder.control(null);
        const biography = this.formBuilder.control(null);
        const formationDate = this.formBuilder.control(null);
        const disbandDate = this.formBuilder.control(null);

        let form = this.formBuilder.group({
            title: title,
            biography: biography,
            formationDate: formationDate,
            disbandDate: disbandDate,
        });

        return form;
    }

    public Populate(form: FormGroup, upsertBandCommand: UpsertBandCommand) {
        form.controls.title.setValue(upsertBandCommand.Name);
        form.controls.formationDate.setValue(upsertBandCommand.FormationDate);
        form.controls.disbandDate.setValue(upsertBandCommand.DisbandDate);
        form.controls.biography.setValue(upsertBandCommand.Description);
    }
}
