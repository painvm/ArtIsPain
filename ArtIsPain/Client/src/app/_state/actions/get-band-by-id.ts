import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { BaseAction } from './base-action';

export class GetBandById extends BaseAction {

    static readonly type = ActionTypeEnum.GetBandById

    constructor(public readonly bandId: string) {
        super();
    }
}
