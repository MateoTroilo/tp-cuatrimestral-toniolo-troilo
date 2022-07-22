using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class TurnosNegocio
    {
        public void agregar(Turno nuevo)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setQuery("Insert into TURNOS(Fecha, IDEstado, IDPaciente, IDMedico, Observaciones, IDEspecialidad)values( @Fecha, @Estado, @Paciente, @Medico, @Observaciones, @Especialidad)");
                datos.setParametros("@Fecha", nuevo.Fecha);
                datos.setParametros("@Estado", nuevo.Estado);
                datos.setParametros("@Paciente", nuevo.Paciente);
                datos.setParametros("@Medico", nuevo.Medico);
                datos.setParametros("@Observaciones", nuevo.Observacion);
                datos.setParametros("@Especialidad", nuevo.Especialidad);
                datos.run();
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

        public void modificar(Turno turno, int id)
        {
            AccesoDB datos = new AccesoDB();
            
            try
            {
                datos.setQuery("update TURNOS set Fecha = @Fecha, IDEstado = @Estado, IDPaciente = @Paciente, IDMedico = @Medico, IDEspecialidad = @Especialidad, Observaciones = @Observacion where IDTurno = @Id");
                datos.setParametros("@Fecha", turno.Fecha);
                datos.setParametros("@Estado", (int)turno.Estado);
                datos.setParametros("@Paciente", turno.Paciente);
                datos.setParametros("@Medico", turno.Medico);
                datos.setParametros("@Especialidad", turno.Especialidad);
                datos.setParametros("@Observacion", turno.Observacion);
                datos.setParametros("@Id", id);
                datos.run();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Turno> listar(int idMedico)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select cast(T.IDTurno as int) as IDTurno, T.Fecha, T.IDEstado, cast(concat(P.Nombre, ' ', P.Apellido,'(', P.IDPaciente, ')' ) as varchar) as Paciente, cast(concat(M.Nombre, ' ', M.Apellido,'(', M.IDMedico, ')' ) as varchar) as Medico, T.IDEspecialidad, T.Observaciones as Observaciones from Turnos as T  inner join Pacientes as P on P.IDPaciente = T.IDPaciente  inner join Medicos as M on M.IDMedico = T.IDMedico inner join Especialidades as E on E.IDEspecialidad = T.IDEspecialidad where M.IDMedico = @IDMEDICO and T.Fecha > GETDATE() order by T.Fecha asc");
                datos.setParametros("@IDMEDICO", idMedico);
                datos.read();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Reader["IDTurno"];
                    aux.Fecha = (DateTime)datos.Reader["Fecha"];
                    aux.Estado = (Estados)Enum.Parse(typeof(Estados), datos.Reader["IDEstado"].ToString());
                    aux.Paciente = (string)datos.Reader["Paciente"];
                    aux.Medico = (string)datos.Reader["Medico"];
                    aux.Observacion = (string)datos.Reader["Observaciones"];

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

        public Turno Buscar(int idMedico, int idPaciente, DateTime fecha)
        {
            AccesoDB datos = new AccesoDB();
            Turno aux = new Turno();
            Estados cancelado = Estados.Cancelado;
            try
            {
                datos.setQuery("select IDEstado, cast(IDPaciente as varchar) as  IDPaciente,cast(IDMedico as varchar) as IDMedico from Turnos where (IDPaciente = @IDPACIENTE OR IDMedico = @IDMEDICO) and Fecha = @FECHA and not IDEstado = @ESTADO");
                datos.setParametros("@IDMEDICO", idMedico);
                datos.setParametros("@IDPACIENTE", idPaciente);
                datos.setParametros("@FECHA", fecha);
                datos.setParametros("@ESTADO", cancelado);
                datos.read();

                while (datos.Reader.Read())
                {
                    aux.Estado = (Estados)Enum.Parse(typeof(Estados), datos.Reader["IDEstado"].ToString());
                    aux.Paciente = (string)datos.Reader["IDPaciente"];
                    aux.Medico = (string)datos.Reader["IDMedico"];

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

        public Turno Buscar(int idTurno)
        {
            AccesoDB datos = new AccesoDB();
            Turno aux = new Turno();
            try
            {
                datos.setQuery("select * from Turnos where IDTurno = @IDTURNO");
                datos.setParametros("@IDTURNO", idTurno);
                datos.read();

                while (datos.Reader.Read())
                {
                    aux.Id = (int)datos.Reader["IDTurno"];
                    aux.Estado = (Estados)Enum.Parse(typeof(Estados), datos.Reader["IDEstado"].ToString());
                    aux.Paciente = (string)datos.Reader["IDPaciente"].ToString();
                    aux.Medico = (string)datos.Reader["IDMedico"].ToString();
                    aux.Fecha = (DateTime)datos.Reader["Fecha"];
                    aux.Especialidad = (string)datos.Reader["IDEspecialidad"].ToString();
                    aux.Observacion = (string)datos.Reader["Observaciones"];
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

        public List<Turno> listarPlanilla()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setQuery("select cast(T.IDTurno as int) as IDTurno, T.Fecha, T.IDEstado, cast(concat(P.Nombre, ' ', P.Apellido,'(', P.IDPaciente, ')' ) as varchar) as Paciente, cast(concat(M.Nombre, ' ', M.Apellido,'(', M.IDMedico, ')' ) as varchar) as Medico, E.Nombre as Especialidad, T.Observaciones as Observaciones from Turnos as T  inner join Pacientes as P on P.IDPaciente = T.IDPaciente  inner join Medicos as M on M.IDMedico = T.IDMedico inner join Especialidades as E on E.IDEspecialidad = T.IDEspecialidad where T.Fecha > GETDATE() order by T.Fecha asc");
                datos.read();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Reader["IDTurno"];
                    aux.Fecha = (DateTime)datos.Reader["Fecha"];
                    aux.Estado = (Estados)Enum.Parse(typeof(Estados), datos.Reader["IDEstado"].ToString());
                    aux.Paciente = (string)datos.Reader["Paciente"];
                    aux.Medico = (string)datos.Reader["Medico"];
                    aux.Especialidad = (string)datos.Reader["Especialidad"];
                    aux.Observacion = (string)datos.Reader["Observaciones"];

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

        public void Eliminar(int id)
        {
            AccesoDB datos = new AccesoDB();
            int cancelado = (int)Estados.Cancelado;
            try
            {
                datos.setQuery("update TURNOS set IDEstado = @Estado where IDTurno = @Id");
                datos.setParametros("@Id", id);
                datos.setParametros("@Estado", cancelado);
                datos.run();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}