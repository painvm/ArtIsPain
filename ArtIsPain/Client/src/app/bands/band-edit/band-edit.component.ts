import { Component, OnInit, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { BandService } from 'src/app/_services/band.service';
import { MatDatepicker } from '@angular/material/datepicker';
import { NgForm, AbstractControl, FormGroup } from '@angular/forms';
import { Store, Select } from '@ngxs/store';
import { BandEditState } from 'src/app/_state/states/band-edit-state';
import { Observable } from 'rxjs';
import { UpsertBandFormBuilder } from 'src/app/_formBuilders/upsert-band-form-builder';

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent implements OnInit, AfterViewInit {

  band: UpsertBandCommand;
  bandUpsertForm: FormGroup;

  @Select(BandEditState.getBandToUpsert) band$: Observable<UpsertBandCommand>;

  constructor(private changeDetector: ChangeDetectorRef,
    private route: ActivatedRoute,
    private router: Router,
    private bandService: BandService,
    private store: Store) { }

  ngAfterViewInit(): void {
    this.changeDetector.detectChanges();
  }

  ngOnInit() {
    this.band$.subscribe(band => {
      this.band = band;
      this.bandUpsertForm = UpsertBandFormBuilder.CreateNewForm(this.band);
    })
  }

  upsertBand() {
    this.bandService.upsert(this.band).subscribe(data => {
      this.router.navigate(['/bands/view/' + data.Id]);
    })
  }
}