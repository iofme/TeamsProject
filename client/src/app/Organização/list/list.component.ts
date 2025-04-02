import { Card } from '../../models/card';
import { CardService } from '../../service/card.service';
import { Component, ElementRef, HostListener, OnInit, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ListService } from '../../service/list.service';
import { List } from '../../models/list';
import { CardComponent } from '../card/card.component';
import { AccountService } from '../../service/account.service';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [CommonModule,FormsModule,CardComponent],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  lists: List[] = [];
  loading = true;
  error = '';
  listService = inject(ListService);
  accountsevice = inject(AccountService);
  cardService = inject(CardService);
  isModalOpen = false;
  currentList: List | null = null;
  teste = false;
  cardSelected: boolean = false;
  cardId!: number;

  nomeLista: string = '';
  cardname: string = '';
  descricao: string = '';
  datafinal: string = '';
  prioridade: number = 0;

  @HostListener('document:click', ['$event'])
  clickOutside(event: MouseEvent) {
    const containerElement = document.querySelector('.add-list-container');
    if (this.teste && containerElement &&
        !containerElement.contains(event.target as Node)) {
      this.cancelAddList();
    }
  }

  @HostListener('document:keydown.escape', ['$event'])
  handleEscapeKey(event: KeyboardEvent) {
    if (this.isModalOpen) {
      this.closeModal();
    }
    if (this.cardSelected) {
      this.cancelCard();
    }
    if (this.teste) {
      this.cancelAddList();
    }
  }

  ngOnInit(): void {
    this.getLists();
  }

  getLists() {
    this.loading = true;
    this.listService.getLists().subscribe({
      next: response => {
        this.lists = response;
        this.loading = false;
      },
      error: error => {
        console.error(error);
        this.error = 'Erro ao carregar listas. Tente novamente mais tarde.';
        this.loading = false;
      }
    });
  }

  openCard(idCard: number) {
    this.cardSelected = true;
    this.cardId = idCard;
  }

  cancelCard() {
    this.cardSelected = false;
  }

  openCardModal(list: List) {
    this.resetCardForm();
    this.currentList = list;
    this.isModalOpen = true;

    // Definir a data padrão como hoje
    const today = new Date();
    const yyyy = today.getFullYear();
    const mm = String(today.getMonth() + 1).padStart(2, '0');
    const dd = String(today.getDate()).padStart(2, '0');
    this.datafinal = `${yyyy}-${mm}-${dd}`;
  }

  closeModal() {
    this.isModalOpen = false;
    this.currentList = null;
    this.resetCardForm();
  }

  resetCardForm() {
    this.cardname = '';
    this.descricao = '';
    this.datafinal = '';
    this.prioridade = 0;
  }

  deleteList(id: number) {
    if (confirm('Tem certeza que deseja excluir esta lista e todos os seus cartões?')) {
      this.listService.deleteList(id).subscribe({
        next: _ => this.getLists(),
        error: error => {
          console.error(error);
          alert('Erro ao excluir a lista. Tente novamente.');
        }
      });
    }
  }

  createCard() {
    if (!this.cardname.trim()) {
      alert('O nome do cartão é obrigatório');
      return;
    }

    if (!this.currentList?.id) {
      alert("Ocorreu um problema ao achar o id da lista");
      return;
    }

    if (!this.prioridade) {
      this.prioridade = 1; // Define baixa prioridade como padrão
    }

    const user = this.accountsevice.currentUser();

    this.cardService.createCard(
      this.cardname,
      this.descricao,
      this.datafinal,
      this.prioridade,
      this.currentList.id,
      user
    ).subscribe({
      next: _ => {
        this.getLists();
        this.closeModal();
      },
      error: error => {
        console.error(error);
        alert('Erro ao criar o cartão. Tente novamente.');
      }
    });
  }

  addList(nomeLista: string) {
    if (!nomeLista.trim()) {
      alert('O nome da lista é obrigatório');
      return;
    }

    this.teste = false;
    this.listService.createList(nomeLista).subscribe({
      next: _ => {
        this.getLists();
      },
      error: error => {
        console.error(error);
        alert('Erro ao criar a lista. Tente novamente.');
      }
    });
  }

  startTeste() {
    this.teste = true;
    this.nomeLista = '';

    // Focar no input após renderização
    setTimeout(() => {
      const input = document.querySelector('.add-list-form input');
      if (input) {
        (input as HTMLInputElement).focus();
      }
    }, 0);
  }

  cancelAddList() {
    this.teste = false;
    this.nomeLista = '';
  }

  deleteCard(idCard: number) {
    if (confirm('Tem certeza que deseja excluir este cartão?')) {
      this.cardService.deleteCard(idCard).subscribe({
        next: _ => {
          this.getLists();
        },
        error: error => {
          console.error(error);
          alert('Erro ao excluir o cartão. Tente novamente.');
        }
      });
    }
  }
}
