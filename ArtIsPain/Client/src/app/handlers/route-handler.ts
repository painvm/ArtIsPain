import { Injectable } from '@angular/core';
import { Actions, ofAction, ofActionSuccessful, Store } from '@ngxs/store';
import { GetAlbumByIdForEdit } from '../_state/actions/get-album-by-id-for-edit';
import { Navigate } from '@ngxs/router-plugin';

@Injectable()
export class RouteHandler {
  constructor(private store: Store, private actions$: Actions) {

  }
}