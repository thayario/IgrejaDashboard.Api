using IgrejaDashboardAPI.DTOs;
using IgrejaDashboardAPI.Models;

namespace IgrejaDashboardAPI.Services
{
    public interface IPessoaService
    {
        Task<Pessoa> CriarPessoa(PessoaDto pessoaDto);
        Task<List<Pessoa>> ListarPessoas(string buscaPorNomeOuEmail);
        Task<DashboardTotaisDto> ObterTotaisDashboard();
        Task<Pessoa> EditarPessoa(int codigoPessoa, PessoaDto pessoaDto);
        Task<bool> RemoverPessoa(int codigoPessoa);
    }
}
