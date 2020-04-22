import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { Observable } from 'rxjs';
import { UpsertAlbumCommand } from '../commands/albums/upsert-album-command';
import { BaseService } from './base.service';
import { ApiPath } from '../_enums/api-path.enum';

@Injectable({
  providedIn: 'root'
})

export class AlbumService extends BaseService<AlbumViewModel> {

  Path = ApiPath.Album;

  constructor(private http: HttpClient) {
    super(http);

}
}
