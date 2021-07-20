import { IRule } from '../_interfaces/i-rule';
import { FormGroup, ValidatorFn } from '@angular/forms';
import { ControlName } from '../_enums/control-name';

export class ControlRule implements IRule {
    ControlName: string;
    Form: FormGroup;
    ValidationRules: ValidatorFn[];

    constructor(form: FormGroup, controlName: string, ...params: ValidatorFn[]) {
        this.ControlName = controlName;
        this.Form = form;
        this.ValidationRules = params;
    }

    public ApplySpecificControlRules() {
        this.Form.controls[this.ControlName].setValidators(this.ValidationRules);
        this.Form.updateValueAndValidity();
    }
}
