import { GetById } from './get-by-id';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';

export class GetBandByIdForEdit extends GetById {

    static readonly type = ActionTypeEnum.GetBandByIdForEdit

    constructor() {
        super();
    }
}