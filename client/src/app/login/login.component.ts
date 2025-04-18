import { Component, inject } from '@angular/core';
import { AccountService } from '../service/account.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private accountService = inject(AccountService)
  private routes = inject(Router)

  usernamelogin!: string
  passwordlogin!: string

  login(){
    this.accountService.login(this.usernamelogin, this.passwordlogin).subscribe({
      next: _ => {alert("Login feito com sucesso")
        this.routes.navigateByUrl('')
      },
      error: error => alert(error.error)
    })
  }

  usernameRegister = '';
  passwordRegister = '';
  fotoRegister = '';
  funcaoRegister = '';
  dateBirthRegister = '';

  register(){
    this.accountService.register(this.usernameRegister, this.passwordRegister, this.fotoRegister, this.funcaoRegister, this.dateBirthRegister).subscribe({
      next: _ => alert("Usuario criado com sucesso"),
      error: error => console.log(error)
    })
  }

}
