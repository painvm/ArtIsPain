import { FormControl, ValidatorFn, Validators, AbstractControl, FormGroup } from '@angular/forms';
import { isDateValid } from 'ngx-bootstrap/chronos/utils/type-checks';

export class BaseValidators {

    static validateDateRange(startDateControlName, endDateControlName: string): ValidatorFn {
        return (form: FormGroup): { [key: string]: any } | null => {

            const startDateControl = form.controls[startDateControlName];
            const endDateControl = form.controls[endDateControlName]
            if (startDateControl.value !== null &&
                endDateControl.value !== null &&
                startDateControl.value > endDateControl.value) {
                console.log(startDateControl.errors);
                return { 'invalidDateRange': { value: true } }
            }
            else {
                return null;
            }

        }
    }

    static UrlValidationPattern = '(https?://)?([\\da-z.-]+)\\.([a-z.]{2,6})[/\\w .-]*/?';
}
