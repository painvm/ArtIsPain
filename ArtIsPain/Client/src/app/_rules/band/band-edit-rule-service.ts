import { ControlRule } from '../control-rule';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BaseValidators } from '../base-validators';
import { FormRule } from '../form-rule';
import { Injectable } from '@angular/core';
import { IRuleService } from '../../_interfaces/i-rule-service';
import { IRule } from '../../_interfaces/i-rule';
import { ControlName } from '../../_enums/control-name';

@Injectable({
    providedIn: 'root'
})
export class BandEditRuleService implements IRuleService {

    public GetRules(form: FormGroup): IRule[] {

        const rules = [];

        const formRule = new FormRule(
            form, BaseValidators.validateDateRange(ControlName.BandFormationDate, ControlName.BandDisbandDate));
        const titleRule = new ControlRule(form, ControlName.BandTitle, Validators.required, Validators.maxLength(255));
        const biographyRule = new ControlRule(form, ControlName.BandBiography, Validators.maxLength(4000));
        const formationDate = new ControlRule(form, ControlName.BandFormationDate, Validators.required);

        rules.push(formRule, titleRule, biographyRule, formationDate);

        return rules;
    }
}
