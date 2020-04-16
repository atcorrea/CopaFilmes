using System.Collections.Generic;
using CopaFilmesAPI.Models;
using CopaFilmesAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaController : ControllerBase
    {
        private readonly IFilmesRepository _repository;

        public CopaController(IFilmesRepository repository){
            _repository = repository;
        }

        [HttpGet("filmes")]
        public JsonResult GetAllFilmes()
        {
            return new JsonResult(_repository.GetAll());
        }

        [HttpPost("disputar")]
        public JsonResult DisputarCopa([FromBody] List<Filme> filmes)
        {
            var copa = new Copa();
            var competidores = copa.CadastrarCompetidores(filmes);
            var partidas = copa.PrepararPartidas();
            var final = copa.DisputarCopa(partidas);

            return new JsonResult(new {primeiro = final.Vencedor, segundo = final.Perdedor});
        }

    }
}
