import { Component, OnDestroy, OnInit } from '@angular/core';
import { Actions } from '@ngxs/store';
import { Observable, Subject } from 'rxjs';
import { distinctUntilChanged, take } from 'rxjs/operators';
import { IResponse } from '../../_interfaces/i-response';
import { IViewComponent } from '../../_interfaces/i-view-component';
import { IViewModel } from '../../_interfaces/i-view-model';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnInit, OnDestroy {

  constructor(
    public entityStream$: Observable<IResponse>,
    public entityLoadedFlagStream$: Observable<boolean>) { 

      this.entityLoadedFlagStream$.pipe(distinctUntilChanged()).subscribe(value => {
        if (value) {
          this.entityStream$.pipe(take(1)).subscribe(
            data => {
              this.entity = data;
              this.isPageLoaded = true;
            })
        }
      })

    }

    isPageLoaded: boolean = false;
    entity: IResponse;

    ngOnInit() {


    }

    private destroy$ = new Subject<void>();

    ngOnDestroy(): void {
      this.destroy$.next();
      this.destroy$.complete();
    }

}
