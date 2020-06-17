import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { Select, Store, Actions, ofActionSuccessful } from '@ngxs/store';
import { AlbumViewState } from '../../_state/states/album-view-state';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { Navigate, RouterDataResolved } from '@ngxs/router-plugin';
import { takeUntil, distinctUntilChanged, take } from 'rxjs/operators';
import { GetAlbumById } from '../../_state/actions/get-album-by-id';

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.css']
})
export class AlbumViewComponent implements OnInit, OnDestroy {

  album: AlbumViewModel;

  @Select(AlbumViewState.getAlbum) albumResponse$: Observable<AlbumViewModel>;
  @Select(AlbumViewState.isAlbumLoaded) isAlbumLoaded$: Observable<boolean>;


  constructor() { }

  ngOnInit() {

    this.isAlbumLoaded$.pipe(distinctUntilChanged()).subscribe(value => {
      if (value) {
        this.albumResponse$.pipe(take(1)).subscribe(
          data => {
            this.album = data;
          })
      }
    })
  }

  private destroy$ = new Subject<void>();


  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}

