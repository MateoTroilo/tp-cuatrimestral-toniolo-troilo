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
            int ID;

            //Datos Personales
            try
            {
                
                db.setQuery("insert into Medicos(Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Sexo, @Email, @HorarioInicio, @HorarioFin)");
                db.setParametros("@Nombre", medico.Nombre);
                db.setParametros("@Apellido", medico.Apellido);
                db.setParametros("@DNI", medico.DNI);
                db.setParametros("@FechaNacimiento", medico.FechaNacimiento);
                db.setParametros("@Sexo", medico.Sexo);
                db.setParametros("@Email", medico.Email);
                db.setParametros("@HorarioInicio", medico.Horario.Inicio);
                db.setParametros("@HorarioFin", medico.Horario.Fin);

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
            db2.Open();
            db2.setParametros("@IDMedico", ID);
            try
            {
                for (int i = 0; i < medico.Especialidades.Count; i++)
                {
                    db2.setQuery("insert into Especialidades_x_Medico(IDMedico, IDEspecialidad) values (@IDMedico, @IDEspecialidad" + i+ ")");
                    db2.setParametros(("@IDEspecialidad" + i), medico.Especialidades[i].ID);
                    db2.rerun();
                    
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally 
            { 
                db2.closeConnection(); 
            }

            ////////Guardar Dias
            AccesoDB db3 = new AccesoDB();
            db3.Open();
            db3.setParametros("@IDMedico", ID);
            try
            {
                for (int i = 0; i < medico.Horario.Dias.Count; i++)
                {
                    db3.setQuery("insert into Dias_x_Medico(IDDia, IDMedico) values(@IDDia" + i + ", @IDMedico)");
                    db3.setParametros(("@IDDia" + i), ((int)medico.Horario.Dias[i] + 1).ToString());
                    db3.rerun();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            { 
                db3.closeConnection(); 
            }
        }

        public void Modificar(Medico medico)
        {
            AccesoDB db = new AccesoDB();
            int ID = medico.Id;

            //Datos Personales
            try
            {

                db.setQuery("update Medicos set Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, FechaNacimiento = @FechaNacimiento, Email = @Email, Sexo = @Sexo,HorarioInicio = @HorarioInicio, HorarioFin = @HorarioFin where IDMedico = @ID");
                db.setParametros("@ID", medico.Id);
                db.setParametros("@Nombre", medico.Nombre);
                db.setParametros("@Apellido", medico.Apellido);
                db.setParametros("@DNI", medico.DNI);
                db.setParametros("@FechaNacimiento", medico.FechaNacimiento);
                db.setParametros("@Sexo", medico.Sexo);
                db.setParametros("@Email", medico.Email);
                db.setParametros("@HorarioInicio", medico.Horario.Inicio);
                db.setParametros("@HorarioFin", medico.Horario.Fin);

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

            ////////Guardar Especialidades
            AccesoDB db2 = new AccesoDB();
            db2.Open();
            db2.setParametros("@IDMedico", ID);
            try
            {
                db2.setQuery("delete from Especialidades_x_Medico where IDMedico = @IDMedico");
                db2.rerun();

                for (int i = 0; i < medico.Especialidades.Count; i++)
                {
                    db2.setQuery("insert into Especialidades_x_Medico(IDMedico, IDEspecialidad) values (@IDMedico, @IDEspecialidad" + i + ")");
                    db2.setParametros(("@IDEspecialidad" + i), medico.Especialidades[i].ID);
                    db2.rerun();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                db2.closeConnection();
            }

            ////////Guardar Dias
            AccesoDB db3 = new AccesoDB();
            db3.Open();
            db3.setParametros("@IDMedico", ID);
            try
            {
                db3.setQuery("delete from Dias_x_Medico where IDMedico = @IDMedico");
                db3.rerun();

                for (int i = 0; i < medico.Horario.Dias.Count; i++)
                {
                    db3.setQuery("insert into Dias_x_Medico(IDDia, IDMedico) values(@IDDia" + i + ", @IDMedico)");
                    db3.setParametros(("@IDDia" + i), ((int)medico.Horario.Dias[i] + 1).ToString());
                    db3.rerun();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db3.closeConnection();
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
                    aux.DNI = Int32.Parse((string)datos.Reader["DNI"]);
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Horario.Inicio = (int)datos.Reader["HorarioInicio"];
                    aux.Horario.Fin = (int)datos.Reader["HorarioFin"];

                    ////////////////////////////<<<<<<<<<<<<<<<<<<
                    //AccesoDB data = new AccesoDB();

                    //data.setQuery("select Nombre from Dias_x_Medico as DxM inner join Dias as D on D.IDDia = DxM.IDDia where IDMedico = @ID");
                    //data.setParametros("@ID", aux.Id);

                    //while (data.Reader.Read())
                    //{
                    //    aux.Horario.Dias.Add((Dias)data.Reader["Nombre"]);
                    //}

                    //data.closeConnection();
                    /////////////////////////////<<<<<<<<<<<<<<<<<
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

        public List<Medico> ListarXEspecialidad(int id)
        {
            List<Medico> lista = new List<Medico>();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("Select M.* from Especialidades_x_Medico E Inner Join Medicos M on M.IDMedico = E.IDMedico Inner Join Especialidades Es on Es.IDEspecialidad = E.IDEspecialidad Where Es.IDEspecialidad = @ID");
                datos.setParametros("@ID", id);
                datos.read();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Reader["IDMedico"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = int.Parse(datos.Reader["DNI"].ToString());
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Horario = new Horario();
                    aux.Horario.Inicio = (int)datos.Reader["HorarioInicio"];
                    aux.Horario.Fin = (int)datos.Reader["HorarioFin"];

                    AccesoDB data = new AccesoDB();

                    data.setQuery("select Nombre from Dias_x_Medico as DxM inner join Dias as D on D.IDDia = DxM.IDDia where IDMedico = @ID");
                    data.setParametros("@ID", aux.Id);
                    data.read();

                    aux.Horario.Dias = new List<Dias>();
                    while (data.Reader.Read())
                    {
                        aux.Horario.Dias.Add((Dias)Enum.Parse(typeof(Dias), data.Reader["Nombre"].ToString()));
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

        public Medico Buscar(int id)
        {
            AccesoDB datos = new AccesoDB();
            Medico aux = new Medico();
            try
            {
                datos.setQuery("Select M.* from Especialidades_x_Medico E Inner Join Medicos M on M.IDMedico = E.IDMedico Inner Join Especialidades Es on Es.IDEspecialidad = E.IDEspecialidad Where M.IDMedico = @ID");
                datos.setParametros("@ID", id);
                datos.read();

                while (datos.Reader.Read())
                {
                    aux.Id = (int)datos.Reader["IDMedico"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.DNI = int.Parse(datos.Reader["DNI"].ToString());
                    aux.Sexo = (string)datos.Reader["Sexo"];
                    aux.FechaNacimiento = (DateTime)datos.Reader["FechaNacimiento"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Horario = new Horario();
                    aux.Horario.Inicio = (int)datos.Reader["HorarioInicio"];
                    aux.Horario.Fin = (int)datos.Reader["HorarioFin"];

                    AccesoDB data = new AccesoDB();

                    data.setQuery("select Nombre from Dias_x_Medico as DxM inner join Dias as D on D.IDDia = DxM.IDDia where IDMedico = @ID");
                    data.setParametros("@ID", aux.Id);
                    data.read();

                    aux.Horario.Dias = new List<Dias>();
                    while (data.Reader.Read())
                    {
                        aux.Horario.Dias.Add((Dias)Enum.Parse(typeof(Dias), data.Reader["Nombre"].ToString()));
                    }

                    data.closeConnection();

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
                db.setParametros("@IDMedico", ID);

                db.setQuery("delete from Turnos where IDMedico = @IDMedico");
                db.rerun();

                db.setQuery("delete from Dias_x_Medico where IDMedico = @IDMedico");
                db.rerun();

                db.setQuery("delete from Especialidades_x_Medico where IDMedico = @IDMedico");
                db.rerun();

                db.setQuery("delete from Medicos where IDMedico = @IDMedico");
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
