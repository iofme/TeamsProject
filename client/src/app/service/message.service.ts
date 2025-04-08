import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Member } from '../models/member';
import { Message } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  http = inject(HttpClient)

  getMessages(username:string){
    return this.http.get<Message[]>(`http://localhost:5240/api/message/thread/${username}`)
  }
}
