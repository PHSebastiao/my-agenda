import { EventService } from './../shared/event.service';
import { Component, OnInit } from '@angular/core';
import { Event } from '../shared/event';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  headers = ['titulo', 'local', 'dataInicio', 'tipo'];
  events: Event[] = [];

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.events = this.eventService.getAll();
  }
  deleteEvent(event): any {
    this.eventService.delete(event.id);
  }
}
