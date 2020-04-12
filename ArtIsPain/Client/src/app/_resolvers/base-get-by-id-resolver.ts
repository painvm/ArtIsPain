import { Injectable } from '@angular/core';
import { IService } from '../_interfaces/iservice';
import { IViewModel } from '../_interfaces/i-view-model';
import { BaseResolver } from './base-resolver';
import { ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export abstract class BaseGetByIdResolver<T extends IViewModel> extends BaseResolver<T> {
    constructor(private service: IService<T>) {
        super();
    }

    performRequest(route: ActivatedRouteSnapshot): Observable<T> {
        return this.service.getById(route.params.id).pipe(
            catchError( error => {
                console.log(error);
                return of(null);
            }));
    }}
