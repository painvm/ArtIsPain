import { GetById } from './get-by-id';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';

export class GetAlbumByIdForEdit extends GetById {
    static readonly type = ActionTypeEnum.GetAlbumByIdForEdit

}
