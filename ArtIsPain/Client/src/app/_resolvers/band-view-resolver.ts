import { Injectable } from '@angular/core';
import { BandService } from '../_services/band.service';
import { BaseGetByIdResolver } from './base-get-by-id-resolver';
import { BandViewModel } from '../models/band/BandViewModel';
import { Store } from '@ngxs/store';
import { GetBandById } from '../_state/actions/get-band-by-id';

@Injectable()
export class BandViewResolver extends BaseGetByIdResolver<BandViewModel> {
  constructor(store: Store) {
    super(store, new GetBandById());
  }
}
