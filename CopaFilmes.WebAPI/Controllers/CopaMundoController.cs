using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.WebAPI.Controllers
{
    [ApiController]
    public class CopaMundoController : ControllerBase
    {
        private readonly ICatalogoFilmes _catalogoFilmes;

        public CopaMundoController(ICatalogoFilmes catalogoFilmes) => _catalogoFilmes = catalogoFilmes;

        [HttpGet]
        [Route("api/[controller]/filmes-disponiveis")]
        public async Task<IReadOnlyCollection<Filme>> Get()
        {
            var filmes = await _catalogoFilmes.ObterTodos();

            return filmes;
        }

        [HttpGet]
        [Route("api/[controller]/jogar/{idsFilmesSelecionados}")]
        public async Task<IActionResult> Get(string idsFilmesSelecionados)
        {
            var copaMundo = new CopaMundo();
            var ids = idsFilmesSelecionados?.Split(',')?.ToList();

            if (ids.Count != 8)
                return BadRequest("Requisição incorreta pois não foi identificado 8 ids de filmes para o torneio.");

            var filmes = await _catalogoFilmes.ObterPorIds(ids);

            foreach (var filme in filmes)
                copaMundo.Adicionar(filme);

            copaMundo.Jogar();

            return Ok(copaMundo);
        }
    }
}
