using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using MonitoramentoJogosLancamentos.Models;
using System.Globalization;

namespace MonitoramentoJogosLancamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // Substitua pela sua chave da RAWG API
        private const string ApiKey = "f8b24cc9bcd14383bc5a06a144449b49";

        // Listar jogos com filtros
        [HttpGet]
        public async Task<IActionResult> GetGames(
            [FromQuery] string? startDate, // Data de início no formato DD/MM/AAAA
            [FromQuery] string? endDate,   // Data final no formato DD/MM/AAAA
            [FromQuery] int? platformId,   // ID da plataforma
            [FromQuery] string? genre,     // Gênero do jogo
            [FromQuery] string? ordering   // Ordenação
        )
        {
            string baseUrl = "https://api.rawg.io/api/games";

            // Converte as datas para o formato ISO 8601 (AAAA-MM-DD)
            if (!string.IsNullOrEmpty(startDate))
            {
                startDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                    .ToString("yyyy-MM-dd");
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                endDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                  .ToString("yyyy-MM-dd");
            }

            // Monta a query string dinâmica
            var queryParams = $"?key={ApiKey}";
            if (platformId.HasValue) queryParams += $"&platforms={platformId}";
            if (!string.IsNullOrEmpty(startDate)) queryParams += $"&dates={startDate},{endDate}";
            if (!string.IsNullOrEmpty(genre)) queryParams += $"&genres={genre}";
            if (!string.IsNullOrEmpty(ordering)) queryParams += $"&ordering={ordering}";

            using HttpClient client = new();
            try
            {
                var response = await client.GetAsync(baseUrl + queryParams);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var gameList = JsonSerializer.Deserialize<GameApiResponse>(responseBody);

                return Ok(gameList.Results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao buscar jogos: {ex.Message}" });
            }
        }

        // Listar todas as plataformas disponíveis
        [HttpGet("platforms")]
        public async Task<IActionResult> GetPlatforms()
        {
            string url = $"https://api.rawg.io/api/platforms?key={ApiKey}";

            using HttpClient client = new();
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var platforms = JsonSerializer.Deserialize<PlatformApiResponse>(responseBody);

                return Ok(platforms.Results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao buscar plataformas: {ex.Message}" });
            }
        }

        // Listar todos os gêneros disponíveis
        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            string url = $"https://api.rawg.io/api/genres?key={ApiKey}";

            using HttpClient client = new();
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var genres = JsonSerializer.Deserialize<GenreApiResponse>(responseBody);

                return Ok(genres.Results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao buscar gêneros: {ex.Message}" });
            }
        }
    }

}

