using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public enum Estados
    {
        Nuevo,
        Cancelado,
        NoAsistio,
        Cerrado
    }
    public class Turno
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public Estados Estado { get; set; }

        public string Paciente { get; set; }

        public string Medico { get; set; }

        public string Especialidad { get; set; }

        public string Observacion { get; set; }

        public Turno(DateTime fecha, Estados estado, string paciente, string medico, string especialidad, string observacion)
        {
            Fecha = fecha;
            Estado = estado;
            Paciente = paciente;
            Medico = medico;
            Especialidad = especialidad;
            Observacion = observacion;
        }

        public Turno()
        {

        }
    }
}
