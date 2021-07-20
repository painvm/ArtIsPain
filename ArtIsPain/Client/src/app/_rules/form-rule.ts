import { IRule } from '../_interfaces/i-rule';
import { ValidatorFn, FormGroup } from '@angular/forms';

export class FormRule implements IRule {

    Form: FormGroup;
    ValidationRules: ValidatorFn[];


    constructor(form: FormGroup, ...params: ValidatorFn[]) {
        this.Form = form;
        this.ValidationRules = params;
    }

    ApplySpecificControlRules() {

        this.Form.setValidators(this.ValidationRules);
        this.Form.updateValueAndValidity();
    }
}
