using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public string? Sexo { get; set; }

        public DadosUsuario ?DadosUsuario { get; set; }

        public virtual ICollection<LogAgua> LogAgua { get; set; } = new List<LogAgua>();

        public virtual ICollection<LogTemperatura> LogTemperatura { get; set; } = new List<LogTemperatura>();

        public virtual ICollection<LogUmidade> LogUmidade { get; set; } = new List<LogUmidade>();

        public virtual ICollection<LogBatimentoOxigenacao> LogBatimentoOxigenacao { get; set; } = new List<LogBatimentoOxigenacao>();
    }
}
