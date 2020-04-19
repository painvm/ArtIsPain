import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

export function ValidateDateRange(formGroup: FormGroup, startDateControlName: string, endDateControlName: string) {

    const startDateControl = formGroup.controls[startDateControlName];
    const endDateControl = formGroup.controls[endDateControlName];

    if (startDateControl && endDateControl && startDateControl.value && endDateControl.value) {
        if (startDateControl.errors 
            || endDateControl.errors
            || isNaN(startDateControl.value.getUTCFullYear()) || isNaN(endDateControl.value.getUTCFullYear()))
        {
            return null;
        }

        if (startDateControl.value > endDateControl.value) {
            endDateControl.setErrors({ invalidRange: true })
        }
    }

    return null;
}
