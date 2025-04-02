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
    return this.http.get<Card>(`http://localhost:5240/api/card/${id}`)
  }

  createCard(cardname: string, descricao: string, datafinal:string, prioridade: number, listaCardsId: number, createby: any){
    return this.http.post<Card>(`http://localhost:5240/api/card`, {cardname, descricao, datafinal, prioridade, listaCardsId, createby})
  }

  deleteCard(idCard: number){
    return this.http.delete<Card>(`http://localhost:5240/api/card/${idCard}`)
  }

  updateCardList(cardId: number, newListId: number) {
    return this.http.put<Card>(`http://localhost:5240/api/card/updatelist/${cardId}/${newListId}`, {})
  }
  
}
