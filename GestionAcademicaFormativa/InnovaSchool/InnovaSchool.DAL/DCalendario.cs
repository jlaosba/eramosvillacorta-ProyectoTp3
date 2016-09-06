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
    public class DCalendario
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<ECalendario> ConsultarCalendariosAgenda(ECalendario ECalendario)
        {
            List<ECalendario> retval = new List<ECalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarCalendariosAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", ECalendario.IdAgenda));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new ECalendario
                        {
                            IdCalendario = int.Parse(reader["IdCalendario"].ToString()),
                            IdAgenda = reader["IdAgenda"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Estado = int.Parse(reader["Estado"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public ECalendario VerificarAperturaCalendario(ECalendario ECalendario)
        {
            ECalendario retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarAperturaCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Tipo", ECalendario.Tipo));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new ECalendario()
                        {
                            IdAgenda = reader["IdCalendario"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<ECalendario> AniosCalendario(ECalendario ECalendario)
        {
            List<ECalendario> retval = new List<ECalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_AniosCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Tipo", ECalendario.Tipo));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new ECalendario
                        {
                            IdAgenda = reader["IdAgenda"].ToString(),
                            IdCalendario = int.Parse(reader["IdCalendario"].ToString())
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<ECalendario> ConsultarCalendario(ECalendario ECalendario)
        {
            List<ECalendario> retval = new List<ECalendario>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdCalendario", ECalendario.IdCalendario));
                cmd.Parameters.Add(new SqlParameter("@Tipo", ECalendario.Tipo));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new ECalendario
                        {
                            IdCalendario = int.Parse(reader["IdCalendario"].ToString()),
                            IdAgenda = reader["IdAgenda"].ToString(),
                            FecCreacion = Convert.ToDateTime(reader["FecCreacion"].ToString()),
                            FecModificacion = Convert.ToDateTime(reader["FecCierre"].ToString()), //FecCierre
                            Estado = int.Parse(reader["Estado"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarAperturaCalendario(EUsuario EUsuario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarAperturaCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }
    }
}
