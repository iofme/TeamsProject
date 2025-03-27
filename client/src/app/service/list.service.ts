import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { List } from '../models/list';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  private http = inject(HttpClient)

  getLists(){
    return this.http.get<List[]>('http://localhost:5240/api/listacards')
  }

  getList(id: number){
    return this.http.get<List>(`http://localhost:5240/api/listacards/${id}`)
  }

  deleteList(id: number){
    return this.http.delete<List>(`http://localhost:5240/api/listacards/${id}`)
  }

  createList(nomeLista: string){
    return this.http.post<List>('http://localhost:5240/api/listacards', {nomeLista})
  }
}
