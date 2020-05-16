import { ValidatorFn, FormGroup } from '@angular/forms';

export interface IRule {
    Form: FormGroup;
    ValidationRules: ValidatorFn[];

    ApplySpecificControlRules: () => void;
}
