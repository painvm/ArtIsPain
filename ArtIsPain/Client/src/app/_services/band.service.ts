import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BandViewModel } from '../models/band/BandViewModel';
import { BaseService } from './base.service';
import { ApiPath } from '../_enums/api-path.enum';

@Injectable({
  providedIn: 'root'
})

export class BandService extends BaseService<BandViewModel> {

  Path = ApiPath.Band;

  constructor(private http: HttpClient) {
    super(http);
  }
}
