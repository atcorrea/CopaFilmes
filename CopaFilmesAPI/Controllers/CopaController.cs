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

    }
}
