import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { BandPreviewModel } from "../models/band/BandPreviewModel";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { AlbumViewModel } from "../models/album/AlbumViewModel";
import { AlbumService } from "../_services/album.service";
import { BaseGetByIdResolver } from "./base-get-by-id-resolver";
import { Store } from '@ngxs/store';
import { GetAlbumById } from '../_state/actions/get-album-by-id';

@Injectable()
export class AlbumViewResolver extends BaseGetByIdResolver<AlbumViewModel> {
  constructor(store: Store) {
    super(store, new GetAlbumById());
  }
}
