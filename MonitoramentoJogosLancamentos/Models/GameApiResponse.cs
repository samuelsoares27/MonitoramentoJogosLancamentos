using MonitoramentoJogosLancamentos.Controllers;
using System.Text.Json.Serialization;

namespace MonitoramentoJogosLancamentos.Models
{
    public class GameApiResponse
    {
        [JsonPropertyName("results")]
        public Game[] Results { get; set; }
    }
}
