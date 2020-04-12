import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { BandPreviewModel } from "../models/band/BandPreviewModel";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { AlbumViewModel } from "../models/album/AlbumViewModel";
import { AlbumService } from "../_services/album.service";
import { BaseGetByIdResolver } from "./base-get-by-id-resolver";

@Injectable()
export class AlbumViewResolver extends BaseGetByIdResolver<AlbumViewModel> {
  constructor(private albumService: AlbumService) {
    super(albumService);
  }
}
