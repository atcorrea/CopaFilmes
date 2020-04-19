import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-lista-filmes',
  templateUrl: './lista-filmes.component.html',
  styleUrls: ['./lista-filmes.component.css']
})
export class ListaFilmesComponent implements OnInit {

  filmes: any;

  constructor(private client: HttpClient) { }

  ngOnInit() {
    this.getFilmes();
  }

  getFilmes() {
    this.client.get('http://localhost:5000/api/copa/filmes').subscribe(resp => {
        this.filmes = resp;
    }, error => {
      console.log(error);
    })
  }
}
