import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { BandPreviewModel } from '../models/band/BandPreviewModel';
import { BandService } from '../_services/band.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class BandResolver implements Resolve<BandPreviewModel>{
    constructor(private bandService: BandService, private router: Router){}

    resolve(route: ActivatedRouteSnapshot): Observable<BandPreviewModel>{
        return this.bandService.getBandById(route.params.id).pipe(
            catchError( error => {
                console.log(error);
                this.router.navigate(['/bands']);
                return of(null);
            }));
    }}
