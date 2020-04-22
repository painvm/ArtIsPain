import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { Observable } from 'rxjs';
import { BandViewState } from 'src/app/_state/states/band-view-state';


@Component({
  selector: 'app-band',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css'],
})

export class BandViewComponent implements OnInit {
  band: BandViewModel;
  state: Observable<BandViewState>;
  constructor(
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.band = data.band;
  });}
}
