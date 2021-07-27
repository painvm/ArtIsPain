import { AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Navigate } from '@ngxs/router-plugin';
import { Actions, ofActionSuccessful, Store } from '@ngxs/store';
import { Observable, Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';
import { IViewModel } from '../../../_interfaces/i-view-model';
import { UpsertAlbum } from '../../../_state/actions/upsert-album';
import { UpsertEntity } from '../../../_state/actions/upsert-entity';

@Component({
  selector: 'app-base-edit',
  templateUrl: './base-edit.component.html',
  styleUrls: ['./base-edit.component.css']
})
export class BaseEditComponent implements OnInit, OnDestroy, AfterViewInit {
    

  redirectPath: string;

    constructor(private changeDetector: ChangeDetectorRef,
      private actions$: Actions,
      public store: Store,
      public entityStream$: Observable<IViewModel>,
    public entityLoadedFlagStream$: Observable<boolean>,
    public upsertEntityAction: UpsertEntity
    ) { 

      this.initializeRouteHandler()

    }
    
    ngAfterViewInit(): void {
      this.changeDetector.detectChanges();
    }
  

  private destroy$ = new Subject<void>();


  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnInit(): void {


  }

  initializeRouteHandler() {
    this.actions$.pipe(ofActionSuccessful(this.upsertEntityAction), takeUntil(this.destroy$))
      .subscribe(() =>

        this.entityLoadedFlagStream$.pipe(takeUntil(this.destroy$)).subscribe(value => {
          if (value) {
            this.entityStream$.pipe(take(1)).subscribe(
              data => {
                const entityId = data.Id;
                this.store.dispatch(new Navigate([this.upsertEntityAction.redirectPath + entityId]))
              });
          }
        }))
  }

}
