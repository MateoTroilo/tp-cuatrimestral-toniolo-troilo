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
        public Dias dias { get; set; }

        public List<int> horas { get; set; }
        //800   (lunes)   
        //1600

        //900   (martes)
        //1300
    }
}