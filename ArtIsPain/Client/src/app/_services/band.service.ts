import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { BandCollectionPreviewModel } from '../models/band/BandCollectionPreviewModel';
import { BandPreviewModel } from '../models/band/BandPreviewModel';
import { BandViewModel } from '../models/band/BandViewModel';
import { UpsertBandCommand } from '../commands/bands/upsert.band.command';

@Injectable({
  providedIn: 'root'
})

export class BandService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getBandById(id): Observable<BandViewModel> {
    return this.http.get<BandViewModel>(this.baseUrl + 'band/' + id);
  }

  getBands(): Observable<BandCollectionPreviewModel> {
    return this.http.get<BandCollectionPreviewModel>(this.baseUrl + 'band/getAll');
  }

  upsertBand(request: UpsertBandCommand): Observable<BandViewModel>{
    return this.http.post<BandViewModel>(this.baseUrl + 'band', request);
  }
}
