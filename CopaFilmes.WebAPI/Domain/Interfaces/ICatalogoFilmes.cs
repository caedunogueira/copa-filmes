using CopaFilmes.WebAPI.Domain.Implementacoes;
using System.Collections.Generic;

namespace CopaFilmes.WebAPI.Domain.Interfaces
{
    internal interface ICatalogoFilmes
    {
        public IReadOnlyCollection<Filme> ObterPorIds(List<string> ids);
    }
}
