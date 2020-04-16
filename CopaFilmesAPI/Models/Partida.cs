using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmesAPI.Models
{
    public class Partida
    {
        private Filme _jogador1;
        private Filme _jogador2;
        private Filme _vencedor;
        private Filme _perdedor;

        public Partida(Filme jogador1, Filme jogador2)
        {
            this._jogador1 = jogador1;
            this._jogador2 = jogador2;
            Competir();
        }
        
        public Filme Jogador1
        {
            get { return _jogador1; }
            set { _jogador1 = value; }
        }
                
        public Filme Jogador2
        {
            get { return _jogador2; }
            set { _jogador2 = value; }
        }        
        public Filme Vencedor
        {
            get { return _vencedor; }
            set { _vencedor = value; }
        }

        public Filme Perdedor
        {
            get { return _perdedor; }
            set { _perdedor = value; }
        }
                
        private void Competir()
        {
            Console.WriteLine("Partida:");
            Console.WriteLine($"{_jogador1.Titulo} (Nota: {_jogador1.Nota}) contra {_jogador2.Titulo} (Nota: {_jogador2.Nota})");

            var competidores = new List<Filme>() {_jogador1, _jogador2};
            competidores = competidores.OrderByDescending(x => x.Nota).ThenBy(x => x.Titulo).ToList();

            _vencedor = competidores[0];
            _perdedor = competidores[1];

            Console.WriteLine($"{_vencedor.Titulo} venceu!");            
        }
    }
}