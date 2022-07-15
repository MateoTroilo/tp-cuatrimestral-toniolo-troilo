using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public enum Dias
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado
    }
    public class Horario
    {
        public List<Dias> Dias { get; set; }

        public int Inicio { get; set; }

        public int Fin { get; set; }

        // Lunes / Miercoles / Viernes
        // 800
        // 1600
        // medico

        // list<Horario>
        public Horario()
        {
            Dias = new List<Dias>();
        }

    }

    

}