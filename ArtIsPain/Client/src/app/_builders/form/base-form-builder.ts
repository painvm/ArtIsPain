import { IFormBuilder } from 'src/app/_interfaces/i-form-builder';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IViewModel } from 'src/app/_interfaces/i-view-model';

export abstract class BaseFormBuilder implements IFormBuilder {
    abstract Initialize(): FormGroup;
    abstract Build(form: FormGroup, entityModel: IViewModel): void;


    constructor(protected formBuilder: FormBuilder) {
    }
}
