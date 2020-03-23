import { AlbumViewModel } from '../models/album/AlbumViewModel';
import { Observable, of } from 'rxjs';
import { AlbumService } from '../_services/album.service';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { catchError } from 'rxjs/operators';

export class AlbumEditResolver
{
    constructor(private albumService: AlbumService, private router: Router){}

    resolve(route: ActivatedRouteSnapshot): Observable<AlbumViewModel> {
        if (!route.params.id) {
            return new Observable<AlbumViewModel>();
        }
        return this.albumService.getAlbumById(route.params.id).pipe(
            catchError( error => {
                console.log(error);
                this.router.navigate(['/albums']);
                return of(null);
            }));
    }}
