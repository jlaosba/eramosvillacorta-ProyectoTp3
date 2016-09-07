using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDirectiva.Core.Entities;
using GDirectiva.Infraestructure.Data.Sql;
using GDirectiva.Cross.Core.Exception;
using GDirectiva.Core.Entities.Adapter;
using GDirectiva.Core.Entities.General;

namespace GDirectiva.Domain.Main
{
    public class BL_PlanAsignatura
    {
        public ProcessResult<List<PA_PLAN_ASIGNATURA_LISTA_Result>> ListarPlanAsignatura(int periodoacademicoId, int planAreaId, int asignaturaId, int pAGINA_INICIO, int tAMANIO_PAGINA)
        {
            ProcessResult<List<PA_PLAN_ASIGNATURA_LISTA_Result>> resultado = new ProcessResult<List<PA_PLAN_ASIGNATURA_LISTA_Result>>();
            try
            {
                DA_PlanAsignatura objeto = new DA_PlanAsignatura();
                resultado.Result = objeto.ListarPlanAsignatura(periodoacademicoId, planAreaId, asignaturaId, pAGINA_INICIO, tAMANIO_PAGINA);
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<BL_PlanAsignatura>(e);
            }
            return resultado;
        }
    }
}
