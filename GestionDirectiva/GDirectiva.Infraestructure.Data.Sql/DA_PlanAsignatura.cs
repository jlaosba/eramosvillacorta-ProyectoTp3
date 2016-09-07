using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDirectiva.Core.Entities;

namespace GDirectiva.Infraestructure.Data.Sql
{
    public class DA_PlanAsignatura
    {
        public List<PA_ASIGNATURA_PLANAREA_LISTA_Result> ListarAsignaturaPlanArea(int planAreaId)
        {
            using (DB_INNOVASCHOOLSEntities contexto = new DB_INNOVASCHOOLSEntities())
            {
                List<PA_ASIGNATURA_PLANAREA_LISTA_Result> objeto = new List<PA_ASIGNATURA_PLANAREA_LISTA_Result>();
                objeto = contexto.PA_ASIGNATURA_PLANAREA_LISTA(planAreaId).ToList();
                return objeto;
            }
        }
    }
}
