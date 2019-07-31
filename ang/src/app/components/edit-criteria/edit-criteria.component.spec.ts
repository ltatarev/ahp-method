import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCriteriaComponent } from './edit-criteria.component';

describe('EditCriteriaComponent', () => {
  let component: EditCriteriaComponent;
  let fixture: ComponentFixture<EditCriteriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCriteriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCriteriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
