import { Observable } from "rxjs";
import { IViewModel } from "./i-view-model";

export interface IViewComponent {
     entityStream$: Observable<IViewModel>,
     entityLoadedFlagStream$: Observable<boolean>
}