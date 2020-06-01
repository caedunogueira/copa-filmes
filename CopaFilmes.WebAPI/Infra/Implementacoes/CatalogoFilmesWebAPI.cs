
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace CopaFilmes.WebAPI.Infra.Implementacoes
{
    internal class CatalogoFilmesWebAPI : ICatalogoFilmes
    {
        private readonly string _enderecoAPI;

        internal CatalogoFilmesWebAPI(string enderecoAPI) => _enderecoAPI = enderecoAPI;

        public IReadOnlyCollection<Filme> ObterPorIds(List<string> ids)
        {

            return new List<Filme>
            {
                new Filme("tt3606756", "Filme A", 2018, 10m),
                new Filme("tt4881806", "Filme B", 2018, 10m),
                new Filme("tt5164214", "Filme C", 2018, 10m),
                new Filme("tt7784604", "Filme D", 2018, 10m),
                new Filme("tt4154756", "Filme E", 2018, 10m),
                new Filme("tt5463162", "Filme F", 2018, 10m),
                new Filme("tt3778644", "Filme G", 2018, 10m),
                new Filme("tt3501632", "Filme H", 2018, 10m)
            };
        }
    }
}
