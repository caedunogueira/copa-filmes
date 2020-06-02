
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IReadOnlyCollection<Filme>> ObterTodos()
        {
            throw new System.NotImplementedException();
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
                var elementosJson = await JsonSerializer.DeserializeAsync<IEnumerable<JsonElement>>(stream);

                foreach (var filmeAux in elementosJson)
                    filmes.Add(new Filme(filmeAux.GetProperty("id").GetString(),
                               filmeAux.GetProperty("titulo").GetString(),
                               filmeAux.GetProperty("ano").GetInt32(),
                               filmeAux.GetProperty("nota").GetDecimal()));

                filmes = filmes.Where(f => ids.Contains(f.Id)).ToList();
            }

            return filmes.AsReadOnly();
        }
    }
}
