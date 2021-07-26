import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Select, Store } from '@ngxs/store';
import { OnInit, Component } from '@angular/core';
import { BandViewState } from '../../_state/states/band-view-state';
import { BandViewModel } from '../../models/band/BandViewModel';
import { BaseComponent } from '../../base/base/base.component';
import { IViewModel } from '../../_interfaces/i-view-model';
import { IViewComponent } from '../../_interfaces/i-view-component';


@Component({
  selector: 'app-band',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css'],
})

export class BandViewComponent extends BaseComponent{

  entity: BandViewModel;

  constructor(store: Store) {

    super(store.select(BandViewState.getBand), store.select(BandViewState.isBandLoaded));
  }

  ngOnInit(): void {
  }

  }
