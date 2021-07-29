import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BandViewModel } from '../models/band/BandViewModel';
import { BaseService } from './base.service';
import { ApiPath } from '../_enums/api-path.enum';
import { BandCollectionViewModel } from '../models/band/BandCollectionViewModel';
import { BaseCollectionService } from './base-collection-service';

@Injectable({
  providedIn: 'root'
})

export class BandCollectionService extends BaseCollectionService<BandCollectionViewModel> {

  Path = ApiPath.Band;

  constructor(private http: HttpClient) {
    super(http);
  }
}
