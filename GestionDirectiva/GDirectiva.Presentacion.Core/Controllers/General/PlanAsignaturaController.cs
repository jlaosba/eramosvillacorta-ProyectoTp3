﻿using GDirectiva.Core.Entities;
using GDirectiva.Core.Entities.Adapter;
using GDirectiva.Cross.Core.Exception;
using GDirectiva.Domain.Main;
using GDirectiva.Presentacion.Core.Controllers.Base;
using GDirectiva.Presentacion.Core.ViewModel.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GDirectiva.Presentacion.Core.Controllers.General
{
    public class PlanAsignaturaController : GenericController
    {

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var model = new PlanAsignaturaBusquedaModel();
            var bl_PeriodoAcademico = new BL_PeriodoAcademico();

            model.ListaPeriodoAcademico = bl_PeriodoAcademico.ListarPeriodosAcademicos();

            return View(model);
        }
        #endregion

        #region Vistas parciales
        public ActionResult FormularioRegistro(int pId_Plan_Asignatura)
        {
            var model = new PlanAsignaturaRegistroModel();

            var bl_PeriodoAcademico = new BL_PeriodoAcademico();
            var bl_PlanAsignatura = new BL_PlanAsignatura();

            if (pId_Plan_Asignatura > 0)
            {
                model.planAsignatura = bl_PlanAsignatura.ObtenerPlanAsignatura(pId_Plan_Asignatura).Result;
            }
            model.ListaPeriodoAcademico = bl_PeriodoAcademico.ListarPeriodosAcademicosVigentes();

            return PartialView(model);
        }
        #endregion

        #region JsonResult

        public JsonResult Buscar(int pId_Periodo, int pGD_Plan_Area_Id_Plan_Area, int pGD_Asignatura_Id_Asignatura)
        {
            var bl_PlanAsignatura = new BL_PlanAsignatura();
            var proceso = bl_PlanAsignatura.ListarPlanAsignatura(pId_Periodo, pGD_Plan_Area_Id_Plan_Area, pGD_Asignatura_Id_Asignatura, 0, 100);
            return Json(proceso);
        }

        public JsonResult BuscarPlanArea(int pId_Periodo)
        {
            ProcessResult<List<SelectListItem>> resultado = new ProcessResult<List<SelectListItem>>();
            resultado.Result = new List<SelectListItem>();
            var bl_PlanArea = new BL_PlanArea();
            var proceso = bl_PlanArea.ListarPlanAreaVigente(pId_Periodo);
            if (proceso != null)
            {
                proceso.Result.ForEach(delegate(PA_PLAN_AREA_LISTA_VIGENTE_Result plan)
                {
                    resultado.Result.Add(new SelectListItem() { Value = plan.ID_PLANAREA.ToString(), Text = plan.NOMBRE });
                });
            }
            else
            {
                resultado.Result = null;
            }
            return Json(resultado);
        }

        public JsonResult BuscarAsignatura(int pId_PlanArea)
        {
            ProcessResult<List<SelectListItem>> resultado = new ProcessResult<List<SelectListItem>>();
            resultado.Result = new List<SelectListItem>();
            var bl_Asignatura = new BL_Asignatura();
            var proceso = bl_Asignatura.ListarAsignaturaPlanArea(pId_PlanArea);
            if (proceso != null)
            {
                proceso.Result.ForEach(delegate(PA_ASIGNATURA_PLANAREA_LISTA_Result asignatura)
                {
                    resultado.Result.Add(new SelectListItem() { Value = asignatura.ID_ASIGNATURA.ToString(), Text = asignatura.NOMBRE_ASIGNATURA });
                });
            }
            else
            {
                resultado.Result = null;
            }
            return Json(resultado);
        }

        public JsonResult Registrar(PlanAsignatura planAsignatura)
        {
            ProcessResult<PlanAsignatura> resultado = new ProcessResult<PlanAsignatura>();
            var bl_PlanAsignatura = new BL_PlanAsignatura();
            if (planAsignatura.Id_PlanAsignatura == 0)
            {
                resultado = bl_PlanAsignatura.InsertarPlanAsignatura(planAsignatura);
            }
            else
            {
                resultado = bl_PlanAsignatura.ActualizarPlanAsignatura(planAsignatura);
            }
            return Json(resultado);
        }

        public JsonResult Eliminar(int pId_PlanAsignatura)
        {
            ProcessResult<PlanAsignatura> resultado = new ProcessResult<PlanAsignatura>();
            var bl_PlanAsignatura = new BL_PlanAsignatura();
            resultado = bl_PlanAsignatura.EliminarPlanAsignatura(pId_PlanAsignatura);
            return Json(resultado);
        }
        #endregion
    }
}
