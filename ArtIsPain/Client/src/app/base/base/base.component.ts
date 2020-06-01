import { Component, OnInit } from '@angular/core';
import { Actions } from '@ngxs/store';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export abstract class BaseComponent implements OnInit {

  constructor(private actions$: Actions) { }

  ngOnInit() {
  }

  public InitializeActionHandlers()
  {

  }

}
