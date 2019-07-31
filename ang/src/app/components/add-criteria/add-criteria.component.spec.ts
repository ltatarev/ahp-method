import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCriteriaComponent } from './add-criteria.component';

describe('AddCriteriaComponent', () => {
  let component: AddCriteriaComponent;
  let fixture: ComponentFixture<AddCriteriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCriteriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCriteriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
