import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAlternativeComponent } from './edit-alternative.component';

describe('EditAlternativeComponent', () => {
  let component: EditAlternativeComponent;
  let fixture: ComponentFixture<EditAlternativeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditAlternativeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAlternativeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
