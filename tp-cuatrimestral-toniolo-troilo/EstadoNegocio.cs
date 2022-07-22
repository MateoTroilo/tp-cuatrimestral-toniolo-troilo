using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class EstadoNegocio
    {

        public List<Estado> listar()
        {
            List<Estado> lista = new List<Estado>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setQuery("select IDEstado, Nombre from Estados");
                datos.read();

                while (datos.Reader.Read())
                {
                    Estado aux = new Estado();
                    aux.ID = (int)datos.Reader["IDEstado"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }
    }
}