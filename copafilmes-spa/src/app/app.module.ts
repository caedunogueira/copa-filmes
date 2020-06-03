import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ConteudoComponent } from './conteudo/conteudo.component';
import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { FilmesComponent } from './filmes/filmes.component';
import { AppRoutingModule } from './app-routing.module';
import { ResultadoComponent } from './resultado/resultado.component';

@NgModule({
  declarations: [
    AppComponent,
    ConteudoComponent,
    CabecalhoComponent,
    FilmesComponent,
    ResultadoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
