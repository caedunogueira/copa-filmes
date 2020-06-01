using CopaFilmes.WebAPI.Domain.Implementacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.WebAPI.Domain.Interfaces
{
    internal interface ICatalogoFilmes
    {
        public Task<IReadOnlyCollection<Filme>> ObterPorIds(List<string> ids);
    }
}
