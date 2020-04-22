import { IAction } from 'src/app/_interfaces/i-action';
import { ActionTypeEnum } from 'src/app/_enums/action-type-enum.enum';

export class BaseAction implements IAction{
    type: ActionTypeEnum;
}
