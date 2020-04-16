using CopaFilmesAPI.Repository;
using FluentAssertions;
using Xunit;

namespace CopaFilmesAPITests
{
    public class HttpFilmesRepositoryTests
    {
        [Fact]
        public void GetAll_Quando_ServidorResponde200()
        {
            //arrange
            var repo = new HttpFilmesRepository();
            
            //act
            var resp = repo.GetAll();

            //assert
            resp.Should().NotBeNullOrEmpty();   
        }
        
    }
}