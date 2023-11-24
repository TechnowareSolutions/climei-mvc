using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class LogUmidade
    {
        public int Id { get; set; }

        public double Umidade { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public int NivelUmidadeId { get; set; }

        public NivelUmidade? NivelUmidade { get; set; }
    }
}
