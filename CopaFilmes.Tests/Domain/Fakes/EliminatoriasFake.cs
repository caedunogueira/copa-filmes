
using CopaFilmes.WebAPI.Domain.Implementacoes;

namespace CopaFilmes.Tests.Domain.Fakes
{
    internal class EliminatoriasFake : Eliminatorias
    {
        internal EliminatoriasFake(CopaMundo copaMundo) : base(copaMundo)
        {
            _montouChaveamento = true;
        }
    }
}
