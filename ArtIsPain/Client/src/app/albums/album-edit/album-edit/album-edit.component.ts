import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CdkDragDrop, moveItemInArray } from "@angular/cdk/drag-drop";
import { FormGroup, FormArray } from '@angular/forms';
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

  applyOrder() {
    this.songs.controls.forEach((song) => {
      song.value.order = this.songs.controls.indexOf(song) + 1;
    });
  }

  onSongPositionChanged(event: CdkDragDrop<string[]>) {
      moveItemInArray(this.songs.controls, event.previousIndex, event.currentIndex);
      this.applyOrder();
  }

  removeSong(songIndex: number){
    this.songs.removeAt(songIndex)
  }

  configureEditMode(song: any) {
      song.editMode = !song.editMode;
      this.isEditSongMode = true;
    }

    upsertAlbum(){
        this.store.dispatch(new UpsertAlbum(this.album.Id));
    }

  get songs(): FormArray {
    return this.albumUpsertForm.get('songs') as FormArray;
 } 

}
