import { UpsertEntity } from "./upsert-entity";
import { ActionTypeEnum } from "../../_enums/action-type-enum.enum";

export class UpsertAlbum extends UpsertEntity {

    static readonly type = ActionTypeEnum.UpsertAlbum;
    static readonly redirectPath = '/albums/view/';
}
