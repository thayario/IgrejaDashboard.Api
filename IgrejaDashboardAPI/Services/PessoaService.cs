using Azure;
using Humanizer;
using IgrejaDashboardAPI.Data;
using IgrejaDashboardAPI.DTOs;
using IgrejaDashboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IgrejaDashboardAPI.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly AppDbContext _appDbContext;
        public PessoaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Pessoa> CriarPessoa(PessoaDto pessoaDto)
        {

            var pessoa = new Pessoa
            {
                Nome = pessoaDto.Nome.ToUpper(),
                Email = pessoaDto.Email.ToUpper(),
                Sexo = pessoaDto.Sexo,
                Status = pessoaDto.Status
            };

            _appDbContext.Pessoas.Add(pessoa);
            await _appDbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<List<Pessoa>> ListarPessoas(string buscaPorNomeOuEmail)
        {
            var query = _appDbContext.Pessoas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(buscaPorNomeOuEmail))
            {
                buscaPorNomeOuEmail = buscaPorNomeOuEmail.ToLower();

                query = query.Where(pessoaBD =>
                        pessoaBD.Nome.ToLower().Contains(buscaPorNomeOuEmail) ||
                        pessoaBD.Email.ToLower().Contains(buscaPorNomeOuEmail)
                        );
            }

            return await query.ToListAsync();
        }

        public async Task<DashboardTotaisDto> ObterTotaisDashboard()
        {
            var totais = await _appDbContext.Pessoas
                .GroupBy(pessoaBD =>  1)
                .Select(grupoPessoa => new DashboardTotaisDto
                {
                    TotalMembros = grupoPessoa.Count(),
                    TotalMasculino = grupoPessoa.Count(pessoa => pessoa.Sexo == Sexo.Masculino),
                    TotalFeminino = grupoPessoa.Count(pessoa => pessoa.Sexo == Sexo.Feminino),
                })
                .FirstOrDefaultAsync();

            return totais;
        }

        public async Task<Pessoa> EditarPessoa(int codigoPessoa, PessoaDto pessoaDto)
        {

            var pessoa = await _appDbContext.Pessoas.FirstOrDefaultAsync(pessoaBD => pessoaBD.Codigo == codigoPessoa);

            if (pessoa == null)
            {
                return null;
            }

            pessoa.Nome = pessoaDto.Nome;
            pessoa.Email = pessoaDto.Email;
            pessoa.Sexo = pessoaDto.Sexo;
            pessoa.Status = pessoaDto.Status;

            _appDbContext.Pessoas.Update(pessoa);
            await _appDbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> RemoverPessoa(int codigoPessoa)
        {

            var pessoa = await _appDbContext.Pessoas.FirstOrDefaultAsync(pessoaBD => pessoaBD.Codigo == codigoPessoa);

            if (pessoa == null)
            {
                return false;
            }

            _appDbContext.Pessoas.Remove(pessoa);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

    }
}
