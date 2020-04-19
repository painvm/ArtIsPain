import { Directive, Input } from '@angular/core';
import { Validator, AbstractControl, ValidationErrors, FormControl, NG_VALIDATORS, FormGroup } from '@angular/forms';
import { ValidateDateRange } from '../_validators/date-range-validator';

@Directive({
  selector: '[dateRangeValidation]',
  providers: [{ provide: NG_VALIDATORS, useExisting: DateRangeValidationDirective, multi: true }]
})
export class DateRangeValidationDirective implements Validator {

  constructor() { }

  @Input('startDateControlName') startDateControlName: string;
  @Input('endDateControlName') endDateControlName: string;

  validate(control: FormGroup): ValidationErrors {

    return ValidateDateRange(control, this.startDateControlName, this.endDateControlName)
  }

}
