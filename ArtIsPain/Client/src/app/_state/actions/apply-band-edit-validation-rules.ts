import { BaseAction } from './base-action';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { FormGroup } from '@angular/forms';
import { ApplyValidationRules } from './apply-validation-rules';

export class ApplyBandEditValidationRules extends ApplyValidationRules {
    static readonly type = ActionTypeEnum.ApplyBandEditValidationRules


    constructor(public Form: FormGroup) {
        super(Form);
    }
}
