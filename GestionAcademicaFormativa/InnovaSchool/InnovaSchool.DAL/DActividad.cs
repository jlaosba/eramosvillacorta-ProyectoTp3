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
    public class DActividad
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EActividad> ListarActividadesCalendario(EActividad EActividad)
        {
            List<EActividad> retval = new List<EActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarActividadesCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdCalendario", EActividad.IdCalendario));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FecInicio = Convert.ToDateTime(reader["FecInicio"].ToString()),
                            FecTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FecTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdPersona = int.Parse(reader["IdPersona"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public List<EActividad> ConsultarActividadCalendarioFiltro(EActividad EActividad)
        {
            List<EActividad> retval = new List<EActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarActividadCalendarioFiltro", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdCalendario", EActividad.IdCalendario));
                cmd.Parameters.Add(new SqlParameter("@Nombre", EActividad.Nombre));
                cmd.Parameters.Add(new SqlParameter("@FecInicio", EActividad.FecInicio));
                cmd.Parameters.Add(new SqlParameter("@FecTermino", EActividad.FecTermino));
                cmd.Parameters.Add(new SqlParameter("@IdPersona", EActividad.IdPersona));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EActividad
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FecInicio = Convert.ToDateTime(reader["FecInicio"].ToString()),
                            FecTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FecTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdPersona = int.Parse(reader["IdPersona"].ToString()),
                            UsuCreacion = reader["UsuCreacion"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int RegistrarActividad(EActividad EActividad, EUsuario EUsuario)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad",EActividad.IdActividad));
	            cmd.Parameters.Add(new SqlParameter("@IdCalendario",EActividad.IdCalendario));
	            cmd.Parameters.Add(new SqlParameter("@Nombre",EActividad.Nombre));
	            cmd.Parameters.Add(new SqlParameter("@FecInicio",EActividad.FecInicio));
	            cmd.Parameters.Add(new SqlParameter("@FecTermino",EActividad.FecTermino));
	            cmd.Parameters.Add(new SqlParameter("@Descripcion",EActividad.Descripcion));
	            cmd.Parameters.Add(new SqlParameter("@IdPersona",EActividad.IdPersona));
	            cmd.Parameters.Add(new SqlParameter("@UsuCreacion",EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }

        public int RegistrarDetalleActividad(EDetalleActividad EDetalleActividad, EUsuario EUsuario)
        {
            int retval = 0;
            using (SqlCommand cmd = new SqlCommand("SP_RegistrarDetalleActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EDetalleActividad.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@Fecha", EDetalleActividad.Fecha));
                cmd.Parameters.Add(new SqlParameter("@HoraInicial", EDetalleActividad.HoraInicial));
                cmd.Parameters.Add(new SqlParameter("@HoraTermino", EDetalleActividad.HoraTermino));
                if (EDetalleActividad.IdAmbiente != 0)
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", EDetalleActividad.IdAmbiente));
                else
                    cmd.Parameters.Add(new SqlParameter("@IdAmbiente", DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Direccion", EDetalleActividad.Direccion));
                cmd.Parameters.Add(new SqlParameter("@UsuCreacion", EUsuario.Usuario));
                retval = cmd.ExecuteNonQuery();
            }
            return retval;
        }

        public List<EDetalleActividad> ConsultarDetalleActividad(EActividad EActividad)
        {
            List<EDetalleActividad> retval = new List<EDetalleActividad>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarDetalleActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EDetalleActividad EDetalleActividad = new EDetalleActividad
                        {
                            IdDetalleActividad = int.Parse(reader["IdDetalleActividad"].ToString()),
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                            HoraInicial = Convert.ToDateTime(reader["HoraInicial"].ToString()),
                            HoraTermino = Convert.ToDateTime(reader["HoraTermino"].ToString()),
                            Direccion = reader["Direccion"].ToString(),
                            IdAmbiente = reader.IsDBNull(5) ? 0 : int.Parse(reader["IdAmbiente"].ToString())
                        };

                        retval.Add(EDetalleActividad);
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public EActividad ConsultarActividadCalendario(EActividad EActividad)
        {
            EActividad retval = null;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarActividadCalendario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        retval = new EActividad()
                        {
                            IdActividad = int.Parse(reader["IdActividad"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FecInicio = Convert.ToDateTime(reader["FecInicio"].ToString()),
                            FecTermino = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader["FecTermino"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdPersona = int.Parse(reader["IdPersona"].ToString())
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }

        public int EliminarActividad(EActividad EActividad)
        {
            int retval = 0;
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_EliminarActividad", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdActividad", EActividad.IdActividad));
                retval = cmd.ExecuteNonQuery();
            }
            cn.Close();
            return retval;
        }
    }
}
