import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { BandService } from '../_services/band.service';
import { BandViewModel } from '../models/band/BandViewModel';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class BandEditResolver implements Resolve<BandViewModel> {
    constructor(private bandService: BandService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<BandViewModel> {
        if (!route.params.id) {
            return new Observable<BandViewModel>();
        }
        return this.bandService.getBandById(route.params.id).pipe(
            catchError( error => {
                console.log(error);
                this.router.navigate(['/bands']);
                return of(null);
            }));
    }}
