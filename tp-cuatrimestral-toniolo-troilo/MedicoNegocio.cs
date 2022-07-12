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
            //AccesoDB db = new AccesoDB();


            int ID;
            //try
            //{
            //    //Datos Personales
            //    db.setQuery("insert into Medicos(Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Sexo, @Email, @HorarioInicio, @HorarioFin)");
            //    db.setParametros("@Nombre", medico.Nombre);
            //    db.setParametros("@Apellido", medico.Apellido);
            //    db.setParametros("@DNI", medico.DNI);
            //    db.setParametros("@FechaNacimiento", medico.FechaNacimiento);
            //    db.setParametros("@Sexo", medico.Sexo);
            //    db.setParametros("@Email", medico.Email);
            //    db.setParametros("@HorarioInicio", medico.Horario.Inicio);
            //    db.setParametros("@HorarioFin", medico.Horario.Fin);

            //    db.run();

            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //finally
            //{
            //    db.closeConnection();
            //}

            ///////Get ID del medico

            AccesoDB db1 = new AccesoDB();

            try
            {

                db1.setQuery("SELECT cast(IDENT_CURRENT('Medicos') as int) as ID");
                db1.read();
                if (db1.Reader.Read())
                {
                    ID = (int)db1.Reader["ID"];
                }
                else { ID = 0 ; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db1.closeConnection();
            }

            ////////Guardar Especialidades
            AccesoDB db2 = new AccesoDB();

            try
            {
                for (int i = 0; i < medico.Especialidades.Count; i++)
                {
                    db2.setQuery("insert into Especialidades_x_Medico(IDMedico, IDEspecialidad) values (@IDMedico, @IDEspecialidad)");
                    db2.setParametros("@IDMedico", ID);
                    db2.setParametros("@IDEspecialidad", medico.Especialidades[i].ID);
                    db2.run();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { db2.closeConnection(); }

            ////////Guardar Dias
            AccesoDB db3 = new AccesoDB();

            try
            {
                for (int i = 0; i < medico.Horario.Dias.Count; i++)
                {
                    db3.setQuery("insert into Dias_x_Medico(IDDia, IDMedico) values(@IDDia, @IDMedico)");
                    db3.setParametros("@IDDia", medico.Especialidades[i].ID);
                    db3.setParametros("@IDMedico", ID);
                    db3.run();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { db3.closeConnection(); }
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
                db.setParametros("@Sexo", medico.Sexo);
                db.setParametros("@Email", medico.Email);
                db.setParametros("@IDEspecialidad", medico.Especialidades);

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

        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select IDMedico, Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin from Medicos");
                datos.read();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Reader["IDMedico"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = (int)datos.Reader["DNI"];
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Horario.Inicio = Int32.Parse(datos.Reader["Horario Inicio"].ToString().Substring(0, datos.Reader["Horario Inicio"].ToString().IndexOf(":") + 1));
                    aux.Horario.Fin = Int32.Parse(datos.Reader["Horario Fin"].ToString().Substring(0, datos.Reader["Horario Fin"].ToString().IndexOf(":") + 1));

                    AccesoDB data = new AccesoDB();

                    data.setQuery("select Nombre from Dias_x_Medico as DxM inner join Dias as D on D.IDDia = DxM.IDDia where IDMedico = @ID");
                    data.setParametros("@ID", aux.Id);

                    while (datos.Reader.Read())
                    {
                        aux.Horario.Dias.Add((Dias)data.Reader["Nombre"]);
                    }

                    data.closeConnection();

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
