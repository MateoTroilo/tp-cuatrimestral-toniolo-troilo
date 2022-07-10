using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class EspecialidadNegocio
    {
        public void Agregar(Especialidad especialidad)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("insert into Especialidades(Nombre) values(@Nombre)");
                db.setParametros("@Nombre", especialidad.Nombre);
                db.run();
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

        public void Modificar(Especialidad especialidad)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("update Pacientes set Nombre = @Nombre where Id = @Id");
                db.setParametros("@Nombre", especialidad.Nombre);
                db.run();
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

        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setQuery("select IDEspecialidad, Nombre from Especialidades");
                datos.read();

                while (datos.Reader.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.ID = (int)datos.Reader["IDEspecialidad"];
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