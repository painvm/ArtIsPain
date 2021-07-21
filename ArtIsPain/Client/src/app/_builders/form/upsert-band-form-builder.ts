import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Injectable } from '@angular/core';
import { BaseFormBuilder } from './base-form-builder';
import { BandViewModel } from '../../models/band/BandViewModel';

@Injectable({
    providedIn: 'root'
})

export class UpsertBandFormBuilder extends BaseFormBuilder {
    
    AddSubArrayElement(formArray: import("@angular/forms").FormArray): void {
        throw new Error("Method not implemented.");
    }


    constructor(formBuilder: FormBuilder) {
        super(formBuilder);

    }

    public Initialize() {
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

    public Build(form: FormGroup, band: BandViewModel) {

        if(band){
            form.controls.title.setValue(band.Name);
            form.controls.formationDate.setValue(new Date(band.FormationDate));
            form.controls.disbandDate.setValue(new Date(band.DisbandDate));
            form.controls.biography.setValue(band.Description);
        }
    }
}
