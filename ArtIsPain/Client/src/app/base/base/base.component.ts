import { Component, OnInit } from '@angular/core';
import { Actions } from '@ngxs/store';
import { Observable } from 'rxjs';
import { IViewModel } from '../../_interfaces/i-view-model';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export abstract class BaseComponent implements OnInit {

  constructor(
    entityStream: Observable<IViewModel>,
    entityLoadedFlagStream: Observable<boolean>) { }

  ngOnInit() {
  }

}
