using System;
using System.Collections.Generic;
using System.Net.Http;
using CopaFilmesAPI.Models;
using Newtonsoft.Json;

namespace CopaFilmesAPI.Repository
{
    public class HttpFilmesRepository : IFilmesRepository
    {
        string DATA_URL = "http://copafilmes.azurewebsites.net/api/filmes";

        public List<Filme> GetAll()
        {
            try
            {
                var client =  new HttpClient();
                var resp = client.GetAsync(DATA_URL).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var content = resp.Content.ReadAsStringAsync().Result;
                    var filmes = JsonConvert.DeserializeObject<List<Filme>>(content);  
                    return filmes;
                }
                else
                {
                    throw new HttpRequestException();
                }                  
            }
            catch (HttpRequestException)
            {
                //Adicionar tratamento para quando requisição falhar
                Console.WriteLine("impossível recuperar lista de filmes, o servidor de dados não respondeu corretamente");
                throw;
            }
            catch (System.Exception)
            {                
                Console.WriteLine("Ocorreu um erro ao realizar a requisição");
                throw;
            }            
        }
    }
}