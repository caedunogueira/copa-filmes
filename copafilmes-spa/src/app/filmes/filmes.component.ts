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

  filmes: Filme[];
  listaIdsFilmesSelecionados: string = "";

  constructor(private copaMundoService: CopamundoService) { }

  ngOnInit(): void {
    this.obterFilmesDisponiveis();
  }

  private obterFilmesDisponiveis(): void {
    this.copaMundoService.obterFilmes()
      .subscribe(filmes => this.filmes = filmes);
  }

  totalFilmesSelecionados(): number {
    return this.idsFilmesSelecionados.length;
  }

  alterarFilmesSelecionados(elementoCheckBox: any, eventoCheckBox: any): void {
    if (elementoCheckBox.checked && this.idsFilmesSelecionados.length === 8) {
      elementoCheckBox.checked = false;
      eventoCheckBox.preventDefault();
    }
    else if (elementoCheckBox.checked)
      this.idsFilmesSelecionados.push(elementoCheckBox.id);
    else {
      const indice = this.idsFilmesSelecionados.indexOf(elementoCheckBox.id);
      if (indice !== -1)
        this.idsFilmesSelecionados.splice(indice, 1);
    }
    
    this.montarListaIdsFilmesSelecionados();
  }

  private montarListaIdsFilmesSelecionados(): void {
    this.listaIdsFilmesSelecionados = "";
    
    for (const id in this.idsFilmesSelecionados) {
      if (this.idsFilmesSelecionados.hasOwnProperty(id)) {
        const element = this.idsFilmesSelecionados[id];
        this.listaIdsFilmesSelecionados += `,${element}`
      }
    }

    this.listaIdsFilmesSelecionados = this.listaIdsFilmesSelecionados.substr(1);
  }
}