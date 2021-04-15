import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../shared/account.service';

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css'],
})
export class CreateAccountComponent implements OnInit {
  emailRegex = /\S+@\S+\.\S+/;
  hoje = new Date().toJSON().slice(0, 10);
  formCA = {
    nome: '',
    email: '',
    password: '',
    genero: '',
    dtn: '',
  };
  login = {
    email: this.formCA.email,
    password: this.formCA.password,
  };


  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit(): void {}
  async onSubmit() {
    try {
      // await this.accountService.createAccount(this.formCA);
      // await this.accountService.login(this.login);

      // this.router.navigate(['']);
      console.log(this.formCA);
    } catch (err) {
      console.error(err);
    }
  }
}
