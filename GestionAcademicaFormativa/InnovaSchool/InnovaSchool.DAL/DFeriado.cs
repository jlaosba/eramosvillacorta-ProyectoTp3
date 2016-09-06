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
                            Fecha = Convert.ToDateTime(reader["Fecha"].ToString()),
                            Motivo = reader["Motivo"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            return retval;
        }
        
    }
}
