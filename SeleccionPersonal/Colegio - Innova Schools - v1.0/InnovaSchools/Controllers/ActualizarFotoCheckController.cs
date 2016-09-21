using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;

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
            ActualizarFotoCheck.TipoDocumentoList = (from entry in _db.TipoDocumento orderby entry.idTipoDocumento ascending select entry).Take(20).ToList();
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
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
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
                       where cnd.idEstadoCandidato == 5
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per };

            if (pNroContrato.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Contrato.idContrato == Convert.ToInt16(pNroContrato)); }
            if (pIdTipoDocumento > 0) { objPersona = objPersona.Where(x => x.Persona.TipoDocumento.idTipoDocumento == pIdTipoDocumento); }
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

    }
}
