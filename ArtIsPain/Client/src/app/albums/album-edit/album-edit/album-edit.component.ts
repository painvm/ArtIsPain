import { Component, OnInit } from '@angular/core';
import { AlbumService } from 'src/app/_services/album.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';
import { UpsertAlbumCommand } from 'src/app/commands/albums/upsert-album-command';

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

    return upsertAlbumCommand;
  }

   upsertAlbum() {
    this.albumService.upsertAlbum(this.album).subscribe(data => {
      this.router.navigate(['/albums/' + data.id]);
    })
  }


}


