using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class NivelTemperatura
    {
        public int Id { get; set; }

        public string Faixa { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAvaliacao { get; set; } = DateTime.Now;

        public virtual ICollection<LogTemperatura> LogTemperatura { get; set; } = new List<LogTemperatura>();
    }
}
