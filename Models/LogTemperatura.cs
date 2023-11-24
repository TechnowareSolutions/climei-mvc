using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class LogTemperatura
    {
        public int Id { get; set; }

        public double Temperatura { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public int NivelTemperaturaId { get; set; }

        public NivelTemperatura? NivelTemperatura { get; set; }
    }
}
