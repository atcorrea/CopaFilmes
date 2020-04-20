import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Filme } from '../Filme';
import { Partida } from '../Partida'

@Injectable({
  providedIn: 'root'
})
export class CopaService {

  host: string = 'http://localhost:5000/api/copa';
  final: any;

  constructor(private client: HttpClient) { }

  getFilmes(): Filme[] {
    let filmes: Filme[] = []
    this.client.get(this.host + '/filmes').subscribe(resp => {
        (resp as Filme[]).map(filme => {
          filmes.push(new Filme(filme.id, filme.titulo, filme.ano, filme.nota))
        });
    })
    return filmes;
  }

  async processarCampeonato(selected: Filme[]){
     let data = await this.client.post<Partida>(this.host + '/disputar', selected).toPromise();
     this.final = data;
  }
}
