using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Logica.Models
{
    public class Busqueda
    {
        [Key]
        public int Id { get; set; }

        public string NombreBuscado { get; set; }

        public bool Resultado { get; set; }

        public DateTime FechaBusqueda { get; set; } = DateTime.UtcNow;
    }
}
