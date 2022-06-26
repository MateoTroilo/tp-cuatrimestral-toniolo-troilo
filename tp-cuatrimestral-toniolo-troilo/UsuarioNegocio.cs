using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuarios usuario)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("select IDUsuario, IDPermiso from Usuarios where email = @user and dni = @pass");
                db.setParametros("@user", usuario.Usuario);
                db.setParametros("@pass", usuario.Pass);
                //db.setQuery("select idUsuario, idpermiso from Usuarios where idUsuario = 1");
                db.read();
                bool x = false;
                x = db.Reader.Read();

                if (x)
                {
                    usuario.Id = (int)db.Reader["IDUsuario"];
                    usuario.TipoUsuario = (int)db.Reader["IDPermiso"];
                    return true;
                }
                else 
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
