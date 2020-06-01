import { FormGroup } from '@angular/forms';
import { IViewModel } from './i-view-model';

export interface IFormBuilder {
    Initialize(): FormGroup;
    Build(form: FormGroup, entityModel: IViewModel): void;
}
