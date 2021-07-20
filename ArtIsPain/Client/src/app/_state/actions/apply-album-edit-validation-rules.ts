import { ApplyValidationRules } from './apply-validation-rules';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { FormGroup } from '@angular/forms';

export class ApplyAlbumEditValidationRules extends ApplyValidationRules {
    static readonly type = ActionTypeEnum.ApplyAlbumEditValidationRules

    constructor(public Form: FormGroup) {
        super(Form);
    }
}


