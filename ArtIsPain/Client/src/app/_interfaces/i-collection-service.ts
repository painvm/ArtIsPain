import { Observable } from 'rxjs';
import { IViewModel } from './i-view-model';
import { IUpsertEntityCommand } from './i-upsert-entity-command';
import { IResponse } from './i-response';

export interface ICollectionService<T extends IResponse>
{
    BaseUrl: string;
    Path: string;

    GetAll(): Observable<T>;
}
