import { Component, OnInit, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { UpsertBandCommand } from 'src/app/commands/bands/upsert.band.command';
import { BandService } from 'src/app/_services/band.service';
import { MatDatepicker } from '@angular/material/datepicker';
import { NgForm, AbstractControl, FormGroup, FormBuilder } from '@angular/forms';
import { Store, Select, Actions, ofActionSuccessful, ofActionDispatched } from '@ngxs/store';
import { BandEditState } from 'src/app/_state/states/band-edit-state';
import { Observable } from 'rxjs';
import { UpsertBandFormBuilder } from 'src/app/_builders/form/upsert-band-form-builder';
import { ApplyBandEditValidationRules } from 'src/app/_state/actions/apply-band-edit-validation-rules';
import { BandEditResolver } from 'src/app/_resolvers/band-edit-resolver';
import { BandEditRules } from 'src/app/_rules/band/band-edit-rules';
import { UpsertBand } from 'src/app/_state/actions/upsert-band';
import { UpdateFormValue } from '@ngxs/form-plugin';
import { Navigate } from '@ngxs/router-plugin';

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent implements OnInit, AfterViewInit {

  band: UpsertBandCommand;
  bandUpsertForm: FormGroup;

  @Select(BandEditState.getBand) band$: Observable<UpsertBandCommand>;
  @Select(BandEditState.getForm) form$: Observable<any>;
  @Select(BandEditState.getBandResponse) bandResponse$: Observable<BandViewModel>;

  constructor(private changeDetector: ChangeDetectorRef,
    private store: Store,
    private formBuilder: UpsertBandFormBuilder,
    private actions$: Actions) { }

  ngAfterViewInit(): void {
    this.changeDetector.detectChanges();
  }

  ngOnInit() {

    this.initializeRouteHandler();
    this.bandUpsertForm = this.formBuilder.Initialize();

    this.band$.subscribe(data => {

      this.band = data;
      this.formBuilder.Populate(this.bandUpsertForm, data);

      this.store.dispatch(new ApplyBandEditValidationRules(this.bandUpsertForm));
    });
  }

  upsertBand() {
    this.store.dispatch(new UpsertBand(this.band.EntityId));
  }

  initializeRouteHandler() {
    this.actions$.pipe(ofActionSuccessful(UpsertBand))
      .subscribe(() => this.bandResponse$.subscribe(
        data => {
          const bandId = data.Id;
          this.store.dispatch(new Navigate(['/bands/view/' + bandId]))
        }));
  }
}
