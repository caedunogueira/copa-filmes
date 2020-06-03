import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CopamundoService } from '../copamundo.service';
import { CopaMundo } from '../copamundo';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  copaMundo: CopaMundo;

  constructor(
    private route: ActivatedRoute,
    private copaMundoService: CopamundoService
  ) { }

  ngOnInit(): void {
    this.obterResultado();
  }

  private obterResultado(): void {
    const ids = this.route.snapshot.paramMap.get('ids');
    this.copaMundoService.obterResultado(ids)
      .subscribe(copaMundo => this.copaMundo = copaMundo);
  }
}
