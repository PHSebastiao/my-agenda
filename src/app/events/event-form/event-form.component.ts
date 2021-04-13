import { AccountService } from './../../account/shared/account.service';
import { Account } from './../../account/shared/account';
import { EventService } from './../shared/event.service';
import { Event } from './../shared/event';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css'],
})
export class EventFormComponent implements OnInit {
  evento: Event;
  title = 'Novo evento';
  accounts: Account[] = [];
  meuForm;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private eventService: EventService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.accounts = this.accountService.getAccounts();
    const idPage = this.activatedRoute.snapshot.paramMap.get('id');
    if (idPage) {
      this.evento = this.eventService.getById(parseInt(idPage, 10));
      this.title = 'Editando evento';
      this.meuForm = new FormGroup({
        id: new FormControl(parseInt(idPage, 10)),
        titulo: new FormControl(this.evento.titulo),
        descricao: new FormControl(this.evento.descricao),
        tipo: new FormControl(this.evento.tipo),
        dataInicio: new FormControl(this.evento.dataInicio),
        dataFim: new FormControl(this.evento.dataFim),
        local: new FormControl(this.evento.local),
        participantes: new FormControl(this.evento.participantes),
      });
    } else {
      this.meuForm = new FormGroup({
        titulo: new FormControl(),
        descricao: new FormControl(),
        tipo: new FormControl('Compartilhado'),
        dataInicio: new FormControl(),
        dataFim: new FormControl(),
        local: new FormControl(),
        participantes: new FormControl(),
      });
    }
  }

  onSubmit(eventForm: Event): any {
    this.eventService.save(eventForm);
    this.router.navigate(['']);
  }
}
