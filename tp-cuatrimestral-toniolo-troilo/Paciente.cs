using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class Paciente: Persona
    {
        public int ObraSocial { get; set; }

        public Paciente(string nombre, string apellido, string sexo, DateTime fechaNacimiento, int dni, string email, int obraSocial)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Sexo = sexo;
            DNI = dni;
            ObraSocial = obraSocial;
        }
        public Paciente()
        { 
        
        }
    }
}