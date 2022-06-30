using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class Medico : Persona
    {
        public Especialidad Especialidad { get; set; }

        public Horario Horario { get; set; }
    }
}