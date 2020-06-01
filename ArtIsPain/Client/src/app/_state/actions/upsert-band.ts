import { UpsertEntity } from './upsert-entity';
import { ActionTypeEnum } from '../../_enums/action-type-enum.enum';

export class UpsertBand extends UpsertEntity {
    static readonly type: ActionTypeEnum.UpsertBand


    constructor(entityId?: string) {
        super(entityId);
    }
}
