import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';


@Component({
  selector: 'app-band',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css'],
})

export class BandViewComponent implements OnInit {
  band: BandViewModel;

  constructor(
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.band = data.band;
  });}
}
