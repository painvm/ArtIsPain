/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Album.viewComponent } from './album.view.component';

describe('Album.viewComponent', () => {
  let component: Album.viewComponent;
  let fixture: ComponentFixture<Album.viewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Album.viewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Album.viewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
