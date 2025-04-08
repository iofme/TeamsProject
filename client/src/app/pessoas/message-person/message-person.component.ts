import { Message } from '../../models/message';
import { MessageService } from '../../service/message.service';
import { Member } from './../../models/member';
import { Component, inject, input, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-person',
  imports: [],
  templateUrl: './message-person.component.html',
  styleUrl: './message-person.component.css'
})
export class MessagePersonComponent implements OnInit {
@Input() usuario!: string
messageService = inject(MessageService)
message: Message[] = []

ngOnInit(): void {
  this.loadMessage()
}

loadMessage(){
  this.messageService.getMessages(this.usuario).subscribe({
    next: response => this.message = response
  })
}


}
