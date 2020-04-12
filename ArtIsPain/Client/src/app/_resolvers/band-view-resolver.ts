import { Injectable } from '@angular/core';
import { BandService } from '../_services/band.service';
import { BaseGetByIdResolver } from './base-get-by-id-resolver';
import { BandViewModel } from '../models/band/BandViewModel';

@Injectable()
export class BandViewResolver extends BaseGetByIdResolver<BandViewModel> {
  constructor(private bandService: BandService) {
    super(bandService);
  }
}
