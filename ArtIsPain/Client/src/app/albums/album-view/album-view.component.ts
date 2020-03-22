import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.css']
})
export class AlbumViewComponent implements OnInit {

  album: AlbumViewModel;
  formattedReleaseDate: number;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.album = data.album;

      this.formattedReleaseDate = new Date(this.album.releaseDate).getFullYear();
  })}

}
