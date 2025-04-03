using System.ComponentModel.DataAnnotations;
using WebApiCadastroFunc.Enums;

namespace WebApiCadastroFunc.Models
{
    public class FuncionariosModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DepartamentoEnums  Departamento { get; set; }

        public bool Ativo { get; set; }

        public TurnoEnums Turno { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
