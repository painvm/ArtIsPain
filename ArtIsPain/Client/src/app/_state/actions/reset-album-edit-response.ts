import { BaseAction } from "./base-action";
import { ActionTypeEnum } from "../../_enums/action-type-enum.enum";

export class ResetAlbumEditResponse extends BaseAction {

    static readonly type = ActionTypeEnum.ResetAlbumEditResponse;
}
