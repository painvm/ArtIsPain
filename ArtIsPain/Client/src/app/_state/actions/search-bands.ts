import { ActionTypeEnum } from "../../_enums/action-type-enum.enum";
import { BaseAction } from "./base-action";

export class SearchBand extends BaseAction {

    static readonly type = ActionTypeEnum.SearchBands;
    static readonly redirectPath = '/albums/view/';

    searchTerm: string;
}
