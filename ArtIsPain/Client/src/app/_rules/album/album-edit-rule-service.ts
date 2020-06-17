import { IRuleService } from "../../_interfaces/i-rule-service";
import { IRule } from "../../_interfaces/i-rule";
import { FormGroup, Validators } from "@angular/forms";
import { Injectable } from "@angular/core";
import { ControlRule } from "../control-rule";
import { ControlName } from "../../_enums/control-name";
import { BaseValidators } from "../base-validators";
import { FormRule } from "../form-rule";


@Injectable({
    providedIn: 'root'
})
export class AlbumEditRuleService implements IRuleService {

    public GetRules(form: FormGroup): IRule[] {

        const rules = [];

        const titleRule = new ControlRule(form, ControlName.AlbumTitle, Validators.required);
        const releaseDate = new ControlRule(form, ControlName.AlbumReleaseDate, Validators.required);
        const urlRule = new ControlRule(form, ControlName.AlbumUrl, Validators.pattern(BaseValidators.UrlValidationPattern));

        const songsRule = new FormRule(form, BaseValidators.validateFormArrayLength(ControlName.SongArray));
        const formRule = new FormRule(form, BaseValidators.validateDateRange(ControlName.AlbumStartRecordDate, ControlName.AlbumReleaseDate));

        rules.push(titleRule, releaseDate, urlRule, formRule, songsRule)
        return rules;
    }
}
