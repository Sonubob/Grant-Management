import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveDialogComponentComponent } from './save-dialog-component.component';

describe('SaveDialogComponentComponent', () => {
  let component: SaveDialogComponentComponent;
  let fixture: ComponentFixture<SaveDialogComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaveDialogComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveDialogComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
