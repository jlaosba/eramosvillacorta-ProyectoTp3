using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace InnovaSchools.Controllers
{
    public class GenerarReporteController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Generar Reporte Administrativo
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | J. LAOS</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | J. LAOS</remarks>
        public ActionResult indexAdministrativo()
        {
            GenerarReporteViewModel GenerarReporte = new GenerarReporteViewModel();
            GenerarReporte.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarReporte.Contrato = new Contrato();
            GenerarReporte.Contratos = new List<Contrato>();
            return View(GenerarReporte);
        }

        // <summary>
        // Generar Reporte Docente
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | J. LAOS</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | J. LAOS</remarks>
        public ActionResult indexDocente()
        {
            GenerarReporteViewModel GenerarReporte = new GenerarReporteViewModel();
            GenerarReporte.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarReporte.Contrato = new Contrato();
            GenerarReporte.Contratos = new List<Contrato>();
            return View(GenerarReporte);
        }

        // <summary>
        // Generar Reporte Docente
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | J. LAOS</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | J. LAOS</remarks>
        public ActionResult indexMantenimiento()
        {
            GenerarReporteViewModel GenerarReporte = new GenerarReporteViewModel();
            GenerarReporte.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarReporte.Contrato = new Contrato();
            GenerarReporte.Contratos = new List<Contrato>();
            return View(GenerarReporte);
        }

        // <summary>
        // Generar Reporte Docente
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | J. LAOS</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | J. LAOS</remarks>
        public ActionResult indexApoyo()
        {
            GenerarReporteViewModel GenerarReporte = new GenerarReporteViewModel();
            GenerarReporte.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarReporte.Contrato = new Contrato();
            GenerarReporte.Contratos = new List<Contrato>();
            return View(GenerarReporte);
        }

        // <summary>
        // Listar Empleados
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | J. LAOS</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | J. LAOS</remarks>
        public ActionResult lstEmpleados(string pFechaInicio, string pFechaFin, Int16 pIdPuesto)
        {
            GenerarReporteViewModel GenerarReporteViewModel = new GenerarReporteViewModel() { };
            GenerarReporteViewModel.Contratos = new List<Contrato>();

            var objPersona =
                       from cnt in _db.Contrato
                       join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                       join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                       join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join per in _db.Persona on cnd.idPersona equals per.idPersona
                       join tct in _db.TipoContrato on cnt.idTipoContrato equals tct.idTipoContrato
                       where cnd.idEstadoCandidato == 5
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per };

            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Puesto.idPuesto == pIdPuesto); }

            foreach (var itm in objPersona)
            {
                if (GenerarReporteViewModel.Contratos.Where(w => w.Empleado.idEmpleado == itm.Empleado.idEmpleado).ToList().Count == 0)
                {
                    GenerarReporteViewModel.Contratos.Add(new Contrato
                    {
                        idContrato = itm.Contrato.idContrato,
                        fechaInicioContratoStr = itm.Contrato.fechaInicioContrato.ToShortDateString(),
                        fechaFinContratoStr = itm.Contrato.fechaFinContrato.ToShortDateString(),
                        Empleado = new Empleado
                        {
                            codigoFotocheck = itm.Empleado.codigoFotocheck,
                            Candidato = new Candidato
                            {
                                Persona = new Persona
                                {
                                    idPersona = itm.Persona.idPersona,
                                    nombre = itm.Persona.nombre,
                                    apellidoPaterno = itm.Persona.apellidoPaterno,
                                    apellidoMaterno = itm.Persona.apellidoMaterno,
                                    telefono = itm.Persona.telefono,
                                    direccion = itm.Persona.direccion,
                                    documentoIdentidad = itm.Persona.documentoIdentidad,
                                },
                            }
                        },
                        Convocatoria = new Convocatoria
                        {
                            Puesto = new Puesto
                            {
                                idPuesto = itm.Puesto.idPuesto,
                                descripcionPuesto = itm.Puesto.descripcionPuesto,
                            }
                        },
                        TipoContrato = new TipoContrato
                        {
                            idTipoContrato = itm.Contrato.idTipoContrato,
                            descripcionContrato = itm.Contrato.TipoContrato.descripcionContrato
                        }
                    });
                }
            }
            if (GenerarReporteViewModel.Contratos.Count() == 0)
            {
                GenerarReporteViewModel.resultadoFind = string.Concat("No se encontraron resultado en busqueda");
            }
            else
            {
                GenerarReporteViewModel.resultadoFind = string.Concat("Resultado de busqueda: ");
            }
            return PartialView("_lstGenerarReporte", GenerarReporteViewModel);
        }

        public ActionResult print(string pTipoReporte, Int16 pIdPuesto)
        {
            #region Datos dummy

            //List<Persona> datos = new List<Persona>(){
            //                                new Persona() { nombre = "Sacarias", apellido_materno = "Piedras del Rio"},
            //                                new Persona() { nombre = "Alan", apellido_materno = "Brito" },
            //                                new Persona() { nombre = "Marcos", apellido_materno = "Pinto" }
            //};

            #endregion Datos dummy

            string DirectorioReportesRelativo = "~/Views/GenerarReporte/";
            string urlArchivo = string.Format("{0}.{1}", "informe", "rdlc");

            string FullPathReport = string.Format("{0}{1}",
                                    this.HttpContext.Server.MapPath(DirectorioReportesRelativo),
                                     urlArchivo);

            ReportViewer Reporte = new ReportViewer();

            Reporte.Reset();
            Reporte.LocalReport.ReportPath = FullPathReport;
            ReportParameter[] parametros = new ReportParameter[1];
            parametros[0] = new ReportParameter("tipoReporte", pTipoReporte);
            Reporte.LocalReport.SetParameters(parametros);

            var objPersona =
                       from cnt in _db.Contrato
                       join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                       join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                       join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join per in _db.Persona on cnd.idPersona equals per.idPersona
                       join tct in _db.TipoContrato on cnt.idTipoContrato equals tct.idTipoContrato
                       where cnd.idEstadoCandidato == 5
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per };

            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Puesto.idPuesto == pIdPuesto); }

            List<Reporte> objLstEmpleados = new List<Reporte>();

            foreach (var itm in objPersona)
            {
                if (objLstEmpleados.Where(w => w.idEmpleado == itm.Empleado.idEmpleado).ToList().Count == 0)
                {
                    objLstEmpleados.Add(new Reporte
                    {
                        idEmpleado = itm.Contrato.idContrato,
                        documentoIdentidad = itm.Empleado.Candidato.Persona.documentoIdentidad,
                        nombreCompleto = itm.Contrato.Empleado.Candidato.nombreCompleto,
                        descripcionPuesto = itm.Contrato.Convocatoria.Puesto.descripcionPuesto,
                        fechaIngresoStr = itm.Contrato.fechaInicioContratoStr,
                        descripcionContrato = itm.Contrato.TipoContrato.descripcionContrato
                    });
                }
            }

            ReportDataSource DataSource = new ReportDataSource("dstInforme", objLstEmpleados);
            Reporte.LocalReport.DataSources.Add(DataSource);
            Reporte.LocalReport.Refresh();
            Reporte.ExportContentDisposition = ContentDisposition.AlwaysInline;

            

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] file = Reporte.LocalReport.Render("PDF");
            return File(new MemoryStream(file).ToArray(),
                      System.Net.Mime.MediaTypeNames.Application.Octet,
                /*Esto para forzar la descarga del archivo*/
                      string.Format("{0}{1}", "reporte_empleados.", "PDF"));

        }
    }
}
