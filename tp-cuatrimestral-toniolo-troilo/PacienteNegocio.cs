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

        public void Modificar(Paciente paciente)
        {
            AccesoDB db = new AccesoDB();
            try
            {
                db.setQuery("update Pacientes set Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, FechaNacimiento = @FechaNacimiento, Email = @Email, ObraSocial = @ObraSocial where Id = @Id");
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

        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select cast(IDPaciente as int) as IDPaciente, cast(Nombre as varchar) as Nombre, cast(Apellido as varchar) as Apellido, cast(DNI as int) as DNI, cast(FechaNacimiento as DateTime) as FechaNacimiento, cast(Email as varchar) as Email from Pacientes");
                datos.read();

                while (datos.Reader.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Reader["IDPaciente"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = (int)datos.Reader["DNI"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];

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