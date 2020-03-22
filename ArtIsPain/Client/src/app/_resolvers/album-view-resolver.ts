import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { BandPreviewModel } from '../models/band/BandPreviewModel';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { AlbumService } from '../_services/album.service';

@Injectable()
export class AlbumViewResolver implements Resolve<AlbumViewModel>{
    constructor(private albumService: AlbumService, private router: Router){}

    resolve(route: ActivatedRouteSnapshot): Observable<AlbumViewModel>{
        return this.albumService.getAlbumById(route.params.id).pipe(
            catchError( error => {
                console.log(error);
                this.router.navigate(['/albums']);
                return of(null);
            }));
    }}
