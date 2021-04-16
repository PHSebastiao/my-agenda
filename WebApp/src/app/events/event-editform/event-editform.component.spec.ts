import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventEditformComponent } from './event-editform.component';

describe('EventEditformComponent', () => {
  let component: EventEditformComponent;
  let fixture: ComponentFixture<EventEditformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventEditformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventEditformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
