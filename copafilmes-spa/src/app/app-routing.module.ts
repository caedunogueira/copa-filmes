import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmesComponent } from './filmes/filmes.component';
import { ResultadoComponent } from './resultado/resultado.component';

const routes: Routes = [
  { path: '', redirectTo: '/copamundo', pathMatch: 'full'},
  { path: 'copamundo', component: FilmesComponent },
  { path: 'copamundo/jogar/:ids', component: ResultadoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
