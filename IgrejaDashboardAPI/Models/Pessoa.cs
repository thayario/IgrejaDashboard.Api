using System.ComponentModel.DataAnnotations;

namespace IgrejaDashboardAPI.Models;

public class Pessoa
{
    [Key]
    public int Codigo { get; set; }
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    public Sexo Sexo { get; set; } = Sexo.Masculino;
    public SituacaoPessoa Status { get; set; } = SituacaoPessoa.Visitante;
}
