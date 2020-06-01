import { BaseAction } from './base-action';
import { ActionTypeEnum } from '../../_enums/action-type-enum.enum';

export abstract class UpsertEntity implements BaseAction {


    constructor(public EntityId?: string) {
    }
    type: ActionTypeEnum;

}
