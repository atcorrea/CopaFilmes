import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import { ListaFilmesComponent } from './lista-filmes/lista-filmes.component'
import { ResultadoComponent } from './resultado/resultado.component'

const routes: Routes = [
  {path: 'selecao', component: ListaFilmesComponent},
  {path: 'resultado', component: ResultadoComponent},
  { path: '', redirectTo: '/selecao', pathMatch: 'full' },
]

@NgModule({
  exports: [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
