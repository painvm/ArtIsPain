import {Injectable} from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IViewModel } from '../_interfaces/i-view-model';
import { IAction } from '../_interfaces/i-action';
import { Store } from '@ngxs/store';

@Injectable()
export abstract class BaseResolver<T extends IViewModel> implements Resolve<T> {
    constructor(private store: Store, private action: IAction) {}

    abstract performRequest(store: Store, route: ActivatedRouteSnapshot, action: IAction): Observable<T>;

    resolve(route: ActivatedRouteSnapshot): Observable<T> {
        return this.performRequest(this.store, route, this.action);
    }}
