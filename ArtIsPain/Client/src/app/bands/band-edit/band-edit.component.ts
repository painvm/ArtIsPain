import { Component, OnInit, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { BandService } from 'src/app/_services/band.service';
import {MatDatepicker} from '@angular/material/datepicker';
import { NgForm, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent implements OnInit, AfterViewInit  {
  band: UpsertBandCommand;

  constructor(private changeDetector: ChangeDetectorRef, private route: ActivatedRoute, private router: Router, private bandService: BandService) { }

  ngAfterViewInit(): void {
    this.changeDetector.detectChanges();
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.band = this.buildUpsertBandCommand(data.band);
      console.log(this.band.FormationDate);
  }
  )}

  buildUpsertBandCommand(bandModel: BandViewModel): UpsertBandCommand
  {
    const upsertBandCommand = new UpsertBandCommand();

    if(!bandModel){
      return upsertBandCommand;
    }

    upsertBandCommand.EntityId = bandModel.Id;
    upsertBandCommand.Description = bandModel.Description;
    upsertBandCommand.FormationDate = bandModel.FormationDate ? new Date(bandModel.FormationDate) : null;
    upsertBandCommand.DisbandDate = bandModel.DisbandDate ? new Date(bandModel.DisbandDate) : null;
    upsertBandCommand.Name = bandModel.Name;

    return upsertBandCommand;
  }

   upsertBand() {
    this.bandService.upsert(this.band).subscribe(data =>{
      this.router.navigate(['/bands/view/' + data.Id]);
    })
  }
}