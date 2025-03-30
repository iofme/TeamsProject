import { Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  {path: '', component: ListComponent},
  {path: 'login', component: LoginComponent}
];
