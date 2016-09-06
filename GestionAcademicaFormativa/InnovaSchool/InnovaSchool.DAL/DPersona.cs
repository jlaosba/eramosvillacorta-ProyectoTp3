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
    public class DPersona
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EPersona> ListarPersona()
        {
            List<EPersona> retval = new List<EPersona>();
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ListarResponsable", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EPersona
                        {
                            IdPersona = int.Parse(reader["IdPersona"].ToString()),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            cn.Close();
            return retval;
        }
    }
}
