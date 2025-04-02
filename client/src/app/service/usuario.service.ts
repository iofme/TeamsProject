import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Member } from '../models/member';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  http = inject(HttpClient)

  getUsuario(){
    return this.http.get<Member>(`http://localhost:5240/api/usuario/logado`)
  }

  getUsuarios(){
    return this.http.get<Member[]>(`http://localhost:5240/api/usuario`)
  }
}
