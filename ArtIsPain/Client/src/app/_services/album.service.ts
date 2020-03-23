import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { Observable } from 'rxjs';
import { UpsertAlbumCommand } from '../commands/albums/upsert-album-command';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAlbumById(id: string): Observable<AlbumViewModel> {
    return this.http.get<AlbumViewModel>(this.baseUrl + 'album/' + id);
  }

  upsertAlbum(request: UpsertAlbumCommand): Observable<AlbumViewModel>{
    return this.http.post<AlbumViewModel>(this.baseUrl + 'album', request);
  }

}
