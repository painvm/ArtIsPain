import { ControlRule } from '../control-rule';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BaseValidators } from '../base-validators';
import { IRule } from 'src/app/_interfaces/i-rule';
import { FormRule } from '../form-rule';
import { ControlName } from 'src/app/_enums/control-name';

export class BandEditRules {

    private static rules: IRule[];

    public static GetRules(form: FormGroup): IRule[] {

        this.rules = [];

        const formRule = new FormRule(
            form, BaseValidators.validateDateRange(ControlName.BandFormationDate, ControlName.BandDisbandDate));
        const titleRule = new ControlRule(form, ControlName.BandTitle, Validators.required, Validators.maxLength(255));
        const biographyRule = new ControlRule(form, ControlName.BandBiography, Validators.maxLength(4000));
        const formationDate = new ControlRule(form, ControlName.BandFormationDate, Validators.required);

        this.rules.push(formRule, titleRule, biographyRule, formationDate);

        return this.rules;
    }
}
