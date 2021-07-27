import { UpsertEntity } from './upsert-entity';
import { ActionTypeEnum } from '../../_enums/action-type-enum.enum';

export class UpsertBand extends UpsertEntity {
    
    static get type() {
        return ActionTypeEnum.UpsertBand
    }

    static readonly redirectPath = '/bands/view/';


    constructor(entityId?: string) {
        super(entityId);
    }
}
