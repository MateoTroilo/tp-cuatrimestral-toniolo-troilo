using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{

    public enum Permisos
    {
        Admin,
        Medico,
        Recepcionista
    }

    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public int DNI { get; set; }

        public string Email { get; set; }
        public Permisos Permiso { get; set; }
    }
}
