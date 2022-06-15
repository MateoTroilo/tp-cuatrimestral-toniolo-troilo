using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class Turno  
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public string Paciente { get; set; }

        public string Medico { get; set; }

        public string Especialidad { get; set; }

        public string Observacion { get; set; }
    }
}
