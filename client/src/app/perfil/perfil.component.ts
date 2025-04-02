import { Component, inject, Input, OnInit } from '@angular/core';
import { Member } from '../models/member';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../service/usuario.service';

@Component({
  selector: 'app-perfil',
  imports: [CommonModule],
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css'
})
export class PerfilComponent implements OnInit {
  member!: Member
  private route = inject(ActivatedRoute)
  private userService = inject(UsuarioService)

  ngOnInit(): void {
    this.loadMember()
  }

loadMember(){
  this.userService.getUsuario().subscribe({
    next: response => this.member = response,
    error: error => console.log(error)
  })
}
}
