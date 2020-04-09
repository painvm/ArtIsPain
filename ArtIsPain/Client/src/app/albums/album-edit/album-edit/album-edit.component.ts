import { Component, OnInit } from '@angular/core';
import { AlbumService } from 'src/app/_services/album.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';
import { UpsertAlbumCommand } from 'src/app/commands/albums/upsert-album-command';
import { UpsertSongCommand } from 'src/app/commands/albums/upsert-song-command';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-album-edit',
  templateUrl: './album-edit.component.html',
  styleUrls: ['./album-edit.component.css']
})
export class AlbumEditComponent implements OnInit {
  album: UpsertAlbumCommand;

  constructor(private route: ActivatedRoute, private router: Router, private albumService: AlbumService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.album = this.buildUpsertAlbumCommand(data.album);
  }
  )}

  buildUpsertAlbumCommand(albumModel: AlbumViewModel): UpsertAlbumCommand
  {
    const upsertAlbumCommand = new UpsertAlbumCommand();

    upsertAlbumCommand.entityId = albumModel.id;
    upsertAlbumCommand.bandId = albumModel.band.id;
    upsertAlbumCommand.url = albumModel.url;
    upsertAlbumCommand.description = albumModel.description;
    upsertAlbumCommand.startRecordDate = albumModel.startRecordDate ? new Date(albumModel.startRecordDate) : null;
    upsertAlbumCommand.releaseDate = albumModel.releaseDate;
    upsertAlbumCommand.title = albumModel.title;

    const albumSongs = new Array<UpsertSongCommand>();

    albumModel.songs.forEach(song => {
      const songToUpsert = new UpsertSongCommand();

      songToUpsert.entityId = song.id;
      songToUpsert.albumId = song.albumId;
      songToUpsert.order = song.order;
      songToUpsert.title = song.title;

      albumSongs.push(songToUpsert);
    });

    upsertAlbumCommand.songs = albumSongs;

    return upsertAlbumCommand;
  }

   upsertAlbum() {
    this.albumService.upsertAlbum(this.album).subscribe(data => {
      this.router.navigate(['/albums/' + data.id]);
    })
  }

  reorderSongs(){
    this.album.songs.forEach(song => {
      song.order = this.album.songs.indexOf(song) + 1;
    });
  }

  drop(event: CdkDragDrop<string[]>) 
  {
    moveItemInArray(this.album.songs, event.previousIndex, event.currentIndex);
    this.reorderSongs();
  }
}


