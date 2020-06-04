using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebAPI.Controllers
{
    [ApiController]
    public class CopaMundoController : ControllerBase
    {
        private const char SEPARADOR_VIRGULA_IDS_FILMES = ',';

        private readonly ICatalogoFilmes _catalogoFilmes;

        public CopaMundoController(ICatalogoFilmes catalogoFilmes) => _catalogoFilmes = catalogoFilmes;

        [HttpGet]
        [Route("api/[controller]/filmes-disponiveis")]
        public async Task<IActionResult> Get()
        {
            var filmes = await _catalogoFilmes.ObterTodos();

            return Ok(filmes);
        }

        [HttpGet]
        [Route("api/[controller]/jogar/{idsFilmesSelecionados}")]
        public async Task<IActionResult> Get(string idsFilmesSelecionados)
        {
            var copaMundo = new CopaMundo();
            
            var ids = idsFilmesSelecionados?.Split(SEPARADOR_VIRGULA_IDS_FILMES)?.ToList();
            if (ids.Count != CopaMundo.TOTAL_FILMES_OBRIGATORIO)
                return BadRequest($"Requisição incorreta pois não foi identificado {CopaMundo.TOTAL_FILMES_OBRIGATORIO} ids de filmes para o torneio.");

            var filmes = await _catalogoFilmes.ObterPorIds(ids);
            if (filmes.Count != CopaMundo.TOTAL_FILMES_OBRIGATORIO)
                return NotFound("Requisição inválida pois um ou mais filmes dentre os Ids informados não consta(m) no catálogo de filmes.");

            foreach (var filme in filmes)
                copaMundo.Adicionar(filme);

            copaMundo.Jogar();

            return Ok(copaMundo);
        }
    }
}
