import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { Filme } from '../filme';
import { CopamundoService } from '../copamundo.service';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {

  private idsFilmesSelecionados: string[] = [];

  filmes$: Observable<Filme[]>;

  constructor(private copaMundoService: CopamundoService) { }

  ngOnInit(): void {
    this.filmes$ = this.copaMundoService.obterFilmes();
  }

  alterarFilmesSelecionados(id: string, opcao: boolean): void {
    if (opcao)
      this.idsFilmesSelecionados.push(id);
    else {
      const indice = this.idsFilmesSelecionados.indexOf(id);
      if (indice !== -1)
        this.idsFilmesSelecionados.splice(indice, 1);
    }
  }
}
