import { Observable } from 'rxjs';
import { IViewModel } from './i-view-model';
import { IUpsertEntityCommand } from './i-upsert-entity-command';

export interface IService<T extends IViewModel>
{
    BaseUrl: string;
    Path: string;


    GetById(id: string): Observable<T>;
    Upsert(upsertEntityCommand: IUpsertEntityCommand): Observable<T>;
}
