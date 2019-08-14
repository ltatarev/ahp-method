import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAlternativeComponent } from './add-alternative.component';

describe('AddAlternativeComponent', () => {
  let component: AddAlternativeComponent;
  let fixture: ComponentFixture<AddAlternativeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAlternativeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAlternativeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
