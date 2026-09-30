using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Agendamento.Models
{
    public class Paciente
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }

    }
}
