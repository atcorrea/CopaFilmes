using System.Collections.Generic;
using CopaFilmesAPI.Models;

namespace CopaFilmesAPI.Repository
{
    public interface IFilmesRepository
    {
        List<Filme> GetAll();
    }
}