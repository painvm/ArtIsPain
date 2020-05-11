import { ActivatedRoute } from '@angular/router';
import { BandViewModel } from 'src/app/models/band/BandViewModel';
import { Observable } from 'rxjs';
import { BandViewState } from 'src/app/_state/states/band-view-state';
import { Select, Store } from '@ngxs/store';
import { OnInit, Component } from '@angular/core';


@Component({
  selector: 'app-band',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css'],
})

export class BandViewComponent implements OnInit {
  band: BandViewModel;
  
  @Select(BandViewState.getBand) band$: Observable<BandViewModel>;

  constructor(
    private route: ActivatedRoute,
    private store: Store
  ) {
  }

  ngOnInit() {
    this.band$.subscribe(data => this.band = data);
  }
}
