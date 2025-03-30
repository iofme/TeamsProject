import { Card } from './../models/card';
import { CardService } from './../service/card.service';
import { Component, ElementRef, HostListener, OnChanges, OnInit, SimpleChanges, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ListService } from '../service/list.service';
import { List } from '../models/list';
import { CardComponent } from '../card/card.component';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule,FormsModule,CardComponent],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  lists: List[] = [];
  listService = inject(ListService);
  cardService = inject(CardService)
  isModalOpen = false;
  currentList: List | null = null;
  teste = false
  cardSelected: boolean = false
  cardId!: number

  nomeLista: string = ''
  cardname: string = ''
  descricao: string = ''
  datafinal: string = ''
  prioridade: number = 0


  @HostListener('document:click', ['$event'])
  clickOutside(event: MouseEvent) {
    const containerElement = document.querySelector('.add-list-container');
    if (this.teste && containerElement &&
        !containerElement.contains(event.target as Node)) {
      this.cancelAddList();
    }
  }

  ngOnInit(): void {
    this.getLists();
  }

  getLists() {
    this.listService.getLists().subscribe({
      next: response => this.lists = response,
      error: error => console.error(error)
    });
  }

  openCard(idCard: number){
    this.cardSelected = true
    this.cardId = idCard
  }
  cancelCard(){
    this.cardSelected = false
  }

  openCardModal(list: List) {
    this.currentList = list;
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
    this.currentList = null;
  }

  deleteList(id: number){
    this.listService.deleteList(id).subscribe({
      next:_ => this.getLists()
    })
  }

  createCard() {
    if(!this.currentList?.id){
      return alert("Ocorreu um problema ao achar o id da lista")
    }
    console.log(this.currentList.id)
    this.cardService.createCard(this.cardname, this.descricao, this.datafinal, this.prioridade, this.currentList?.id).subscribe({
      next: _ => this.getLists(),
      error: error => console.error(error)
    })
  }

  addList(nomeLista: string) {
    this.teste = false
    this.listService.createList(nomeLista).subscribe({
      next: _ => {
        this.getLists()
      }
    })
  }


  startTeste(){
    this.teste = true
    this.nomeLista = ''
  }
  cancelAddList() {
    this.teste = false;
    this.nomeLista = '';
  }

}
