import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';
import { GetById } from './get-by-id';

export class GetBandById extends GetById {

    static readonly type = ActionTypeEnum.GetBandById

    constructor() {
        super();
    }
}
