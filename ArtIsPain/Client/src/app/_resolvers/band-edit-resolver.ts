import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { BandService } from '../_services/band.service';
import { BandViewModel } from '../models/band/BandViewModel';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { BaseEditResolver } from './base-edit-resolver';

@Injectable()
export class BandEditResolver extends BaseEditResolver<BandViewModel> {
    constructor(private bandService: BandService) {
        super(bandService);
    }
}
