import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoDatepickerComponent } from './demo-datepicker.component';

describe('DemoDatepickerComponent', () => {
  let component: DemoDatepickerComponent;
  let fixture: ComponentFixture<DemoDatepickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoDatepickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoDatepickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
