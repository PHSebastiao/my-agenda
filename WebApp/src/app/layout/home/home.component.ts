import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'my-agenda';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  logOut(): any {
    localStorage.setItem('token', '');
    document.location.reload();
  }

}
