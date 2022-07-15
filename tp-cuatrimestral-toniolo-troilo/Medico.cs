using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class Medico : Persona
    {
        public List<Especialidad> Especialidades { get; set; }

        public Horario Horario { get; set; }

        public Medico(string nombre, string apellido, string sexo, DateTime fechaNacimiento, int dni, string email, int horarioinicio, int horariofin, List<Dias> dias, List<Especialidad> especialidades)
        {
            Horario = new Horario();
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Sexo = sexo;
            DNI = dni;
            Especialidades = especialidades;
            Horario.Inicio = horarioinicio;
            Horario.Fin = horariofin;
            Horario.Dias = dias;
        }


        public Medico()
        {
            Horario = new Horario();
        }

    }

    
}