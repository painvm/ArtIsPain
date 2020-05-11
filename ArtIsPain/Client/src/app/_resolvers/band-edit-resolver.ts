import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { BandService } from '../_services/band.service';
import { BandViewModel } from '../models/band/BandViewModel';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { BaseEditResolver } from './base-edit-resolver';
import { GetBandById } from '../_state/actions/get-band-by-id';
import { Store } from '@ngxs/store';
import { GetBandByIdForEdit } from '../_state/actions/get-band-by-id-for-edit';

@Injectable()
export class BandEditResolver extends BaseEditResolver<BandViewModel> {
    constructor(store: Store) {
        super(store, new GetBandByIdForEdit());
    }
}
