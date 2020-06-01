import { FormGroup } from '@angular/forms';
import { IRule } from './i-rule';

export interface IRuleService {
    GetRules(form: FormGroup): IRule[];
}
