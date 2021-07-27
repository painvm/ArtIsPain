import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { Select, Store, Actions, ofActionSuccessful } from '@ngxs/store';
import { AlbumViewState } from '../../_state/states/album-view-state';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { Navigate, RouterDataResolved } from '@ngxs/router-plugin';
import { takeUntil, distinctUntilChanged, take } from 'rxjs/operators';
import { GetAlbumById } from '../../_state/actions/get-album-by-id';
import { BaseComponent } from '../../base/base-view/base.component';

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.css']
})
export class AlbumViewComponent extends BaseComponent  {

  entity: AlbumViewModel;

  constructor(store: Store) { 
    super(store.select(AlbumViewState.getAlbum), store.select(AlbumViewState.isAlbumLoaded))
  }
}

