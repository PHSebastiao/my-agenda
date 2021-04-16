import { EventService } from './../shared/event.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoadingBarService } from '@ngx-loading-bar/core';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css'],
})
export class EventListComponent implements OnInit {
  headers = ['titulo', 'local', 'data', 'tipo'];
  events: any[] = [];

  constructor(
    private eventService: EventService,
    private router: Router,
    public loader: LoadingBarService
  ) {}

  ngOnInit(): void {
    this.reloadEvents();
  }
  reloadEvents(): any {
    this.eventService.getAll().subscribe((events) => {
      this.events = events;
      this.events.forEach((event) => {
        event.data = new Date(event.data).toJSON().slice(0, 10);
      });
    });
  }
  deleteEvent(event): any {
    this.eventService.delete(event.idevent).subscribe(() => {
      this.reloadEvents();
    });
  }
}
