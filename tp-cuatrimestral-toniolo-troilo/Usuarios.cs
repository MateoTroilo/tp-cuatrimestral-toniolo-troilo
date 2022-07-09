using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        MEDICO = 2,
        RECEPCIONISTA = 3
    }
    public class Usuarios : Persona
    {
        public string Usuario { get; set; }

        public string Pass { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuarios(string user, string pass, TipoUsuario tipo)
        {
            Usuario = user;
            Pass = pass;
            TipoUsuario = tipo;
        }
    }
}
