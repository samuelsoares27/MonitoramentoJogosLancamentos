using MonitoramentoJogosLancamentos.Controllers;
using System.Text.Json.Serialization;

namespace MonitoramentoJogosLancamentos.Models
{
    public class Game
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("released")]
        public string Released { get; set; }

        [JsonPropertyName("platforms")]
        public Platform[] Platforms { get; set; }
    }
}
