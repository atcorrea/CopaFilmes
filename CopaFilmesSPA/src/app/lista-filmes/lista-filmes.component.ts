import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Filme } from './Filme';

@Component({
  selector: 'app-lista-filmes',
  templateUrl: './lista-filmes.component.html',
  styleUrls: ['./lista-filmes.component.css']
})
export class ListaFilmesComponent implements OnInit {

  host: string = 'http://localhost:5000/api/copa';

  filmes: Filme[] = [];
  selected: Filme[] = [];
  allMoviesSelected: boolean;

  constructor(private client: HttpClient) { }

  ngOnInit() {
    this.getFilmes();
  }

  getFilmes() {
    this.client.get(this.host + '/filmes').subscribe(resp => {
        (resp as Filme[]).map(filme => {
          this.filmes.push(new Filme(filme.id, filme.titulo, filme.ano, filme.nota))
        });
    }, error => {
      console.log(error);
    })
  }

  addToSelectedMovieToList(filme: Filme, event: any) {
    let item = this.filmes.find(x => x.id === filme.id);
    item.selected = event.target.checked;
    this.selected = this.filmes.filter(x => x.selected);
    this.allMoviesSelected = this.selected.length == 8;
  }

  processarCampeonato(){
    this.client.post(this.host + '/disputar', this.selected).subscribe(resp => {
      console.log(resp);
    })
  }
}
