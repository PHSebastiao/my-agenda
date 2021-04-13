import { Injectable } from '@angular/core';
import { Event } from './event';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  events: Event[] = [
    {
      id: 1,
      tipo: 'Exclusivo',
      titulo: 'Evento 1',
      descricao: 'Evento  é um evento exclusivo',
      dataInicio: new Date(),
      dataFim: new Date(),
      local: 'Praça',
      participantes: [],
    },
  ];
  constructor() {}

  getAll(): Event[] {
    return this.events;
  }
  getById(id: number): Event {
    const event = this.events.find((value) => value.id === id);
    return event;
  }
  save(event: Event): any {
    if (event.id) {
      const eventArr = this.getById(event.id);
      eventArr.tipo = event.tipo;
      eventArr.titulo = event.titulo;
      eventArr.descricao = event.descricao;
      eventArr.dataInicio = event.dataInicio;
      eventArr.dataFim = event.dataFim;
      eventArr.local = event.local;
      eventArr.participantes = event.participantes;
    } else {
      if (this.events.length) {
        const lastId = this.events[this.events.length - 1].id;
        event.id = lastId + 1;
      } else {
        event.id = 1;
      }
      this.events.push(event);
    }
  }
  delete(id: number): any {
    const eventIndex = this.events.findIndex((value) => value.id === id);
    this.events.splice(eventIndex, 1);
  }
}
