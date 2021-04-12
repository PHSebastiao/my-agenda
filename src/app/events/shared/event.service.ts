import { Injectable } from '@angular/core';
import { Event } from './event';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  events: Event[] = [];
  constructor() {}

  // tslint:disable-next-line: typedef
  public getAll() {
    return this.events;
  }
}
