import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './service/account.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  private accountService = inject(AccountService)

  ngOnInit(): void {
    this.setCurrentUser()
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user')
    if(!userString) return;
    const user = JSON.parse(userString)
    this.accountService.currentUser.set(user)
  }
}
