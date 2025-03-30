import { Component, inject, Input, input, OnInit } from '@angular/core';
import { CardService } from '../service/card.service';
import { Card } from '../models/card';
import { CommonModule, NgClass } from '@angular/common';

@Component({
  selector: 'app-card',
  imports: [NgClass, CommonModule],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent implements OnInit{
@Input() idCard!: number
card!: Card

private cardService = inject(CardService)

ngOnInit(): void {
  this.loadCard()
}

loadCard(){
  this.cardService.getCard(this.idCard).subscribe({
    next: response => this.card = response,
    error: error => console.error(error)
  })
}
}
