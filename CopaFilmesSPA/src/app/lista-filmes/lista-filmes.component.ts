import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Filme } from '../Filme';
import { Router } from '@angular/router';
import { CopaService } from '../_services/copa.service';

@Component({
  selector: 'app-lista-filmes',
  templateUrl: './lista-filmes.component.html',
  styleUrls: ['./lista-filmes.component.css']
})
export class ListaFilmesComponent implements OnInit {
  
  tituloPagina: string = "Fase de Seleção";
  mensagemPagina: string = "Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.";
  host: string = 'http://localhost:5000/api/copa';

  filmes: Filme[] = [];
  selected: Filme[] = [];
  allMoviesSelected: boolean;

  constructor(private client: HttpClient,
              private router: Router,
              private copa: CopaService) { }

  ngOnInit() {
    this.filmes = this.copa.getFilmes();
  }

  addToSelectedMovieToList(filme: Filme, event: any): void {
    let item = this.filmes.find(x => x.id === filme.id);
    item.selected = event.target.checked;
    this.selected = this.filmes.filter(x => x.selected);
    this.allMoviesSelected = this.selected.length == 8;
  }

  async gerarMeuCampeonato() {
    await this.copa.processarCampeonato(this.selected);
    this.router.navigate(['/resultado']);
  }
}
