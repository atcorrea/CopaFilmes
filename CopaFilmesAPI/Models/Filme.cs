using Newtonsoft.Json;

namespace CopaFilmesAPI.Models
{
    public class Filme
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("ano")]
        public short Ano { get; set; }

        [JsonProperty("nota")]
        public decimal Nota { get; set; }

        public override string ToString()
        {
            return $"{Titulo} - {Nota}";
        }
    }
}