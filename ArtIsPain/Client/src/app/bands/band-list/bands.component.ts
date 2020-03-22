import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BandService } from 'src/app/_services/band.service';
import { BandPreviewModel } from 'src/app/models/band/BandPreviewModel';

@Component({
  selector: 'app-bands',
  templateUrl: './bands.component.html',
  styleUrls: ['./bands.component.css']
})
export class BandsComponent implements OnInit {

  constructor(private bandService: BandService, private route: ActivatedRoute) {}
  bands: BandPreviewModel[];
  ngOnInit(): void {
  }

}
