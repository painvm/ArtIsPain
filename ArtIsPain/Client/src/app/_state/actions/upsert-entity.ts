import { IAction } from 'src/app/_interfaces/i-action';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { BaseAction } from './base-action';

export abstract class UpsertEntity implements BaseAction {

    readonly EntityId?: string;


    constructor(entityId?: string) {
        this.EntityId = entityId;
    }
    type: ActionTypeEnum;

}
