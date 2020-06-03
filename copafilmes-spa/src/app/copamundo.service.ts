import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Filme } from './filme';

@Injectable({
  providedIn: 'root'
})
export class CopamundoService {

  private enderecoAPI = 'http://localhost:5000/api/copamundo';

  constructor(private http: HttpClient) { }

  obterFilmes(): Observable<Filme[]> {
    const url = `${this.enderecoAPI}/filmes-disponiveis`;
    console.log('url requisitada: ' + url);
    return this.http.get<Filme[]>(url).pipe(
      catchError(this.handleError<Filme[]>([]))
    );
  }

  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    }
  }
}
