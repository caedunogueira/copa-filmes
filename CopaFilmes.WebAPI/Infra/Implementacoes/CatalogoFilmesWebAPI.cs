using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaFilmes.WebAPI.Infra.Implementacoes
{
    public class CatalogoFilmesWebAPI : ICatalogoFilmes
    {
        private readonly HttpClient _httpClient;
        private readonly OpcoesCatalogoFilmes _opcoes;

        public CatalogoFilmesWebAPI(HttpClient httpClient, IOptions<OpcoesCatalogoFilmes> opcoes)
        {
            _httpClient = httpClient;
            _opcoes = opcoes.Value;
        }

        public async Task<IReadOnlyCollection<Filme>> ObterTodos()
        {
            var filmes = new List<Filme>();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync(_opcoes.EnderecoAPI);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var elementos = await JsonSerializer.DeserializeAsync<IEnumerable<JsonElement>>(stream);

                foreach (var elemento in elementos)
                    filmes.Add(CriarFilme(elemento));
            }

            return filmes;
        }

        public async Task<IReadOnlyCollection<Filme>> ObterPorIds(List<string> ids)
        {
            var filmes = new List<Filme>();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync(_opcoes.EnderecoAPI);

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var elementos = await JsonSerializer.DeserializeAsync<IEnumerable<JsonElement>>(stream);

                foreach (var elemento in elementos)
                {
                    if (ids.Contains(elemento.GetProperty("id").GetString()))
                        filmes.Add(CriarFilme(elemento));
                }
            }

            return filmes;
        }

        private Filme CriarFilme(JsonElement elemento)
        {
            return new Filme(elemento.GetProperty("id").GetString(),
                elemento.GetProperty("titulo").GetString(),
                elemento.GetProperty("ano").GetInt32(),
                elemento.GetProperty("nota").GetDecimal());
        }
    }
}