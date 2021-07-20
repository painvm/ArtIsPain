import { IUpsertEntityCommand } from './i-upsert-entity-command';
import { FormGroup } from '@angular/forms';

export interface ICommandBuilder {
    Build(form: FormGroup, entityId: string): IUpsertEntityCommand
}
