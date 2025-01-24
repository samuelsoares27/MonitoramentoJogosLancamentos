using MonitoramentoJogosLancamentos.Controllers;
using System.Text.Json.Serialization;

namespace MonitoramentoJogosLancamentos.Models
{
    public class Platform
    {
        [JsonPropertyName("platform")]
        public PlatformDetail PlatformDetail { get; set; }
    }
}
