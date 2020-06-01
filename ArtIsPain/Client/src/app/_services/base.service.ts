import { Injectable } from '@angular/core';
import { IService } from '../_interfaces/iservice';
import { IViewModel } from '../_interfaces/i-view-model';
import { Observable } from 'rxjs';
import { IUpsertEntityCommand } from '../_interfaces/i-upsert-entity-command';
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { ApiPath } from '../_enums/api-path.enum';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T extends IViewModel> implements IService<T> {

  BaseUrl = environment.apiUrl;
  Path: ApiPath;

constructor(private httpClient: HttpClient) { }

  GetById(id: string): Observable<T>
  {
    const requestUrl = this.BaseUrl.concat(this.Path.concat(id));

    return this.httpClient.get<T>(requestUrl);
  }

  Upsert(upsertEntityCommand: IUpsertEntityCommand): Observable<T>
  {
    const requestUrl = this.BaseUrl.concat(this.Path);

    return this.httpClient.post<T>(requestUrl, upsertEntityCommand);
  }

}
