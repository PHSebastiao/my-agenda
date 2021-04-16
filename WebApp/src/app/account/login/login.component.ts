import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../shared/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  login = {
    email: '',
    password: '',
  };
  result;

  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit(): void {}

  async onSubmit(): Promise<any> {
    try {
      await this.accountService.login(this.login).subscribe((data: any) => {
        localStorage.setItem('token', data.token);
        this.router.navigate(['']);
      });
    } catch (err) {
      console.error(err);
    }
  }
}
