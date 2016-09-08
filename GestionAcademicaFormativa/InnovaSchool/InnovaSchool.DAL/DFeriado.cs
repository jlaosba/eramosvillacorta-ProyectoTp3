using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using InnovaSchool.Entity;

namespace InnovaSchool.DAL
{
    public class DFeriado
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public EFeriado VerificarFeriado(EActividad EActividad)
        {
            EFeriado retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarFeriado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FecInicio", EActividad.FecInicio));
                cmd.Parameters.Add(new SqlParameter("@FecTermino", EActividad.FecTermino));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EFeriado
                        {
                            FecCreacion = Convert.ToDateTime(reader["Fecha"].ToString()),
                            Motivo = reader["Motivo"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public EFeriado ConsultarFeriado(EFeriado EFeriado)
        {
            EFeriado retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarFeriado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EFeriado.IdAgenda));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EFeriado()
                        {
                            IdAgenda = reader["IdAgenda"].ToString(),
                            Motivo = reader["Motivo"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),
                            FechaTermino = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Repetitivo = int.Parse(reader["Repetitivo"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString(),
                            FecCreacion = Convert.ToDateTime(reader["FecCreacion"].ToString()),
                            UsuModificacion = reader["UsuModificacion"].ToString(),
                            FecModificacion = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["FecModificacion"].ToString())
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }
        public List<EFeriado> ConsultarFeriadoLista(EFeriado EFeriado)
        {
            List<EFeriado> retval = new List<EFeriado>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarFeriado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EFeriado.IdAgenda));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add( new EFeriado
                        {
                            IdAgenda = reader["IdAgenda"].ToString(),
                            Motivo = reader["Motivo"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FechaInicio"].ToString()),                            
                            FechaTermino = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["FechaTermino"].ToString()),
                            Repetitivo = int.Parse(reader["Repetitivo"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString(),
                            FecCreacion = Convert.ToDateTime(reader["FecCreacion"].ToString()),
                            UsuModificacion = reader["UsuModificacion"].ToString(),
                            FecModificacion = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["FecModificacion"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarFeriado(EFeriado EFeriado, EUsuario EUsuario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarFeriado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@motivo", EFeriado.Motivo));
                cmd.Parameters.Add(new SqlParameter("@repetitivo", EFeriado.Repetitivo));
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", EFeriado.FechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaTermino", EFeriado.FechaTermino));
                cmd.Parameters.Add(new SqlParameter("@usuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }
    }
}
