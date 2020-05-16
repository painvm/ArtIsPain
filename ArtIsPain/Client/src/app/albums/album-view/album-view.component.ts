import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlbumViewModel } from 'src/app/models/album/AlbumViewModel';
import { AlbumViewState } from 'src/app/_state/states/album-view-state';
import { Observable } from 'rxjs';
import { Select } from '@ngxs/store';

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.css']
})
export class AlbumViewComponent implements OnInit {

  album: AlbumViewModel;
  formattedReleaseDate: number;

  @Select(AlbumViewState.getAlbum) album$: Observable<AlbumViewModel>;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.album$.subscribe(data => {
      this.album = data;
    })
  }
}

