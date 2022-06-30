using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class MedicoNegocio
    {
        public void Agregar(Medico medico)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("insert into Medicos(Nombre, Apellido, DNI, FechaNacimiento, Email, IDEspecialidad) values(@Nombre, @Apellido, @DNI, @FechaNacimiento, @Email, @IDEspecialidad)");
                db.setParametros("@Nombre", medico.Nombre);
                db.setParametros("@Apellido", medico.Apellido);
                db.setParametros("@DNI", medico.DNI);
                db.setParametros("@FechaNacimiento", medico.FechaNacimiento);
                //db.setParametros("@Sexo", paciente.Sexo);
                db.setParametros("@Email", medico.Email);
                db.setParametros("@IDEspecialidad", medico.Especialidad.ID);

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

        public void Modificar(Medico medico)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("update Pacientes set Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, FechaNacimiento = @FechaNacimiento, Email = @Email, ObraSocial = @ObraSocial where Id = @Id");
                db.setParametros("@Nombre", medico.Nombre);
                db.setParametros("@Apellido", medico.Apellido);
                db.setParametros("@DNI", medico.DNI);
                db.setParametros("@FechaNacimiento", medico.FechaNacimiento);
                //db.setParametros("@Sexo", paciente.Sexo);
                db.setParametros("@Email", medico.Email);
                db.setParametros("@IDEspecialidad", medico.Especialidad.ID);

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

    }
}
