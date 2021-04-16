import { AccountService } from '../../account/shared/account.service';
import { Account } from '../../account/shared/account';
import { EventService } from '../shared/event.service';
import { Event } from '../shared/event';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoadingBarService } from '@ngx-loading-bar/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-addform.component.html',
  styleUrls: ['./event-addform.component.css'],
})
export class EventAddFormComponent implements OnInit {
  evento: any = {};
  accounts: Account[] = [];
  hoje = new Date().toJSON().slice(0, 10);
  meuForm;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private eventService: EventService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.meuForm = this.evento;
  }

  onSubmit(): any {
    this.eventService.save(this.meuForm).subscribe(() => {
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate(['']);
    });
  }
}
