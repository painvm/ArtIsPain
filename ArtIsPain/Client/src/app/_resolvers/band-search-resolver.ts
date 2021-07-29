import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot } from "@angular/router";
import { Store } from "@ngxs/store";
import { Observable } from "rxjs";
import { BandCollectionViewModel } from "../models/band/BandCollectionViewModel";
import { BandViewModel } from "../models/band/BandViewModel";
import { IAction } from "../_interfaces/i-action";
import { SearchBand } from "../_state/actions/search-bands";
import { BaseResolver } from "./base-resolver";

@Injectable()
export class BandSearchResolver extends BaseResolver<BandCollectionViewModel> {


    constructor(store: Store) {
        super(store, new SearchBand());
        
    }

    performRequest(store: Store, route: ActivatedRouteSnapshot, action: SearchBand): Observable<BandCollectionViewModel> {
        return store.dispatch(action);
    }
}
