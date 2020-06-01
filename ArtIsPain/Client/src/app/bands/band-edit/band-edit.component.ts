import { Component, OnInit, AfterViewInit, ChangeDetectorRef } from "@angular/core";import { BandViewModel } from "../../models/band/BandViewModel";import { FormGroup } from "@angular/forms";import { Select, Store, Actions, ofActionSuccessful } from "@ngxs/store";import { BandEditState } from "../../_state/states/band-edit-state";import { Observable } from "rxjs";import { UpsertBandFormBuilder } from "../../_builders/form/upsert-band-form-builder";import { ApplyBandEditValidationRules } from "../../_state/actions/apply-band-edit-validation-rules";import { UpsertBand } from "../../_state/actions/upsert-band";import { Navigate } from "@ngxs/router-plugin";

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent implements OnInit, AfterViewInit {

  band: BandViewModel;
  bandUpsertForm: FormGroup;

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

    this.bandResponse$.subscribe(data => {

      this.band = data;
      this.formBuilder.Build(this.bandUpsertForm, data);

      this.store.dispatch(new ApplyBandEditValidationRules(this.bandUpsertForm));
    });
  }

  upsertBand() {
    this.store.dispatch(new UpsertBand(this.band.Id));
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
