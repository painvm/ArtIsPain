import { BaseAction } from './base-action';
import { FormGroup } from '@angular/forms';

export abstract class ApplyValidationRules extends BaseAction {

    constructor(protected Form: FormGroup) {
        super();
    }
}
