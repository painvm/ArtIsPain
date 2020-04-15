import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { BandCollectionPreviewModel } from '../models/band/BandCollectionPreviewModel';
import { BandPreviewModel } from '../models/band/BandPreviewModel';
import { BandViewModel } from '../models/band/BandViewModel';
import { UpsertBandCommand } from '../commands/bands/upsert.band.command';
import { BaseService } from './base.service';
import { ApiPath } from '../enums/api-path.enum';

@Injectable({
  providedIn: 'root'
})

export class BandService extends BaseService<BandViewModel> {

  Path = ApiPath.Band;

  constructor(private http: HttpClient) {
    super(http);
  }
}
