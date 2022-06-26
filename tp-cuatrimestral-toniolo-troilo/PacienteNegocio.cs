using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class PacienteNegocio
    {
        public void Agregar(Paciente paciente)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("insert into Pacientes(Nombre, Apellido, DNI, FechaNacimiento, Email, IDPlan) values(@Nombre, @Apellido, @DNI, @FechaNacimiento, @Email, @IDPlan)");
                db.setParametros("@Nombre", paciente.Nombre);
                db.setParametros("@Apellido", paciente.Apellido);
                db.setParametros("@DNI", paciente.DNI);
                db.setParametros("@FechaNacimiento", paciente.FechaNacimiento);
                //db.setParametros("@Sexo", paciente.Sexo);
                db.setParametros("@Email", paciente.Email);
                db.setParametros("@IDPlan", paciente.ObraSocial);

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