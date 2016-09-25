using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;
using System.Data.Entity.Validation;

namespace InnovaSchools.Controllers
{
    public class ActualizarFotoCheckController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Mantener actualizada la información de solicitud de emisión de fotocheck
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | B. PARRAGA</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | B. PARRAGA</remarks>
        public ActionResult index()
        {
            ActualizarFotoCheckViewModel ActualizarFotoCheck = new ActualizarFotoCheckViewModel();
            ActualizarFotoCheck.DocumentoIdentidadList = (from entry in _db.DocumentoIdentidad orderby entry.idDocumentoIdentidad ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.Contrato = new Contrato();
            ActualizarFotoCheck.Contratos = new List<Contrato>();
            //ActualizarFotoCheck.Empleado = new Empleado();
            //ActualizarFotoCheck.Empleados = new List<Empleado>();
            //ActualizarFotoCheck.Persona = new Persona();
            //ActualizarFotoCheck.Personas = new List<Persona>();
            return View(ActualizarFotoCheck);
        }

        // <summary>
        // Listar Empleados
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | B. PARRAGA</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | B. PARRAGA</remarks>
        public ActionResult lstEmpleados(string pFechaInicio, string pFechaFin, string pNroContrato, Int16 pIdTipoDocumento, string pDocumentoIdentidad,
                                         string pNombre, string pApePaterno, string pApeMaterno, Int16 pIdPuesto)
        {
            ActualizarFotoCheckViewModel ActualizarFotoCheckViewModel = new ActualizarFotoCheckViewModel() { };
            ActualizarFotoCheckViewModel.Contratos = new List<Contrato>();

            var objPersona =
                       from cnt in _db.Contrato
                       join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                       join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                       join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join per in _db.Persona on cnd.idPersona equals per.idPersona
                       join tct in _db.TipoContrato on cnt.idTipoContrato equals tct.idTipoContrato
                       where cnd.idEstadoCandidato == 5 //&& emp.codigoFotocheck.ToString().Trim() == ""
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per };

            //if (pNroContrato.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Contrato.idContrato == Convert.ToInt16(pNroContrato)); }
            if (pNroContrato.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Contrato.nroContrato == pNroContrato); }
            if (pIdTipoDocumento > 0) { objPersona = objPersona.Where(x => x.Persona.DocumentoIdentidad.idDocumentoIdentidad == pIdTipoDocumento); }
            if (pDocumentoIdentidad.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.documentoIdentidad.Contains(pNroContrato)); }
            if (pNombre.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.nombre.Contains(pNroContrato)); }
            if (pApePaterno.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoPaterno.Contains(pNroContrato)); }
            if (pApeMaterno.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoMaterno.Contains(pNroContrato)); }
            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Puesto.idPuesto == pIdPuesto); }

            foreach (var itm in objPersona)
            {
                if (ActualizarFotoCheckViewModel.Contratos.Where(w => w.Empleado.idEmpleado == itm.Empleado.idEmpleado).ToList().Count == 0)
                {
                    ActualizarFotoCheckViewModel.Contratos.Add(new Contrato
                    {
                        idContrato = itm.Contrato.idContrato,
                        nroContrato = itm.Contrato.nroContrato,
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
            if (ActualizarFotoCheckViewModel.Contratos.Count() == 0)
            {
                ActualizarFotoCheckViewModel.resultadoFind = string.Concat("No se encontraron resultado en busqueda");
            }
            else
            {
                ActualizarFotoCheckViewModel.resultadoFind = string.Concat("Resultado de busqueda: ");
            }
            return PartialView("_lstActualizarFotoCheck", ActualizarFotoCheckViewModel);
        }

        // <summary>
        // Obtener Contrato
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | B. PARRAGA</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | B. PARRAGA</remarks>
        public ActionResult getEmpleado(int pIdPersona)
        {

            var objPersona =
                      from cnt in _db.Contrato
                      join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                      join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                      join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                      join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                      join tpt in _db.TipoPuesto on cvt.idTipoPuesto equals tpt.idTipoPuesto
                      join are in _db.Area on cvt.idArea equals are.idArea
                      join dsr in _db.Desarrollo on cvt.idDesarrollo equals dsr.idDesarrollo
                      join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona
                      join nac in _db.Nacionalidad on per.idNacionalidad equals nac.idNacionalidad
                      join dni in _db.DocumentoIdentidad on per.idDocumentoIdentidad equals dni.idDocumentoIdentidad
                      //where cnd.idEstadoCandidato == 5
                      where per.idPersona == pIdPersona
                      select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per,
                                        Nacionalidad = nac,
                                        TipoPuesto = tpt,
                                        Area = are,
                                        Desarrollo = dsr,
                                        DocumentoIdentidad = dni
                      };

            ActualizarFotoCheckViewModel ActualizarFotoCheck = new ActualizarFotoCheckViewModel();
            ActualizarFotoCheck.Contratos = new List<Contrato>();

            foreach (var itm in objPersona)
            {               
                    ActualizarFotoCheck.Contrato = new Contrato
                    {
                        idContrato = itm.Contrato.idContrato,
                        nroContrato = itm.Contrato.nroContrato,
                        fechaInicioContratoStr = itm.Contrato.fechaInicioContrato.ToShortDateString(),
                        fechaFinContratoStr = itm.Contrato.fechaFinContrato.ToShortDateString(),
                        Empleado = new Empleado
                        {
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
                                    Nacionalidad = new Nacionalidad { idNacionalidad = itm.Nacionalidad.idNacionalidad, nacionalidad = itm.Nacionalidad.nacionalidad },
                                    DocumentoIdentidad = new DocumentoIdentidad { idDocumentoIdentidad = itm.DocumentoIdentidad.idDocumentoIdentidad},
                                },
                            }
                        },
                        Convocatoria = new Convocatoria
                        {                            
                            TipoPuesto = new TipoPuesto { idTipoPuesto = itm.TipoPuesto.idTipoPuesto, descripcionPuesto = itm.TipoPuesto.descripcionPuesto },
                            Puesto = new Puesto { idPuesto = itm.Puesto.idPuesto, descripcionPuesto = itm.Puesto.descripcionPuesto },
                            Area = new Area { idArea = itm.Area.idArea, descripcionArea = itm.Area.descripcionArea },
                            Desarrollo = new Desarrollo { idDesarrollo = itm.Desarrollo.idDesarrollo, descripcionDesarrollo = itm.Desarrollo.descripcionDesarrollo }
                        },
                        TipoContrato = new TipoContrato
                        {
                            idTipoContrato = itm.Contrato.idTipoContrato,
                            descripcionContrato = itm.Contrato.TipoContrato.descripcionContrato
                        },
                        idTipoContratoTiempo = itm.Contrato.idTipoContratoTiempo
                    };
                //}
                ActualizarFotoCheck.fechaInicioPublicacionStr= itm.Contrato.fechaInicioContrato.ToShortDateString();
                ActualizarFotoCheck.fechaFinPublicacionStr = itm.Contrato.fechaFinContrato.ToShortDateString();
            }


            ActualizarFotoCheck.DocumentoIdentidadList = (from entry in _db.DocumentoIdentidad orderby entry.idDocumentoIdentidad ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedDocumentoIdentidadId = ActualizarFotoCheck.Contrato.Empleado.Candidato.Persona.DocumentoIdentidad.idDocumentoIdentidad;

            ActualizarFotoCheck.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedPuestoId = ActualizarFotoCheck.Contrato.Convocatoria.Puesto.idPuesto;

            ActualizarFotoCheck.TipoPuestoList = (from entry in _db.TipoPuesto orderby entry.idTipoPuesto ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedTipoPuestoId = ActualizarFotoCheck.Contrato.Convocatoria.TipoPuesto.idTipoPuesto;

            ActualizarFotoCheck.AreaList = (from entry in _db.Area orderby entry.idArea ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedAreaId = Convert.ToInt16(ActualizarFotoCheck.Contrato.Convocatoria.Area.idArea);

            ActualizarFotoCheck.DesarrolloList = (from entry in _db.Desarrollo orderby entry.idDesarrollo ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedDesarrolloId = Convert.ToInt16(ActualizarFotoCheck.Contrato.Convocatoria.Desarrollo.idDesarrollo);

            ActualizarFotoCheck.TipoContratoList = (from entry in _db.TipoContrato orderby entry.idTipoContrato ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedTipoContratoId = Convert.ToInt16(ActualizarFotoCheck.Contrato.TipoContrato.idTipoContrato);

            ActualizarFotoCheck.TipoContratoTiempoList = (from entry in _db.TipoContratoTiempo orderby entry.idTipoContratoTiempo ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.SelectedTipoContratoTiempoId = Convert.ToInt16(ActualizarFotoCheck.Contrato.idTipoContratoTiempo);

            return View(ActualizarFotoCheck);
        }

        // <summary>
        // Actualizar datos del empleado y su contrato
        // </summary>
        // <returns>Fecha Creacion      : 06/09/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 06/09/0216 | M. MAURICIO</remarks>
        public JsonResult setEmpleado(string pDni)
        {
            var objPersona = (from cvt in _db.Contrato
                              join emp in _db.Empleado on cvt.idEmpleado equals emp.idEmpleado
                              where cvt.nroContrato == pDni
                              select new { Empleado = emp, Contrato = cvt}).First(); ;

            string vIdContrato;
            try
            {
                var objCandidato = _db.Empleado.First(x => x.idEmpleado == objPersona.Empleado.idEmpleado);
                //objCandidato.codigoFotocheck = string.Concat(DateTime.Now.Year.ToString(),
                //                                             objPersona.Contrato.idTipoContrato.ToString(),
                //                                             objPersona.Contrato.idConvocatoria.ToString(),
                //                                             objPersona.Contrato.idEmpleado.ToString().PadLeft(7, '0'));

                objCandidato.codigoFotocheck = string.Concat(DateTime.Now.Year.ToString(),
                                                             objPersona.Contrato.TipoContrato.descripcionContrato.Substring(0,3).ToString().ToUpper(),
                                                             objPersona.Contrato.Convocatoria.TipoPuesto.descripcionPuesto.Substring(0, 3).ToString().ToUpper(),
                                                             objPersona.Contrato.Convocatoria.Puesto.descripcionPuesto.Substring(0, 3).ToString().ToUpper(),
                                                             objPersona.Contrato.idEmpleado.ToString().PadLeft(7, '0'));
                _db.SaveChanges();

                vIdContrato = Convert.ToString(objCandidato.codigoFotocheck);
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (InvalidCastException e)
            {
                throw;
            }

            return Json(vIdContrato, JsonRequestBehavior.AllowGet);
        }
    }
}
