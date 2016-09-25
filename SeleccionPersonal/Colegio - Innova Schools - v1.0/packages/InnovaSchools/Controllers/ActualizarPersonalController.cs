using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;

namespace InnovaSchools.Controllers
{
    public class ActualizarPersonalController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Verificar la documentación del Personal
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
        public ActionResult index()
        {
            ActualizarPersonalViewModel ActualizarPersonal = new ActualizarPersonalViewModel();
            ActualizarPersonal.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarPersonal.Contrato = new Contrato();
            ActualizarPersonal.Contratos = new List<Contrato>();
            return View(ActualizarPersonal);
        }

        // <summary>
        // Listar Empleados
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
        public ActionResult lstContratos(string pNroContrato, string pNombreCompleto, Int16 pIdPuesto)
        {
            ActualizarPersonalViewModel ActualizarPersonalViewModel = new ActualizarPersonalViewModel(){};
            ActualizarPersonalViewModel.Contratos = new List<Contrato>();

            var objPersona =
                       from cnt in _db.Contrato
                       join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                       join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                       join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona                       
                       where cnd.idEstadoCandidato == 5
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per };

            if (pNroContrato.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.nombre.Contains(pNroContrato)); }
            if (pNombreCompleto.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoPaterno.Contains(pNombreCompleto)); }
            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Puesto.idPuesto == pIdPuesto); }

            foreach (var itm in objPersona)
            {
                if (ActualizarPersonalViewModel.Contratos.Where(w => w.Empleado.idEmpleado == itm.Empleado.idEmpleado).ToList().Count == 0)
                {
                    ActualizarPersonalViewModel.Contratos.Add(new Contrato
                    {
                        idContrato = itm.Contrato.idContrato,
                        nroContrato = itm.Contrato.nroContrato,
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
            if (ActualizarPersonalViewModel.Contratos.Count() == 0)
            {
                ActualizarPersonalViewModel.resultadoFind = string.Concat("No se encontraron resultado en busqueda");
            }
            else
            {
                ActualizarPersonalViewModel.resultadoFind = string.Concat("Resultado de busqueda: ");
            }
            return PartialView("_lstActualizarPersonal", ActualizarPersonalViewModel);
        }

        // <summary>
        // Obtener Contrato
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
        public ActionResult getEmpleado(int pIdContrato)
        {
            var objPersona =
                       from cnt in _db.Contrato
                       join emp in _db.Empleado on cnt.idEmpleado equals emp.idEmpleado
                       join cnd in _db.Candidato on emp.idCandidato equals cnd.idCandidato
                       join cvt in _db.Convocatoria on cnt.idConvocatoria equals cvt.idConvocatoria
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join seg in _db.Seguro on emp.idSeguro equals seg.idSeguro
                       join niv in _db.NivelEstudio on emp.idNivelEstudio equals niv.idNivelEstudio
                       join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona
                       join dni in _db.DocumentoIdentidad on per.idDocumentoIdentidad equals dni.idDocumentoIdentidad
                       where cnt.idContrato == pIdContrato
                       select new { Contrato = cnt, Empleado = emp, Puesto = pst, Persona = per, NivelEstudio = niv  };

            ActualizarPersonalViewModel ActualizarPersonal = new ActualizarPersonalViewModel() { };
            ActualizarPersonal.Contratos = new List<Contrato>();

            foreach (var itm in objPersona)
            {
                ActualizarPersonal.Contrato = new Contrato
                {
                    idContrato = itm.Contrato.idContrato,
                    nroContrato = itm.Contrato.nroContrato,
                    Empleado = new Empleado
                    {
                        contactoEmergencia = itm.Empleado.contactoEmergencia,
                        telefonoEmergencia = itm.Empleado.telefonoEmergencia,
                        cuentaBanco = itm.Empleado.cuentaBanco,
                        Candidato = new Candidato
                        {
                            Persona = new Persona
                            {
                                idPersona = itm.Persona.idPersona,
                                nombre = itm.Persona.nombre,
                                apellidoPaterno = itm.Persona.apellidoPaterno,
                                apellidoMaterno = itm.Persona.apellidoMaterno,
                                fechaNacimiento = itm.Persona.fechaNacimiento,
                                nroHijos = itm.Persona.nroHijos,
                                telefono = itm.Persona.telefono,
                                celular = itm.Persona.celular,
                                correoElectronico = itm.Persona.correoElectronico,
                                direccion = itm.Persona.direccion,
                                genero = itm.Persona.genero,
                                documentoIdentidad = itm.Persona.documentoIdentidad,
                                idDocumentoIdentidad = itm.Persona.idDocumentoIdentidad,
                                Nacionalidad = new Nacionalidad { idNacionalidad = itm.Persona.Nacionalidad.idNacionalidad, nacionalidad = itm.Persona.Nacionalidad.nacionalidad },
                                EstadoCivil = new EstadoCivil { idEstadoCivil = itm.Persona.EstadoCivil.idEstadoCivil , estadoCivil = itm.Persona.EstadoCivil.estadoCivil }
                            },
                        },
                        Banco = new Banco { idBanco = itm.Empleado.Banco.idBanco, nombreBanco = itm.Empleado.Banco.nombreBanco, prefijoCuenta = itm.Empleado.Banco.prefijoCuenta },
                        Seguro = new Seguro { idSeguro = itm.Empleado.Seguro.idSeguro, descripcionSeguro = itm.Empleado.Seguro.descripcionSeguro },
                        EstadoEmpleado = new EstadoEmpleado { idEstadoEmpleado = itm.Empleado.EstadoEmpleado.idEstadoEmpleado, estadoEmpleado = itm.Empleado.EstadoEmpleado.estadoEmpleado },
                        FondoPensiones = new FondoPensiones { idFondoPensiones = itm.Empleado.FondoPensiones.idFondoPensiones, fondoPensiones = itm.Empleado.FondoPensiones.fondoPensiones },
                        NivelEstudio = new NivelEstudio { idNivelEstudio = itm.Empleado.NivelEstudio.idNivelEstudio, gradoEstudio = itm.Empleado.NivelEstudio.gradoEstudio }
                    },
                    Convocatoria = new Convocatoria
                    {
                        idTipoPuesto = itm.Contrato.Convocatoria.idTipoPuesto,
                        idArea = itm.Contrato.Convocatoria.idArea,
                        idDesarrollo = itm.Contrato.Convocatoria.idDesarrollo,
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
                };
            }
            ActualizarPersonal.DocumentoIdentidadList = (from entry in _db.DocumentoIdentidad orderby entry.idDocumentoIdentidad ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedDocumentoIdentidadId = ActualizarPersonal.Contrato.Empleado.Candidato.Persona.idDocumentoIdentidad;

            ActualizarPersonal.TipoPuestoList = (from entry in _db.TipoPuesto orderby entry.idTipoPuesto ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedTipoPuestoId = ActualizarPersonal.Contrato.Convocatoria.idTipoPuesto;

            ActualizarPersonal.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedPuestoId = ActualizarPersonal.Contrato.Convocatoria.Puesto.idPuesto;

            ActualizarPersonal.AreaList = (from entry in _db.Area orderby entry.idArea ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedAreaId = Convert.ToInt16(ActualizarPersonal.Contrato.Convocatoria.idArea);

            ActualizarPersonal.DesarrolloList = (from entry in _db.Desarrollo orderby entry.idDesarrollo ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedDesarrolloId = Convert.ToInt16(ActualizarPersonal.Contrato.Convocatoria.idDesarrollo);

            ActualizarPersonal.NivelEstudioList = (from entry in _db.NivelEstudio orderby entry.idNivelEstudio ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedNivelEstudioId = ActualizarPersonal.Contrato.Empleado.NivelEstudio.idNivelEstudio;

            ActualizarPersonal.FondoPensioneList = (from entry in _db.FondoPensiones orderby entry.idFondoPensiones ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedFondoPensioneId = ActualizarPersonal.Contrato.Empleado.FondoPensiones.idFondoPensiones;

            ActualizarPersonal.EstadoEmpleadoList = (from entry in _db.EstadoEmpleado orderby entry.idEstadoEmpleado ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedEstadoEmpleadoId = ActualizarPersonal.Contrato.Empleado.EstadoEmpleado.idEstadoEmpleado;

            ActualizarPersonal.SeguroList = (from entry in _db.Seguro orderby entry.idSeguro ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedSeguroId = ActualizarPersonal.Contrato.Empleado.Seguro.idSeguro;

            ActualizarPersonal.BancoList = (from entry in _db.Banco orderby entry.idBanco ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedBancoId = ActualizarPersonal.Contrato.Empleado.Banco.idBanco;

            ActualizarPersonal.NacionalidadList = (from entry in _db.Nacionalidad orderby entry.idNacionalidad ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedNacionalidadId = ActualizarPersonal.Contrato.Empleado.Candidato.Persona.Nacionalidad.idNacionalidad;

            ActualizarPersonal.EstadoCivilList = (from entry in _db.EstadoCivil orderby entry.idEstadoCivil ascending select entry).Take(20).ToList();
            ActualizarPersonal.SelectedEstadoCivilId = ActualizarPersonal.Contrato.Empleado.Candidato.Persona.EstadoCivil.idEstadoCivil;

            return View(ActualizarPersonal);
            //return RedirectToAction("Index");
        }

        // <summary>
        // Obtener Prefijo Cta Bancaría
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
        public JsonResult getPrefijoCtaBanco(int pIdBanco)
        {
            return Json((from bco in _db.Banco
                         where (bco.idBanco == pIdBanco)
                         select new { Banco = bco }).Single().Banco.prefijoCuenta , JsonRequestBehavior.AllowGet);
        }

        // <summary>
        // Actualizar datos del empleado
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | Y. Condor</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | Y. Condor</remarks>
        public JsonResult setEmpleado(string pDocumentoIdentidad, string pDireccion, string pTelefono, string pCelular,
                                      string pEmail, int pNroHijos, int pIdNivelEstudio, int pIdFondoPensione, int pIdSeguro,
                                      int pIdEstadoEmpleado, string pContactoEmergencia, string pTelefonoEmergencia,
                                      int pIdBanco, string pCtaBanco)
        {
            var objEmpleado = _db.Empleado.First(x => x.Candidato.Persona.documentoIdentidad == pDocumentoIdentidad);
            objEmpleado.Candidato.Persona.direccion = pDireccion;
            objEmpleado.Candidato.Persona.telefono = pTelefono;
            objEmpleado.Candidato.Persona.celular = pCelular;
            objEmpleado.Candidato.Persona.correoElectronico = pEmail;
            objEmpleado.Candidato.Persona.nroHijos = pNroHijos;
            objEmpleado.idNivelEstudio  = pIdNivelEstudio;
            objEmpleado.idFondoPensiones = pIdFondoPensione;
            objEmpleado.idSeguro = pIdSeguro;
            objEmpleado.idEstadoEmpleado = pIdEstadoEmpleado;
            objEmpleado.contactoEmergencia = pContactoEmergencia;
            objEmpleado.telefonoEmergencia = pTelefonoEmergencia;
            objEmpleado.idBanco = pIdBanco;
            objEmpleado.cuentaBanco = pCtaBanco;
            _db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
