using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;
using System.Data.Entity.Validation;

namespace InnovaSchools.Controllers
{
    public class GenerarContratoController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Permite generar el contrato del candidato y/o empleado
        // </summary>
        // <returns>Fecha Creacion      : 06/09/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 06/09/0216 | M. MAURICIO</remarks>
        public ActionResult index()
        {
            GenerarContratoViewModel GenerarContrato = new GenerarContratoViewModel();
            GenerarContrato.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarContrato.Convocatoria = new Convocatoria();
            GenerarContrato.Convocatorias = new List<Convocatoria>();
            return View(GenerarContrato);
        }

        // <summary>
        // Listar Candidatos
        // </summary>
        // <returns>Fecha Creacion      : 06/09/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 06/09/0216 | M. MAURICIO</remarks>
        public ActionResult lstCandidatos(string pDocumentoIdentidad, string pNombre, string pApePaterno, string pApeMaterno, Int16 pIdPuesto)
        {
            GenerarContratoViewModel GenerarContratoViewModel = new GenerarContratoViewModel()
            {
                //Candidato = new Candidato()
            };
            GenerarContratoViewModel.Convocatorias = new List<Convocatoria>();

            var objPersona =
                       from cvt in _db.Convocatoria
                       join ccd in _db.ConvocatoriaCandidato on cvt.idConvocatoria equals ccd.idConvocatoria
                       join cnd in _db.Candidato on ccd.idCandidato equals cnd.idCandidato
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join per in _db.Persona on cnd.idPersona equals per.idPersona
                       where cnd.idEstadoCandidato == 2 //Filtrar solo lo que están Verificado
                       select new { Candidato = cnd, Convocatoria = cvt, Puesto = pst, Persona = per };

            if (pDocumentoIdentidad.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.documentoIdentidad.Contains(pDocumentoIdentidad)); }
            if (pNombre.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.nombre.Contains(pNombre)); }
            if (pApePaterno.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoPaterno.Contains(pApePaterno)); }
            if (pApeMaterno.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoMaterno.Contains(pApeMaterno)); }
            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Convocatoria.Puesto.idPuesto == pIdPuesto); }

            foreach (var itm in objPersona)
            {
                if (GenerarContratoViewModel.Convocatorias.Where(w => w.ConvocatoriaCandidato.Candidato.Persona.idPersona == itm.Persona.idPersona).ToList().Count == 0)
                {
                    GenerarContratoViewModel.Convocatorias.Add(new Convocatoria
                    {
                        fechaVencimientoDocumento = itm.Convocatoria.fechaVencimientoDocumento,
                        ConvocatoriaCandidato = new ConvocatoriaCandidato
                        {
                            Candidato = new Candidato
                            {
                                Persona = new Persona
                                {
                                    fecha_inicio = itm.Convocatoria.fechaInicioPublicacion.ToShortDateString(),
                                    fecha_fin = itm.Convocatoria.fechaFinPublicacion.ToShortDateString(),
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
                        Puesto = new Puesto
                        {
                            idPuesto = itm.Puesto.idPuesto,
                            descripcionPuesto = itm.Puesto.descripcionPuesto,
                        }
                    });
                }
            }
            if (GenerarContratoViewModel.Convocatorias.Count() == 0)
            {
                GenerarContratoViewModel.resultadoFind = string.Concat("No se encontraron resultado en busqueda");
            }
            else
            {
                //VerificarDocumentacionViewModel.resultadoFind = string.Concat("Resultado de busqueda: De ", fechaInicio.ToShortDateString(), " hasta ", fechaFin.ToShortDateString());
                GenerarContratoViewModel.resultadoFind = string.Concat("Resultado de busqueda");
            }
            return PartialView("_lstGenerarContrato", GenerarContratoViewModel);
        }

        // <summary>
        // Obtener Contrato
        // </summary>
        // <returns>Fecha Creacion      : 06/09/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 06/09/0216 | M. MAURICIO</remarks>
        public ActionResult getContrato(int pIdPersona)
        {
            var objPersona =
                      from cvt in _db.Convocatoria
                      join ccd in _db.ConvocatoriaCandidato on cvt.idConvocatoria equals ccd.idConvocatoria
                      join cnd in _db.Candidato on ccd.idCandidato equals cnd.idCandidato
                      join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                      join tpt in _db.TipoPuesto on cvt.idTipoPuesto equals tpt.idTipoPuesto
                      join are in _db.Area on cvt.idArea equals are.idArea
                      join dsr in _db.Desarrollo on cvt.idDesarrollo equals dsr.idDesarrollo
                      join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona
                      join nac in _db.Nacionalidad on per.idNacionalidad equals nac.idNacionalidad
                      join dni in _db.DocumentoIdentidad on per.idDocumentoIdentidad equals dni.idDocumentoIdentidad
                      //join emp in _db.Empleado on cnd.Empleado.idEmpleado equals emp.idEmpleado
                      //join ctt in _db.Contrato on emp.Contrato.idContrato equals ctt.idContrato
                      //join tct in _db.TipoContrato on ctt.idTipoContrato equals tct.idTipoContrato
                      where per.idPersona == pIdPersona
                      select new { Candidato = cnd, Convocatoria = cvt, Puesto = pst, Persona = per, Nacionalidad = nac, 
                                   TipoPuesto = tpt, Area = are, Desarrollo = dsr, DocumentoIdentidad = dni };

            GenerarContratoViewModel GenerarContratoViewModel = new GenerarContratoViewModel();

            foreach (var itm in objPersona)
            {
                GenerarContratoViewModel.Convocatoria = new Convocatoria
                {

                    fechaVencimientoDocumento = itm.Convocatoria.fechaVencimientoDocumento,
                    ConvocatoriaCandidato = new ConvocatoriaCandidato
                    {
                        Candidato = new Candidato
                        {
                            Persona = new Persona
                            {
                                fecha_inicio = itm.Convocatoria.fechaInicioPublicacion.ToShortDateString(),
                                fecha_fin = itm.Convocatoria.fechaFinPublicacion.ToShortDateString(),
                                idPersona = itm.Persona.idPersona,
                                nombre = itm.Persona.nombre,
                                apellidoPaterno = itm.Persona.apellidoPaterno,
                                apellidoMaterno = itm.Persona.apellidoMaterno,
                                telefono = itm.Persona.telefono,
                                direccion = itm.Persona.direccion,
                                documentoIdentidad = itm.Persona.documentoIdentidad,
                                celular = itm.Persona.celular,
                                correoElectronico = itm.Persona.correoElectronico,
                                Nacionalidad = new Nacionalidad { idNacionalidad = itm.Nacionalidad.idNacionalidad, nacionalidad = itm.Nacionalidad.nacionalidad },
                                DocumentoIdentidad = new DocumentoIdentidad
                                {
                                    idDocumentoIdentidad = itm.DocumentoIdentidad.idDocumentoIdentidad,
                                    descripcion = itm.DocumentoIdentidad.descripcion
                                }
                            },
                        }
                    },
                    TipoPuesto = new TipoPuesto { idTipoPuesto = itm.TipoPuesto.idTipoPuesto, descripcionPuesto = itm.TipoPuesto.descripcionPuesto },
                    Puesto = new Puesto { idPuesto = itm.Puesto.idPuesto, descripcionPuesto = itm.Puesto.descripcionPuesto },
                    Area = new Area { descripcionArea = itm.Area.descripcionArea },
                    Desarrollo = new Desarrollo { descripcionDesarrollo = itm.Desarrollo.descripcionDesarrollo }
                };
                GenerarContratoViewModel.fechaIngreso = itm.Convocatoria.fechaInicioPublicacion;
                GenerarContratoViewModel.fechaCese = itm.Convocatoria.fechaFinPublicacion;
                GenerarContratoViewModel.estadoCandidato = itm.Candidato.EstadoCandidato.estadoCandidato;  
            }
            GenerarContratoViewModel.DocumentoIdentidadList = (from entry in _db.DocumentoIdentidad orderby entry.idDocumentoIdentidad ascending select entry).Take(20).ToList();
            GenerarContratoViewModel.SelectedDocumentoIdentidadId = GenerarContratoViewModel.Convocatoria.ConvocatoriaCandidato.Candidato.Persona.DocumentoIdentidad.idDocumentoIdentidad;

            GenerarContratoViewModel.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            GenerarContratoViewModel.SelectedPuestoId = GenerarContratoViewModel.Convocatoria.Puesto.idPuesto;

            GenerarContratoViewModel.TipoPuestoList = (from entry in _db.TipoPuesto orderby entry.idTipoPuesto ascending select entry).Take(20).ToList();
            GenerarContratoViewModel.SelectedTipoPuestoId = GenerarContratoViewModel.Convocatoria.TipoPuesto.idTipoPuesto;

            GenerarContratoViewModel.TipoContratoList = (from entry in _db.TipoContrato orderby entry.idTipoContrato ascending select entry).Take(20).ToList();
            GenerarContratoViewModel.TipoContratoTiempoList = (from entry in _db.TipoContratoTiempo orderby entry.idTipoContratoTiempo ascending select entry).Take(20).ToList();
            //GenerarContratoViewModel.SelectedTipoContratoId = GenerarContratoViewModel  .Candidato.Convocatoria.idPuesto;
            GenerarContratoViewModel.NivelEstudioList = (from entry in _db.NivelEstudio orderby entry.idNivelEstudio ascending select entry).Take(20).ToList();
            //GenerarContratoViewModel.SelectedNivelEstudioId = GenerarContratoViewModel.Contrato.Empleado.NivelEstudio.idNivelEstudio;
            GenerarContratoViewModel.SeguroList = (from entry in _db.Seguro orderby entry.idSeguro ascending select entry).Take(20).ToList();
            //GenerarContratoViewModel.SelectedSeguroId = GenerarContratoViewModel.Contrato.Empleado.Seguro.idSeguro;
            GenerarContratoViewModel.BancoList = (from entry in _db.Banco orderby entry.idBanco ascending select entry).Take(20).ToList();
            //GenerarContratoViewModel.SelectedBancoId = GenerarContratoViewModel.Contrato.Empleado.Banco.idBanco;


            return View(GenerarContratoViewModel);
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
                         select new { Banco = bco }).Single().Banco.prefijoCuenta, JsonRequestBehavior.AllowGet);
        }

        // <summary>
        // Actualizar datos del empleado y su contrato
        // </summary>
        // <returns>Fecha Creacion      : 06/09/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 06/09/0216 | M. MAURICIO</remarks>
        public JsonResult setEmpleado(string pDni, int pTipoContrato, string pSalario,
                                      string pFechaInicio, string pFechaFin, Int16 pIdConvocatoriaTiempo,
                                      Int16 pIdSeguro, Int16 pIdBanco, Int16 pIdNivelEstudio,
                                      string pCuentaBanco)
        {
            //var objPersona = (from per in _db.Persona
            //                  join cnd in _db.Candidato on per.idPersona equals cnd.idPersona
            //                  where per.documentoIdentidad == pDni 
            //                  select new { Persona = per, Candidato = cnd}).First();

            var objPersona = (from cvt in _db.Convocatoria
                              join ccd in _db.ConvocatoriaCandidato on cvt.idConvocatoria equals ccd.idConvocatoria
                              join cnd in _db.Candidato on ccd.idCandidato equals cnd.idCandidato
                              join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                              join per in _db.Persona on cnd.idPersona equals per.idPersona
                              where per.documentoIdentidad == pDni
                              select new { Candidato = cnd, Convocatoria = cvt, Puesto = pst, Persona = per }).First(); ;

            string vIdContrato;
            try
            {
                var objEmpleado = new Empleado
                {
                    idCandidato = objPersona.Candidato.idCandidato,
                    idFondoPensiones = 1,
                    idSeguro = pIdSeguro,
                    idEstadoEmpleado = 1,
                    idBanco = pIdBanco,
                    idNivelEstudio = pIdNivelEstudio,
                    contactoEmergencia = "",
                    telefonoEmergencia = "",
                    cuentaBanco = pCuentaBanco
                };
                _db.Empleado.Add(objEmpleado);
                _db.SaveChanges();

                var objContrato = new Contrato
                {
                    //nroContrato = string.Concat(DateTime.Now.Year.ToString(), objPersona.Convocatoria.TipoPuesto.idTipoPuesto, objPersona.Convocatoria.Puesto.idPuesto, objPersona.Convocatoria.Area.idArea),
                    fechaInicioContrato = Convert.ToDateTime(pFechaInicio),
                    
                    fechaFinContrato = Convert.ToDateTime(pFechaFin),
                    idEmpleado = objEmpleado.idEmpleado,
                    salario = Convert.ToDecimal(pSalario),
                    idTipoContrato = pTipoContrato,
                    idConvocatoria = objPersona.Convocatoria.idConvocatoria,
                    idTipoContratoTiempo = pIdConvocatoriaTiempo
                };
                _db.Contrato.Add(objContrato);                
                _db.SaveChanges();

                var objContratoNroContrato = _db.Contrato.First(x => x.idContrato == objContrato.idContrato);
                objContratoNroContrato.nroContrato = string.Concat(DateTime.Now.Year.ToString(),
                                                                   objPersona.Convocatoria.TipoPuesto.idTipoPuesto.ToString(),
                                                                   objPersona.Convocatoria.Puesto.idPuesto.ToString(), 
                                                                   objPersona.Convocatoria.Area.idArea.ToString(),
                                                                   objContrato.idContrato.ToString().PadLeft(7,'0'));
                _db.SaveChanges();

                var objCandidato = _db.Candidato.First(x => x.idCandidato == objEmpleado.idCandidato);
                objCandidato.idEstadoCandidato = 5; //Estado Contratado
                _db.SaveChanges();

                vIdContrato = Convert.ToString(objContrato.nroContrato);
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
