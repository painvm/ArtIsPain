import { Component, OnInit, AfterViewInit, ChangeDetectorRef, OnDestroy } from "@angular/core"; import { BandViewModel } from "../../models/band/BandViewModel"; import { FormGroup } from "@angular/forms"; import { Select, Store, Actions, ofActionSuccessful } from "@ngxs/store"; import { BandEditState } from "../../_state/states/band-edit-state"; import { Observable, Subject } from "rxjs"; import { UpsertBandFormBuilder } from "../../_builders/form/upsert-band-form-builder"; import { ApplyBandEditValidationRules } from "../../_state/actions/apply-band-edit-validation-rules"; import { UpsertBand } from "../../_state/actions/upsert-band"; import { Navigate } from "@ngxs/router-plugin";
import { map, takeUntil, distinctUntilChanged, take, takeWhile } from "rxjs/operators";
import { Route, Router } from "@angular/router";
import { BaseEditComponent } from "../../base/base-edit/base-edit/base-edit.component";

@Component({
  selector: 'app-band-edit',
  templateUrl: './band-edit.component.html',
  styleUrls: ['./band-edit.component.css']
})

export class BandEditComponent extends BaseEditComponent {

  band: BandViewModel;
  bandUpsertForm: FormGroup;

  @Select(BandEditState.getForm) form$: Observable<any>;
  @Select(BandEditState.getBandResponse) bandResponse$: Observable<BandViewModel>;
  @Select(BandEditState.isBandLoaded) isBandLoaded$: Observable<boolean>;

  constructor(changeDetector: ChangeDetectorRef,
    store: Store,
    public formBuilder: UpsertBandFormBuilder,
    actions$: Actions) {

    super(changeDetector,
      actions$,
      store,
      store.select(BandEditState.getBandResponse),
      store.select(BandEditState.isBandLoaded),
      UpsertBand)
  }

  ngOnInit() {

    this.bandUpsertForm = this.formBuilder.Initialize();

    this.isBandLoaded$.pipe(takeWhile(() => this.band === undefined)).subscribe(value => {
      if (value) {
        this.bandResponse$.pipe(take(1)).subscribe(
          data => {
            this.band = data;
            this.formBuilder.Build(this.bandUpsertForm, this.band);

            this.store.dispatch(new ApplyBandEditValidationRules(this.bandUpsertForm))
          })
      }
    })
  }

  upsertBand() {
    this.store.dispatch(new UpsertBand(this.band ? this.band.Id : null))
      .subscribe(() => this.bandUpsertForm.reset());;
  }
}
