import {Injectable} from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IViewModel } from '../_interfaces/i-view-model';

@Injectable()
export abstract class BaseResolver<T extends IViewModel> implements Resolve<T> {
    constructor() {}

    abstract performRequest(route: ActivatedRouteSnapshot): Observable<T>;

    resolve(route: ActivatedRouteSnapshot): Observable<T> {
        return this.performRequest(route).pipe(
            catchError( error => {
                console.log(error);
                return of(null);
            }));
    }}
