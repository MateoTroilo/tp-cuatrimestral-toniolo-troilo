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
                db.setQuery("insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Sexo, @Email, @IDPlan)");
                db.setParametros("@Nombre", paciente.Nombre);
                db.setParametros("@Apellido", paciente.Apellido);
                db.setParametros("@DNI", paciente.DNI);
                db.setParametros("@FechaNacimiento", paciente.FechaNacimiento);
                db.setParametros("@Sexo", paciente.Sexo);
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
                db.setQuery("update Pacientes set Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, FechaNacimiento = @FechaNacimiento, Email = @Email, ObraSocial = @ObraSocial where IDPaciente = @Id");
                db.setParametros("@Nombre", paciente.Nombre);
                db.setParametros("@Apellido", paciente.Apellido);
                db.setParametros("@DNI", paciente.DNI);
                db.setParametros("@FechaNacimiento", paciente.FechaNacimiento);
                db.setParametros("@Sexo", paciente.Sexo);
                db.setParametros("@Email", paciente.Email);
                db.setParametros("@IDPlan", paciente.ObraSocial);
                db.setParametros("@ID", paciente.Id);

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
                datos.setQuery("select IDPaciente, P.Nombre, Apellido, cast(DNI as int) as DNI, FechaNacimiento, Sexo, Email, O.Nombre as 'Obra Social' from Pacientes as P inner join ObrasSociales as O on O.IDObraSocial = P.IDObraSocial");
                datos.read();

                while (datos.Reader.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Reader["IDPaciente"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = (int)datos.Reader["DNI"];
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    //aux.ObraSocial = (string)datos.Reader["Obra Social"];

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

        public Paciente Buscar(int ID)
        {
            Paciente aux = new Paciente();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select IDPaciente, P.Nombre, Apellido, cast(DNI as int) as DNI, FechaNacimiento, Sexo, Email, O.Nombre as 'Obra Social' from Pacientes as P inner join ObrasSociales as O on O.IDObraSocial = P.IDObraSocial where IDPaciente = @ID");
                datos.setParametros("@ID", ID);
                datos.read();

                while (datos.Reader.Read())
                {
                    aux.Id = (int)datos.Reader["IDPaciente"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = (int)datos.Reader["DNI"];
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    //aux.ObraSocial = (string)datos.Reader["Obra Social"];

                }


                return aux;
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

        public Paciente BuscarDNI(int dni)
        {
            Paciente aux = new Paciente();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select IDPaciente, P.Nombre, Apellido, cast(DNI as int) as DNI, FechaNacimiento, Sexo, Email, O.Nombre as 'Obra Social' from Pacientes as P inner join ObrasSociales as O on O.IDObraSocial = P.IDObraSocial where DNI = @DNI");
                datos.setParametros("@DNI", dni);
                datos.read();

                while (datos.Reader.Read())
                {
                    aux.Id = (int)datos.Reader["IDPaciente"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = (int)datos.Reader["DNI"];
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    //aux.ObraSocial = (string)datos.Reader["Obra Social"];

                }


                return aux;
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

        public void Eliminar(int ID)
        {
            AccesoDB db = new AccesoDB();
            db.Open();
            try
            {
                db.setParametros("@IDPaciente", ID);

                db.setQuery("delete from Turnos where IDPaciente = @IDPaciente");
                db.rerun();

                db.setQuery("delete from Pacientes where IDPaciente = @IDPaciente");
                db.rerun();

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