import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Card } from '../models/card';
import { List } from '../models/list';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  http = inject(HttpClient)

  getCard(id:number){
    this.http.get<Card>(`http://localhost:5240/api/card/${id}`)
  }

  createCard(cardname: string, descricao: string, datafinal:string, prioridade: number, listaCardsId: number){
    return this.http.post<Card>(`http://localhost:5240/api/card`, {cardname, descricao, datafinal, prioridade, listaCardsId})
  }
}
