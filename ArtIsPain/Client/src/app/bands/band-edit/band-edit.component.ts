import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { BandService } from 'src/app/_services/band.service';
import {MatDatepicker} from '@angular/material/datepicker';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent implements OnInit {
  band: UpsertBandCommand;

  constructor(private route: ActivatedRoute, private router: Router, private bandService: BandService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.band = this.buildUpsertBandCommand(data.band);
      console.log(this.band.FormationDate);
  }
  )}

  buildUpsertBandCommand(bandModel: BandViewModel): UpsertBandCommand
  {
    const upsertBandCommand = new UpsertBandCommand();

    upsertBandCommand.EntityId = bandModel.Id;
    upsertBandCommand.Description = bandModel.Description;
    upsertBandCommand.FormationDate = new Date(bandModel.FormationDate);
    upsertBandCommand.DisbandDate = new Date(bandModel.DisbandDate);
    upsertBandCommand.Name = bandModel.Name;

    return upsertBandCommand;
  }

   upsertBand() {
    this.bandService.upsert(this.band).subscribe(data =>{
      this.router.navigate(['/bands/' + data.Id]);
    })
  }


}


