using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class LogAgua
    {
        public int Id { get; set; }

        public double Quantidade { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
