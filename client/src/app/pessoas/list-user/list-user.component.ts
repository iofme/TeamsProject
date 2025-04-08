import { Member } from '../../models/member';
import { UsuarioService } from './../../service/usuario.service';
import { Component, inject, OnInit } from '@angular/core';
import { MensagensComponent } from "../mensagens/mensagens.component";
import { MessagePersonComponent } from "../message-person/message-person.component";

@Component({
  selector: 'app-list-user',
  imports: [MensagensComponent, MessagePersonComponent],
  templateUrl: './list-user.component.html',
  styleUrl: './list-user.component.css'
})
export class ListUserComponent implements OnInit {
 private usuarioService = inject(UsuarioService)
 usuarios: Member[] = [];


 ngOnInit(): void {
   this.getUsuarios()
 }

 getUsuarios(){
  this.usuarioService.getUsuarios().subscribe({
    next: response => this.usuarios = response,
    error: err => console.error(err)
  })
 }
}
