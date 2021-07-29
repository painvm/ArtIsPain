import { Injectable } from '@angular/core';
import { IService } from '../_interfaces/iservice';
import { IViewModel } from '../_interfaces/i-view-model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { ApiPath } from '../_enums/api-path.enum';
import { ICollectionService } from '../_interfaces/i-collection-service';
import { IResponse } from '../_interfaces/i-response';

@Injectable({
  providedIn: 'root'
})

export abstract class BaseCollectionService<T extends IResponse> implements ICollectionService<T> {

  BaseUrl = environment.apiUrl;
  Path: ApiPath;

constructor(private httpClient: HttpClient) { }

  GetAll(): Observable<T> {

    const requestUrl = this.BaseUrl.concat(this.Path);

    return this.httpClient.get<T>(requestUrl);
  }}
