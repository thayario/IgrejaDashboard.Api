using IgrejaDashboardAPI.Data;
using IgrejaDashboardAPI.DTOs;
using IgrejaDashboardAPI.Models;
using IgrejaDashboardAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgrejaDashboardAPI.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: api/pessoas
        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> GetPessoas([FromQuery] string? search)
        {
            var pessoas = await _pessoaService.ListarPessoas(search);

            if (pessoas == null || pessoas.Count == 0)
                return NotFound("Nenhuma pessoa encontrada.");

            return Ok(pessoas);
        }

        // GET: api/pessoas/dashboard
        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardTotaisDto>> GetTotaisDashboard()
        {
            var totais = await _pessoaService.ObterTotaisDashboard();

            return Ok(totais);
        }

        // PUT: api/pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Pessoa>> PutPessoa(int codigo, PessoaDto pessoaDto)
        {
            var pessoa = await _pessoaService.EditarPessoa(codigo, pessoaDto);

            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            return pessoa;

        }

        // POST: api/pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PessoaDto pessoaDto)
        {

            var pessoa = await _pessoaService.CriarPessoa(pessoaDto);

            return pessoa;
        }

        // DELETE: api/pessoas/5
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeletePessoa(int codigo)
        {
            var pessoaRemovida = await _pessoaService.RemoverPessoa(codigo);

            if(pessoaRemovida == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            return Ok(new { mensagem = "Pessoa removida com sucesso." });

        }

    }
}
