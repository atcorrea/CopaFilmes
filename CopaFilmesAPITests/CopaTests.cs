using System;
using FluentAssertions;
using Xunit;
using System.Linq;
using Bogus;
using CopaFilmesAPI.Models;
using System.Collections.Generic;

namespace CopaFilmesAPITests
{
    public class CopaTests
    {
        private Faker<Filme> _filmeFaker = new Faker<Filme>()
                                        .RuleFor(x => x.Titulo, f => f.Commerce.ProductName())
                                        .RuleFor(x => x.Ano, f => f.Random.Short(1900,2020))
                                        .RuleFor(x => x.Nota, f => Math.Round(f.Random.Decimal(0,10),1))
                                        .RuleFor(x => x.Id, f => f.Random.AlphaNumeric(9));

        [Fact]
        public void CadastrarCompetidores_Quando_NumeroDeCandidatosEstaCorreto()
        {   
            //arrange
            var filmes = _filmeFaker.Generate(8);
            var filmesOrdenados = filmes.OrderBy(x => x.Titulo);
            var copa = new Copa();
        
            //act
            var cadastrados = copa.CadastrarCompetidores(filmes);
        
            //assert
            cadastrados.Should().BeEquivalentTo(filmesOrdenados);            
        }

        [Fact]
        public void CadastrarCompetidores_Quando_NumeroDeCandidatosEImcompativel()
        {   
            //arrange
            var filmes = _filmeFaker.Generate(6);
            var copa = new Copa();
        
            //act-assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                copa.CadastrarCompetidores(filmes);
            });
                     
        }
        

        [Fact]
        public void PrepararPartida_Quando_HaCandidatosSuficientes()
        {
            //arrange
            var filmes = _filmeFaker.Generate(8);
            var copa = new Copa();
            
            //act
            var cadastrados = copa.CadastrarCompetidores(filmes);
            var eliminatorias = copa.PrepararPartidas();
            
            //assert
            eliminatorias[0].Jogador1.Should().Be(cadastrados[0]);
            eliminatorias[0].Jogador2.Should().Be(cadastrados[7]);
            
            eliminatorias[1].Jogador1.Should().Be(cadastrados[1]);
            eliminatorias[1].Jogador2.Should().Be(cadastrados[6]);

            eliminatorias[2].Jogador1.Should().Be(cadastrados[2]);
            eliminatorias[2].Jogador2.Should().Be(cadastrados[5]);

            eliminatorias[3].Jogador1.Should().Be(cadastrados[3]);
            eliminatorias[3].Jogador2.Should().Be(cadastrados[4]);
        }

        [Fact]
        //teste de mesa
        public void DisputarCopa_Quando_TodosOsParametrosEstaoCorretos()
        {
            //arrange
            var filmes = new List<Filme>();
            filmes.Add(new Filme() {Titulo = "Os Incríveis 2", Nota = 8.5m});
            filmes.Add(new Filme() {Titulo = "Jurassic World: Reino Ameaçado", Nota = 6.7m});
            filmes.Add(new Filme() {Titulo = "Oito Mulheres e um Segredo", Nota = 6.3m});
            filmes.Add(new Filme() {Titulo = "Hereditário", Nota = 7.8m});
            filmes.Add(new Filme() {Titulo = "Vingadores: Guerra Infinita", Nota = 8.8m});
            filmes.Add(new Filme() {Titulo = "Deadpool 2", Nota = 8.1m});
            filmes.Add(new Filme() {Titulo = "Han Solo: Uma História Star Wars", Nota = 7.2m});
            filmes.Add(new Filme() {Titulo = "Thor: Ragnarok", Nota = 7.9m});
            var copa = new Copa();

            var vencedor = filmes[4];
            var segundo = filmes[0];
            
            //act
            var cadastrados = copa.CadastrarCompetidores(filmes);
            var eliminatorias = copa.PrepararPartidas();
            var final = copa.DisputarCopa(eliminatorias);       
        
            //assert
            final.Vencedor.Should().Be(vencedor);
            final.Perdedor.Should().Be(segundo);
        }
        
    }
}
