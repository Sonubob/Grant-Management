import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GrantProgramComponent } from './grant-program.component';

describe('GrantProgramComponent', () => {
  let component: GrantProgramComponent;
  let fixture: ComponentFixture<GrantProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GrantProgramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GrantProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
