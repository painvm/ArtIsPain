/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { BandViewComponent } from './band.component';


describe('BandComponent', () => {
  let component: BandViewComponent;
  let fixture: ComponentFixture<BandViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BandViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BandViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
