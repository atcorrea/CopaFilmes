import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  tituloPagina: string = "Resultado Final";
  mensagemPagina: string = "Veja o resultado final do Campeonato de filmes de forma simples e rápida";
  
  constructor() { }

  ngOnInit() {
  }

}
