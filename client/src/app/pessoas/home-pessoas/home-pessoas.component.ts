import { Component, inject, OnInit } from '@angular/core';
import { UsuarioService } from '../../service/usuario.service';
import { Member } from '../../models/member';

@Component({
  selector: 'app-home-pessoas',
  imports: [],
  templateUrl: './home-pessoas.component.html',
  styleUrl: './home-pessoas.component.css'
})
export class HomePessoasComponent implements OnInit{
  private usuarioService = inject(UsuarioService)
  members: Member[] = []

  ngOnInit(): void {
    this.loadMember()
  }

  loadMember(){
    this.usuarioService.getUsuarios().subscribe({
      next: response => this.members = response,
      error: err => console.log(err)
    })
  }
}
