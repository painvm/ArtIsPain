import { BaseAction } from './base-action';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { FormGroup } from '@angular/forms';

export class ApplyBandEditValidationRules extends BaseAction {
    static readonly type = ActionTypeEnum.ApplyBandEditValidationRules


    constructor(public Form: FormGroup) {
        super();
    }
}
