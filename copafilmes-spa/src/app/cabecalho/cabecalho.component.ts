import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  @Input() mensagemFase: string;
  @Input() mensagemInstrucao: string;
  
  constructor() { }

  ngOnInit(): void {
  }

}
