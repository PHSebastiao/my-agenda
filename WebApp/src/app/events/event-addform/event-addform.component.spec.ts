import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventAddFormComponent } from './event-addform.component';

describe('EventFormComponent', () => {
  let component: EventAddFormComponent;
  let fixture: ComponentFixture<EventAddFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventAddFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
