import { Injectable } from '@angular/core';
import { IService } from '../_interfaces/iservice';
import { IViewModel } from '../_interfaces/i-view-model';
import { BaseResolver } from './base-resolver';
import { ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { GetById } from '../_state/actions/get-by-id';
import { Store } from '@ngxs/store';
import { IAction } from '../_interfaces/i-action';

@Injectable()
export abstract class BaseGetByIdResolver<T extends IViewModel> extends BaseResolver<T> {
    constructor(store: Store, action: GetById) {
        super(store, action);
    }


    performRequest(store: Store, route: ActivatedRouteSnapshot, action: GetById): Observable<T> {
        action.Id = route.params.id;
        return store.dispatch(action);
    }}
