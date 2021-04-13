import { Account } from './account';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  accounts: Account[] = [
    {
      id: 1,
      nome: 'Pedro Henrique',
      email: 'pedro@gmail.com',
      pwd: 'senha',
      dtn: new Date(),
      genero: 'Masculino',
    }, {
      id: 2,
      nome: 'Lorem Ipsum',
      email: 'lorem@ipsum.com',
      pwd: 'senha',
      dtn: new Date(),
      genero: 'Neutro',
    }, {
      id: 3,
      nome: 'Dolor Sit',
      email: 'dolor@sit.com',
      pwd: 'senha',
      dtn: new Date(),
      genero: 'Neturo',
    },
  ];

  constructor() {}

  getAccounts(): Account[] {
    return this.accounts;
  }
}
