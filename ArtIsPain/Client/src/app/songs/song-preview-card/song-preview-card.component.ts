import { Component, OnInit, Input } from '@angular/core';
import { SongPreviewModel } from 'src/app/models/song/song-preview-model';

@Component({
  selector: 'app-song-preview-card',
  templateUrl: './song-preview-card.component.html',
  styleUrls: ['./song-preview-card.component.css']
})
export class SongPreviewCardComponent implements OnInit {
  @Input() song: SongPreviewModel;

  constructor() { }

  ngOnInit() {
  }

}
