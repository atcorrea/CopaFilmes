import { Component, OnInit } from '@angular/core';
import { CopaService } from '../_services/copa.service'
import { Filme } from '../Filme';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  tituloPagina: string = "Resultado Final";
  mensagemPagina: string = "Veja o resultado final do Campeonato de filmes de forma simples e rápida";

  primeiro: Filme;
  segundo: Filme;
  
  constructor(private copa: CopaService) { }

  ngOnInit() {
    this.primeiro = this.copa.final.primeiro;
    this.segundo = this.copa.final.segundo;    
  }
}
