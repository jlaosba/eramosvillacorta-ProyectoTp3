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
    public class DParametro
    {
        SqlConnection cn = new SqlConnection(ConexionUtil.Get_Connection());

        public string ConsultarParametro(int IdPadre, int ValNumerico, string ValTextual)
        {
            string retval = null;
            cn.Open();
            if (ValTextual != null)
            {
                using (SqlCommand cmd = new SqlCommand("SP_ConsultarParametroTexto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPadre", IdPadre));
                    cmd.Parameters.Add(new SqlParameter("@ValTextual", ValTextual));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) { retval = reader["Descripcion"].ToString(); }
                    }
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("SP_ConsultarParametroNumerico", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPadre", IdPadre));
                    cmd.Parameters.Add(new SqlParameter("@ValNumerico", ValNumerico));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) { retval = reader["Descripcion"].ToString(); }
                    }
                }
            }
            
            cn.Close();
            return retval;
        }

        public List<EParametro> ConsultarParametrosLista(int IdPadre)
        {
            List<EParametro> retval = new List<EParametro>();         
            cn.Open();
            
            using (SqlCommand cmd = new SqlCommand("SP_ConsultarParametrosLista", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdPadre", IdPadre));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        retval.Add(new EParametro
                        {
                            ValTextual = reader["ValTextual"].ToString(),
                            ValNumerico = int.Parse(reader["ValNumerico"].ToString()),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }            

            cn.Close();
            return retval;
        }
    }
}
