import { UsuarioService } from './../../service/usuario.service';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-list-user',
  imports: [],
  templateUrl: './list-user.component.html',
  styleUrl: './list-user.component.css'
})
export class ListUserComponent {
 private UsuarioService = inject(UsuarioService)
}
