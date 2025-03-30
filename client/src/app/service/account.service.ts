import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../models/usuario';
import { map } from 'rxjs'
import { idText } from 'typescript';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient)
  private url = `http://localhost:5240/api/account/`
  currentUser = signal<User | null>(null)

  login(username: string, password:string){
    return this.http.post<User>(this.url + 'login', {username, password}).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user)
        }
      })
    )
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  register(username: string, password: string, foto: string, funcao: string, dateBirth: string){
    return this.http.post(this.url + 'register', {username, password, foto ,funcao, dateBirth})
  }
}
