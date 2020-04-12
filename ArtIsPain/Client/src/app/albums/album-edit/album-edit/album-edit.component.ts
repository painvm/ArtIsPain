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
      this.album.Songs.sort((a, b) => a.Order - b.Order);
  }
  )}

  buildUpsertAlbumCommand(albumModel: AlbumViewModel): UpsertAlbumCommand
  {
    const upsertAlbumCommand = new UpsertAlbumCommand();

    upsertAlbumCommand.EntityId = albumModel.Id;
    upsertAlbumCommand.BandId = albumModel.Band.Id;
    upsertAlbumCommand.Url = albumModel.Url;
    upsertAlbumCommand.Description = albumModel.Description;
    upsertAlbumCommand.StartRecordDate = albumModel.StartRecordDate ? new Date(albumModel.StartRecordDate) : null;
    upsertAlbumCommand.ReleaseDate = albumModel.ReleaseDate;
    upsertAlbumCommand.Title = albumModel.Title;

    const albumSongs = new Array<UpsertSongCommand>();

    albumModel.Songs.forEach(song => {
      const songToUpsert = new UpsertSongCommand();

      songToUpsert.EntityId = song.Id;
      songToUpsert.AlbumId = song.AlbumId;
      songToUpsert.Order = song.Order;
      songToUpsert.Title = song.Title;

      albumSongs.push(songToUpsert);
    });

    upsertAlbumCommand.Songs = albumSongs;

    return upsertAlbumCommand;
  }

   upsertAlbum() {
    this.albumService.upsert(this.album).subscribe(data => {
      this.router.navigate(['/albums/' + data.Id]);
    })
  }

  reorderSongs(){
    this.album.Songs.forEach(song => {
      song.Order = this.album.Songs.indexOf(song) + 1;
    });
  }

  drop(event: CdkDragDrop<string[]>) 
  {
    moveItemInArray(this.album.Songs, event.previousIndex, event.currentIndex);
    this.reorderSongs();
  }
}


