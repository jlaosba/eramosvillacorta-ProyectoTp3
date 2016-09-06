using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaSchool.Entity;
using System.Data.SqlClient;
using System.Data;

namespace InnovaSchool.DAL
{
    public class DAmbiente
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public List<EAmbiente> ListarAmbientes()
        {
            List<EAmbiente> retval = new List<EAmbiente>();
            cn.Open();

            using (SqlCommand cmd = new SqlCommand("SP_ListarAmbientes", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retval.Add(new EAmbiente
                        {
                            IdAmbiente = int.Parse(reader["IDAmbiente"].ToString()),
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
