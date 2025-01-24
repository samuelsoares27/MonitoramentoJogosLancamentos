using System.Text.Json.Serialization;

namespace MonitoramentoJogosLancamentos.Models
{
    public class GenreApiResponse
    {
        [JsonPropertyName("results")]
        public Genre[] Results { get; set; }
    }
}
