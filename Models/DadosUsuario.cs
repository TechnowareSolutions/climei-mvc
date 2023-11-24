using System.ComponentModel.DataAnnotations.Schema;

namespace ClimeiMvc.Models
{
    public class DadosUsuario
    {
        public int Id { get; set; }

        public double Altura { get; set; }
        
        public double Peso { get; set; }

        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

    }
}
