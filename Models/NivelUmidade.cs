using System.ComponentModel.DataAnnotations;

namespace ClimeiMvc.Models
{
    public class NivelUmidade
    {
        public int Id { get; set; }

        public string Faixa { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAvaliacao { get; set; } = DateTime.Now;

        public virtual ICollection<LogUmidade> LogUmidade { get; set; } = new List<LogUmidade>();
    }
}
