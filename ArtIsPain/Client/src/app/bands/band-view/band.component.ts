import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Select, Store } from '@ngxs/store';
import { OnInit, Component } from '@angular/core';
import { BandViewState } from '../../_state/states/band-view-state';
import { BandViewModel } from '../../models/band/BandViewModel';
import { distinctUntilChanged, take } from 'rxjs/operators';


@Component({
  selector: 'app-band',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css'],
})

export class BandViewComponent implements OnInit {
  band: BandViewModel;

  @Select(BandViewState.getBand) bandResponse$: Observable<BandViewModel>;
  @Select(BandViewState.isBandLoaded) isBandLoaded$: Observable<boolean>;


  constructor() {
  }

  ngOnInit() {

      this.isBandLoaded$.pipe(distinctUntilChanged()).subscribe(value => {
        if (value) {
          this.bandResponse$.pipe(take(1)).subscribe(
            data => {
              this.band = data;
            })
        }
      })
    }
  }
