using System.Collections.Generic;
using System.Linq;
using System;

namespace CopaFilmesAPI.Models
{
    public class Copa
    {
        private List<Filme> _competidores;

        public List<Filme> CadastrarCompetidores(List<Filme> filmes)
        {
            if(filmes.Count % 4 != 0)
                throw new ArgumentOutOfRangeException("Número de jogadores incompatível!");

            _competidores = filmes.OrderBy(x => x.Titulo).ToList();
            return _competidores;
        }
        
        public List<Partida> PrepararPartidas()
        {
            var filmes = _competidores;
            var partidasEliminatoria = new List<Partida>();                        

            //ordenar primeiro com ultimo, segundo com penultimo, assim em diante
            for (int i = 0; i < filmes.Count / 2; i++)
                partidasEliminatoria.Add(new Partida(filmes[i], filmes[(filmes.Count - 1) - i]));
                            
            return partidasEliminatoria;
        }

        public Partida DisputarCopa(List<Partida> partidas)
        {
            if (partidas.Count == 1)
                return partidas.First();

            var vencedores = partidas.Select(x => x.Vencedor).ToList();
            
            var novaFase = new List<Partida>();            
            for (int i = 0; i < vencedores.Count; i = i + 2)
                novaFase.Add(new Partida(vencedores[i], vencedores[i + 1]));

            return DisputarCopa(novaFase);
        }
    }
}