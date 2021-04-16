import { EventService } from './../shared/event.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/account/shared/account.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-event-editform',
  templateUrl: './event-editform.component.html',
  styleUrls: ['./event-editform.component.css'],
})
export class EventEditformComponent implements OnInit {
  evento;
  hoje = new Date().toJSON().slice(0, 10);
  accounts: Account[] = [];
  meuForm;

  constructor(
    private eventService: EventService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.accountService.getAccounts().subscribe((data) => {
      this.accounts = data;
    });
    const idPage = this.activatedRoute.snapshot.paramMap.get('id');
    if (idPage) {
      this.eventService.getById(parseInt(idPage, 10)).subscribe((data) => {
        this.evento = data;
        this.evento.data = new Date(data.data).toJSON().slice(0, 10);
        this.meuForm = new FormGroup({
          idevent: new FormControl(parseInt(idPage, 10)),
          titulo: new FormControl(this.evento.titulo),
          tipo: new FormControl(this.evento.tipo),
          descricao: new FormControl(this.evento.descricao),
          data: new FormControl(this.evento.data),
          local: new FormControl(this.evento.local),
        });
      });
    }
    this.accountService.getAccounts().subscribe((data) => {
      this.accounts = data;
    });
  }

  onSubmit(): any {
    this.eventService.save(this.meuForm.value).subscribe(() => {
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate(['']);
    });
  }
}
