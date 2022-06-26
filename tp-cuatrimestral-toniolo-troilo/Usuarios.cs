using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2,  
    }
    public class Usuarios
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Pass { get; set; }

        public int TipoUsuario { get; set; }

        public Usuarios(string user, string pass, int tipo)
        {
            Usuario = user;
            Pass = pass;
            TipoUsuario = tipo;
        }
    }
}
