/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BandsComponent } from "./BandsComponent";

describe('BandsComponent', () => {
  let component: BandsComponent;
  let fixture: ComponentFixture<BandsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BandsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
