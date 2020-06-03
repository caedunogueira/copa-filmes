import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Filme } from './filme';
import { CopaMundo } from './copamundo';

@Injectable({
  providedIn: 'root'
})
export class CopamundoService {

  private enderecoAPI = 'http://localhost:5000/api/copamundo';

  constructor(private http: HttpClient) { }

  obterFilmes(): Observable<Filme[]> {
    const url = `${this.enderecoAPI}/filmes-disponiveis`;
    
    return this.http.get<Filme[]>(url).pipe(
      catchError(this.handleError<Filme[]>([]))
    );
  }

  obterResultado(ids: string): Observable<CopaMundo> {
    const url = `${this.enderecoAPI}/jogar/${ids}`;

    return this.http.get<CopaMundo>(url).pipe(
      catchError(this.handleError<CopaMundo>())
    );
  }

  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    }
  }
}
