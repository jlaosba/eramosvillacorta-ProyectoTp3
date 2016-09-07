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
    public class DAgenda
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public int RegistrarAperturaAgenda(EAgenda EAgenda, EUsuario EUsuario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarAperturaAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FecApertura", EAgenda.fechaApertura));
                cmd.Parameters.Add(new SqlParameter("@FecCierre", EAgenda.fechaCierre ));
                cmd.Parameters.Add(new SqlParameter("@FecIniEscolar", EAgenda.fechaInicioEscolar));
                cmd.Parameters.Add(new SqlParameter("@FecFinEscolar", EAgenda.FechaTerminoEscolar));
	            cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public EAgenda VerificarAperturaAgenda()
        {
            EAgenda retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_VerificarAperturaAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EAgenda()
                        {
                            IdAgenda = reader["IdAgenda"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EAgenda> AniosAgenda()
        {
            List<EAgenda> retval = new List<EAgenda>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_AniosAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAgenda
                        {
                            IdAgenda = reader["IdAgenda"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public EAgenda ConsultarAgenda(EAgenda EAgenda)
        {
            EAgenda retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EAgenda.IdAgenda));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EAgenda()
                        {
                            IdAgenda = reader["IdAgenda"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            fechaApertura = Convert.ToDateTime(reader["fechaApertura"].ToString()),
                            fechaCierre = Convert.ToDateTime(reader["fechaCierre"].ToString()),
                            fechaInicioEscolar = Convert.ToDateTime(reader["fechaInicioEscolar"].ToString()),
                            FechaTerminoEscolar = Convert.ToDateTime(reader["FechaTerminoEscolar"].ToString()),
                            Estado = int.Parse(reader["Estado"].ToString()),
                            UsuModificación = reader["UsuModificacion"].ToString(),
                            FecModificacion = reader.IsDBNull(8) ? (DateTime?)null : Convert.ToDateTime(reader["FecModificacion"].ToString())
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int GenerarAgenda(EAgenda EAgenda)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_GenerarAgenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdAgenda", EAgenda.IdAgenda));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", EAgenda.Descripcion));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }
            

    }
}
