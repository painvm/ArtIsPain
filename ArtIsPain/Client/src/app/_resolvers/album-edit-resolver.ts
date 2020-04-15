import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { Observable, of } from 'rxjs';
import { AlbumService } from '../_services/album.service';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { BaseEditResolver } from './base-edit-resolver';

export class AlbumEditResolver extends BaseEditResolver<AlbumViewModel>
{
    constructor(private albumService: AlbumService) {
        super(albumService);
    }
}
