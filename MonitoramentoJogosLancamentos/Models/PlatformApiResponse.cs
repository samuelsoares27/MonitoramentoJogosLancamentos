using System.Text.Json.Serialization;

namespace MonitoramentoJogosLancamentos.Models
{
    public class PlatformApiResponse
    {
        [JsonPropertyName("results")]
        public Platform[] Results { get; set; }
    }
}
