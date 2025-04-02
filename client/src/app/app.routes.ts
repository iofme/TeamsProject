import { Routes } from '@angular/router';
import { ListComponent } from './Organização/list/list.component';
import { LoginComponent } from './login/login.component';
import { PerfilComponent } from './perfil/perfil.component';
import { HomePessoasComponent } from './pessoas/home-pessoas/home-pessoas.component';

export const routes: Routes = [
  {path: '', component: ListComponent},
  {path: 'login', component: LoginComponent},
  {path: 'perfil', component: PerfilComponent },
  {path: 'pessoas', component: HomePessoasComponent}
];
