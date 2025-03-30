import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient)
  private url = `http://localhost:5240/api/account/`

  login(username: string, password:string){
    return this.http.post(this.url + 'login', {username, password})
  }

  register(username: string, password: string, foto: string, funcao: string, dateBirth: string){
    return this.http.post(this.url + 'register', {username, password, foto ,funcao, dateBirth})
  }
}
