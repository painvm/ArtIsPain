import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IViewModel } from '../_interfaces/i-view-model';
import { IService } from '../_interfaces/iservice';
import { BaseResolver } from './base-resolver';

@Injectable()
export abstract class BaseEditResolver<T extends IViewModel> extends BaseResolver<T> {
    constructor(private service: IService<T>) {
        super();
    }

    performRequest(route: ActivatedRouteSnapshot): Observable<T> {
        if (!route.params.id) {
            return of<T>(null);
        }
        return this.service.getById(route.params.id);
    }}
