using IgrejaDashboardAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace IgrejaDashboardAPI.DTOs
{
    public class PessoaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = "";

        public Sexo Sexo { get; set; } = Sexo.Masculino;

        public SituacaoPessoa Status { get; set; } = SituacaoPessoa.Visitante;
    }
}
