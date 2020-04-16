import { Component, OnInit } from "@angular/core";
import { AlbumService } from "src/app/_services/album.service";
import { ActivatedRoute, Router } from "@angular/router";
import { AlbumViewModel } from "src/app/models/album/AlbumViewModel";
import { UpsertAlbumCommand } from "src/app/commands/albums/upsert-album-command";
import { UpsertSongCommand } from "src/app/commands/albums/upsert-song-command";
import { CdkDragDrop, moveItemInArray } from "@angular/cdk/drag-drop";
import { SongPreviewModel } from "src/app/models/song/song-preview-model";
import { BandPreviewModel } from "src/app/models/band/BandPreviewModel";

@Component({
  selector: "app-album-edit",
  templateUrl: "./album-edit.component.html",
  styleUrls: ["./album-edit.component.css"],
})
export class AlbumEditComponent implements OnInit {
  album: UpsertAlbumCommand;
  draftSongs: UpsertSongCommand[];

  potentialSong: UpsertSongCommand;

  isEditSongMode: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private albumService: AlbumService
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.album = this.buildUpsertAlbumCommand(data.album);
      this.album.Songs.sort((a, b) => a.Order - b.Order);

      this.draftSongs = JSON.parse(JSON.stringify(this.album.Songs));
    });
  }

  buildUpsertAlbumCommand(albumModel: AlbumViewModel): UpsertAlbumCommand {
    const upsertAlbumCommand = new UpsertAlbumCommand();

    if (!albumModel) {
      albumModel = new AlbumViewModel();
      albumModel.Band = new BandPreviewModel();
      albumModel.Band.Id = window.history.state.bandId;
    }

    upsertAlbumCommand.EntityId = albumModel.Id;
    upsertAlbumCommand.BandId = albumModel.Band.Id;
    upsertAlbumCommand.Url = albumModel.Url;
    upsertAlbumCommand.Description = albumModel.Description;
    upsertAlbumCommand.StartRecordDate = albumModel.StartRecordDate
      ? new Date(albumModel.StartRecordDate)
      : null;
    upsertAlbumCommand.ReleaseDate = albumModel.ReleaseDate;
    upsertAlbumCommand.Title = albumModel.Title;

    const albumSongs = new Array<UpsertSongCommand>();

    if (albumModel.Songs && albumModel.Songs.length > 0) {
      albumModel.Songs.forEach((song) => {
        const songToUpsert = new UpsertSongCommand();

        songToUpsert.EntityId = song.Id;
        songToUpsert.AlbumId = song.AlbumId;
        songToUpsert.Order = song.Order;
        songToUpsert.Title = song.Title;

        albumSongs.push(songToUpsert);
      });
    }

    upsertAlbumCommand.Songs = albumSongs;

    return upsertAlbumCommand;
  }

  upsertAlbum() {
    this.album.Songs = [...this.draftSongs];

    this.albumService.upsert(this.album).subscribe((data) => {
      this.router.navigate(["albums/view/" + data.Id]);
    });
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
    this.potentialSong = new UpsertSongCommand();

    if (this.album.EntityId != null) {
      this.potentialSong.AlbumId = this.album.EntityId;
    }

    if (this.draftSongs && this.draftSongs.length > 0) {
      this.potentialSong.Order =
        this.draftSongs[this.draftSongs.length - 1].Order + 1;
    }
    else{
      this.potentialSong.Order = 1;
    }
  }

  resetSongTemplate() {
    this.potentialSong = null;
  }

  addSong() {
    this.draftSongs.push(this.potentialSong);
    this.resetSongTemplate();
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
