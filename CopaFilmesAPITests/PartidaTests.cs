using CopaFilmesAPI.Models;
using FluentAssertions;
using Xunit;

namespace CopaFilmesAPITests
{
    public class PartidaTests
    {
        [Fact]
        public void TestPartida_Quando_NotasSaoDiferentes()
        {
            //arrange
            var filme1 = new Filme() {Titulo = "Mad Max", Nota = 9.0m};
            var filme2 = new Filme() {Titulo = "Transformers 5", Nota = 2.0m};

            //act
            var ptd = new Partida(filme1, filme2);

            //assert
            ptd.Vencedor.Should().Be(filme1);
        }

        [Theory]
        [InlineData("Avatar", "Zootopia", "Avatar")]
        [InlineData("Velozes e Furiosos", "Transformers", "Transformers")]
        [InlineData("Star Wars", "Star Trek", "Star Trek")]
        public void TestPartida_Quando_NotasSaoIguais(string filme1, string filme2, string vencedor)
        {
            //arrange
            var jogador1 = new Filme() {Titulo = filme1, Nota = 7.0m};
            var jogador2 = new Filme() {Titulo = filme2, Nota = 7.0m};

            //act
            var ptd = new Partida(jogador1, jogador2);

            //assert
            ptd.Vencedor.Titulo.Should().Be(vencedor);
        }
    }
}