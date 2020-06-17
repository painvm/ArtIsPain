import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute, Router, ActivatedRouteSnapshot } from "@angular/router";
import { CdkDragDrop, moveItemInArray } from "@angular/cdk/drag-drop";
import { FormGroup, FormArray } from '@angular/forms';
import { Select, Store, Actions, ofActionCompleted, ofActionSuccessful } from '@ngxs/store';
import { ApplyAlbumEditValidationRules } from "../../../_state/actions/apply-album-edit-validation-rules";
import { AlbumViewModel } from "../../../models/album/AlbumViewModel";
import { UpsertSongCommand } from "../../../commands/albums/upsert-song-command";
import { UpsertAlbumFormBuilder } from "../../../_builders/form/upsert-album-form-builder";
import { AlbumService } from "../../../_services/album.service";
import { AlbumEditState } from "../../../_state/states/album-edit-state";
import { UpsertAlbum } from "../../../_state/actions/upsert-album";
import { tap, takeUntil, map, distinctUntilChanged, take, distinctUntilKeyChanged, takeWhile } from "rxjs/operators";
import { Subscription } from "rxjs/internal/Subscription";
import { Observable } from "rxjs/internal/Observable";
import { GetAlbumByIdForEdit } from "../../../_state/actions/get-album-by-id-for-edit";
import { Subject } from "rxjs";
import { Navigate } from "@ngxs/router-plugin";

@Component({
  selector: "app-album-edit",
  templateUrl: "./album-edit.component.html",
  styleUrls: ["./album-edit.component.css"],
})
export class AlbumEditComponent implements OnInit, OnDestroy {
  album: AlbumViewModel;
  draftSongs: UpsertSongCommand[];

  potentialSong: UpsertSongCommand;

  isEditSongMode: boolean;

  albumUpsertForm: FormGroup;

  constructor(
    private store: Store,
    private formBuilder: UpsertAlbumFormBuilder,
    private route: ActivatedRoute,
    private actions$: Actions
  ) {



  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private destroy$ = new Subject<void>();


  @Select(AlbumEditState.getAlbumResponse) albumResponse$: Observable<AlbumViewModel>;
  @Select(AlbumEditState.isAlbumLoaded) isAlbumLoaded$: Observable<boolean>;

  ngOnInit() {
    this.initializeRouteHandler();

    this.albumUpsertForm = this.formBuilder.Initialize();

    this.isAlbumLoaded$.pipe(takeWhile(() => this.album === undefined)).subscribe(value => {
      if (value) {
        this.albumResponse$.pipe(take(1)).subscribe(
          data => {
            this.album = data;
            this.formBuilder.Build(this.albumUpsertForm, this.album);
            this.store.dispatch(new ApplyAlbumEditValidationRules(this.albumUpsertForm))
          })
      }
    })
  }

  applyOrder() {
    this.songs.controls.forEach((song) => {
      song.value.order = this.songs.controls.indexOf(song) + 1;
    });
  }

  onSongPositionChanged(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.songs.controls, event.previousIndex, event.currentIndex);
    this.applyOrder();
  }

  addSong() {
    this.configureEditMode(this.formBuilder.AddSubArrayElement(this.songs))
    this.applyOrder();
  }

  removeSong(songIndex: number) {
    this.songs.removeAt(songIndex)
  }

  configureEditMode(song: any, removeWhenEmpty: boolean = false) {
    song.editMode = !song.editMode;

    if (removeWhenEmpty && (!song.controls.songTitle.value || song.controls.songTitle.value === "")) {
      this.removeSong(this.songs.value.indexOf(song))
    }

    this.albumUpsertForm.updateValueAndValidity()
  }

  upsertAlbum() {
    this.store.dispatch(new UpsertAlbum(this.album?.Id));
  }

  get songs(): FormArray {
    return this.albumUpsertForm.get('songs') as FormArray;
  }

  initializeRouteHandler() {
    this.actions$.pipe(ofActionSuccessful(UpsertAlbum), takeUntil(this.destroy$))
      .subscribe(() =>

        this.isAlbumLoaded$.pipe(takeUntil(this.destroy$)).subscribe(value => {
          if (value) {
            this.albumResponse$.pipe(take(1)).subscribe(
              data => {
                const albumId = data.Id;
                this.store.dispatch(new Navigate(['/albums/view/' + albumId]))
              });
          }
        }))
  }
}
