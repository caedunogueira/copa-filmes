import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmesComponent } from './filmes/filmes.component';

const routes: Routes = [
  { path: '', redirectTo: '/copamundo', pathMatch: 'full'},
  { path: 'copamundo', component: FilmesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
