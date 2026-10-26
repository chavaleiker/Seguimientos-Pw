namespace Actividad.Models
{
    public class RegistroJugadores
    {
        private readonly List<Jugador> jugadores = new();
        private int siguienteId = 1;

        public List<Jugador> ObtenerTodos()
        {
            return jugadores.OrderBy(j => j.Nombre).ToList();
        }

        public bool ExisteCorreo(string correo)
        {
            return jugadores.Any(j =>
                j.Correo.Equals(
                    correo,
                    StringComparison.OrdinalIgnoreCase));
        }

        public void Agregar(Jugador jugador)
        {
            jugador.Id = siguienteId++;
            jugador.FechaInscripcion = DateTime.Now;
            jugadores.Add(jugador);
        }

        public bool Eliminar(int id)
        {
            Jugador? jugador = jugadores.FirstOrDefault(j => j.Id == id);

            if (jugador == null)
                return false;

            jugadores.Remove(jugador);
            return true;
        }
    }
}