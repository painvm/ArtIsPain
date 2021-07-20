import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { IViewModel } from '../../_interfaces/i-view-model';
import { IFormBuilder } from '../../_interfaces/i-form-builder';

export abstract class BaseFormBuilder implements IFormBuilder {
    abstract Initialize(): FormGroup;
    abstract Build(form: FormGroup, entityModel: IViewModel): void;
    abstract AddSubArrayElement(formArray: FormArray): void;


    constructor(protected formBuilder: FormBuilder) {
    }


}
