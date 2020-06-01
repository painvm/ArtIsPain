import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IViewModel } from '../_interfaces/i-view-model';
import { BaseResolver } from './base-resolver';
import { Store, Select } from '@ngxs/store';
import { GetById } from '../_state/actions/get-by-id';
import { BandViewState } from '../_state/states/band-view-state';

@Injectable()
export abstract class BaseEditResolver<T extends IViewModel> extends BaseResolver<T> {
    constructor(store: Store, action: GetById) {
        super(store, action);
    }

    performRequest(store: Store, route: ActivatedRouteSnapshot, action: GetById): Observable<T> {
        action.Id = route.params.id;
        return store.dispatch(action);
    }
}
