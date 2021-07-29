import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BandSearchComponent } from './band-search.component';

describe('BandSearchComponent', () => {
  let component: BandSearchComponent;
  let fixture: ComponentFixture<BandSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BandSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BandSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
