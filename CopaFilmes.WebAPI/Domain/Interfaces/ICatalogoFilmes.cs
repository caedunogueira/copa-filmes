using CopaFilmes.WebAPI.Domain.Implementacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.WebAPI.Domain.Interfaces
{
    public interface ICatalogoFilmes
    {
        public Task<IReadOnlyCollection<Filme>> ObterPorIds(List<string> ids);
    }
}
