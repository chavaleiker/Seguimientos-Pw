using System.ComponentModel.DataAnnotations;

namespace Actividad.Models
{
    public class Jugador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Escribe tu nombre completo.")]
        [StringLength(80, MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escribe tu correo electrónico.")]
        [EmailAddress(ErrorMessage = "Ingresa un correo válido.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecciona una categoría.")]
        public string Categoria { get; set; } = string.Empty;

        [Range(8, 100, ErrorMessage = "La edad debe estar entre 8 y 100 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Selecciona tu nivel de juego.")]
        public string Nivel { get; set; } = string.Empty;

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
    }
}