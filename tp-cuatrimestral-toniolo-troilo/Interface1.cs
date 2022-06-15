using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class TurnosNegocio
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDB datos = new AccesoDB();


            try
            {
                datos.setQuery("select cast(T.IDTurno as int) as IDTurno, T.Fecha, T.Estado, cast(concat(P.Nombre, ' ', P.Apellido,'(', P.IDPaciente, ')' ) as varchar) as Paciente, cast(concat(M.Nombre, ' ', M.Apellido,'(', M.IDMedico, ')' ) as varchar) as Medico, E.Nombre as Especialidad from Turnos as T inner join Pacientes as P on P.IDPaciente = T.IDPaciente inner join Medicos as M on M.IDMedico = T.IDMedico inner join Especialidades as E on E.IDEspecialidad = M.IDEspecialidad");
                datos.read();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)datos.Reader["IDTurno"];
                    aux.Fecha = (DateTime)datos.Reader["Fecha"];
                    aux.Estado = (string)datos.Reader["Estado"];
                    aux.Paciente = (string)datos.Reader["Paciente"];
                    aux.Medico = (string)datos.Reader["Medico"];
                    aux.Especialidad = (string)datos.Reader["Especialidad"];
                    //aux.Observacion = (string)datos.Reader["Observaciones"];

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