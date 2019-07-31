import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalResultComponent } from './final-result.component';

describe('FinalResultComponent', () => {
  let component: FinalResultComponent;
  let fixture: ComponentFixture<FinalResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinalResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinalResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
