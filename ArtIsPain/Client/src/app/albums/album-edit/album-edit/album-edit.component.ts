import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CdkDragDrop, moveItemInArray } from "@angular/cdk/drag-drop";
import { FormGroup } from '@angular/forms';
import { Select, Store, Actions, ofActionCompleted } from '@ngxs/store';
import { ApplyAlbumEditValidationRules } from "../../../_state/actions/apply-album-edit-validation-rules";
import { AlbumViewModel } from "../../../models/album/AlbumViewModel";
import { UpsertSongCommand } from "../../../commands/albums/upsert-song-command";
import { UpsertAlbumFormBuilder } from "../../../_builders/form/upsert-album-form-builder";
import { AlbumService } from "../../../_services/album.service";
import { AlbumEditState } from "../../../_state/states/album-edit-state";
import { UpsertAlbum } from "../../../_state/actions/upsert-album";
import { tap } from "rxjs/operators";
import { Subscription } from "rxjs/internal/Subscription";
import { Observable } from "rxjs/internal/Observable";

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
    private albumService: AlbumService,
    private actions$: Actions
  ) { }

  ngOnDestroy(): void {
  }

  @Select(AlbumEditState.getAlbumResponse) album$: Observable<AlbumViewModel>;


  ngOnInit() {

    this.albumUpsertForm = this.formBuilder.Initialize();

    this.album$.subscribe(data => {

      this.album = data;
      this.formBuilder.Build(this.albumUpsertForm, data);

      this.store.dispatch(new ApplyAlbumEditValidationRules(this.albumUpsertForm))
    }).unsubscribe()
  }

  reorderSongs() {
    this.draftSongs.forEach((song) => {
      song.Order = this.draftSongs.indexOf(song) + 1;
    });
  }

  drop(event: CdkDragDrop<string[]>) {
    if (!this.draftSongs.find((x) => x.IsEditMode)) {
      moveItemInArray(this.draftSongs, event.previousIndex, event.currentIndex);
      this.reorderSongs();
    }
  }

  createSongTemplate() {
  }

  resetSongTemplate() {
    this.potentialSong = null;
  }

  addSong() {
    this.draftSongs.push(this.potentialSong);
    this.resetSongTemplate();
    this.isEditSongMode = false;
  }

  showInput(song: UpsertSongCommand) {
    if (!this.draftSongs.find((x) => x.IsEditMode)) {
      song.IsEditMode = !song.IsEditMode;
      this.isEditSongMode = true;
    }
  }

  cancelEditSong(song: UpsertSongCommand) {
    song.IsEditMode = !song.IsEditMode;
    this.draftSongs = JSON.parse(JSON.stringify(this.album.Songs));
    this.isEditSongMode = false;
  }

  updateSong(song: UpsertSongCommand) {
    song.IsEditMode = !song.IsEditMode;
  }

}
