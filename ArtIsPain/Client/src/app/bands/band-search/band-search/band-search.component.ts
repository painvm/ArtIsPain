import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { BaseComponent } from '../../../base/base-view/base.component';
import { BandCollectionViewModel } from '../../../models/band/BandCollectionViewModel';
import { BandSearchState } from '../../../_state/states/band-search-state';

@Component({
  selector: 'app-band-search',
  templateUrl: './band-search.component.html',
  styleUrls: ['./band-search.component.css']
})
export class BandSearchComponent extends BaseComponent {


  entity: BandCollectionViewModel;

  constructor(store: Store) { 
    super(store.select(BandSearchState.getBandSearchResults), store.select(BandSearchState.areBandSearchResultsLoaded))
  }

}
