using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;
using System.IO;

namespace InnovaSchools.Controllers
{
    public class VerificarDocumentacionController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Verificar la documentación del Personal
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public ActionResult index()
        {
            VerificarDocumentacionViewModel VerificarDocumentacion = new VerificarDocumentacionViewModel();
            VerificarDocumentacion.TipoPuestoList = (from entry in _db.TipoPuesto orderby entry.idTipoPuesto ascending select entry).Take(20).ToList();
            VerificarDocumentacion.EstadoCandidatoList = (from entry in _db.EstadoCandidato orderby entry.idEstadoCandidato ascending select entry).Take(20).ToList();
            VerificarDocumentacion.Convocatoria = new Convocatoria();
            VerificarDocumentacion.Convocatorias = new List<Convocatoria>();
            return View(VerificarDocumentacion);
        }
        
        // <summary>
        // Listar Candidatos
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public ActionResult lstCandidatos(string pFechaInicio, string pFechaFin, string pNombre, string pApePaterno, Int16 pIdTipoPuesto, Int16 pIdEstadoCandidato)
        {
            var fechaInicio = Convert.ToDateTime(pFechaInicio);
            var fechaFin = Convert.ToDateTime(pFechaFin);

            VerificarDocumentacionViewModel VerificarDocumentacionViewModel = new VerificarDocumentacionViewModel(){};
            VerificarDocumentacionViewModel.Convocatorias = new List<Convocatoria>();

            var objPersona =
                       from cvt in _db.Convocatoria
                       join ccd in _db.ConvocatoriaCandidato on cvt.idConvocatoria equals ccd.idConvocatoria
                       join cnd in _db.Candidato on ccd.idCandidato equals cnd.idCandidato
                       //join pst in _db.Puesto on cvt.Puesto .idPuesto equals pst.idPuesto
                       join pst in _db.Puesto on cvt.idPuesto equals pst.idPuesto
                       join tpt in _db.TipoPuesto on cvt.idTipoPuesto equals tpt.idTipoPuesto
                       //join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona
                       join per in _db.Persona on cnd.idPersona equals per.idPersona
                       join tdc in _db.TipoDocumento on per.idTipoDocumento equals tdc.idTipoDocumento
                       join ecd in _db.EstadoCandidato on cnd.idEstadoCandidato equals ecd.idEstadoCandidato
                       //where (cvt.fechaInicioPublicacion >= fechaInicio && cvt.fechaFinPublicacion <= fechaFin) 
                       where cnd.idEstadoCandidato != 5
                       select new { Convocatoria = cvt, ConvocatoriaCandidato = ccd, Candidato = cnd, EstadoCandidato = ecd, TipoPuesto = tpt, Puesto = pst, Persona = per };

            if (pNombre.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.nombre.Contains(pNombre)); }
            if (pApePaterno.Trim().LongCount() > 0) { objPersona = objPersona.Where(x => x.Persona.apellidoPaterno.Contains(pApePaterno)); }
            if (pIdTipoPuesto > 0) { objPersona = objPersona.Where(x => x.Convocatoria.idTipoPuesto == pIdTipoPuesto); }
            if (pIdEstadoCandidato > 0) { objPersona = objPersona.Where(x => x.Candidato.idEstadoCandidato == pIdEstadoCandidato); }

            foreach (var itm in objPersona)
            {
                if (VerificarDocumentacionViewModel.Convocatorias.Where(w => w.ConvocatoriaCandidato.Candidato.Persona.idPersona == itm.Persona.idPersona).ToList().Count == 0)
                {
                    VerificarDocumentacionViewModel.Convocatorias.Add(new Convocatoria
                    {
                        fechaVencimientoDocumentoStr = itm.Convocatoria.fechaVencimientoDocumento.ToShortDateString(),
                        ConvocatoriaCandidato = new ConvocatoriaCandidato
                        {
                            Candidato = new Candidato
                            {
                                EstadoCandidato = new EstadoCandidato
                                {
                                    idEstadoCandidato = itm.EstadoCandidato.idEstadoCandidato,
                                    estadoCandidato = itm.EstadoCandidato.estadoCandidato
                                },
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
                                    TipoDocumento = new TipoDocumento { idTipoDocumento = itm.Persona.idTipoDocumento, descripcionDocumento = itm.Persona.TipoDocumento.descripcionDocumento }
                                },

                            }
                        },
                        TipoPuesto = new TipoPuesto { idTipoPuesto = itm.TipoPuesto.idTipoPuesto, descripcionPuesto = itm.TipoPuesto.descripcionPuesto },
                        Puesto = new Puesto { idPuesto = itm.Puesto.idPuesto, descripcionPuesto = itm.Puesto.descripcionPuesto }
                    });
                }
            }
            if (VerificarDocumentacionViewModel.Convocatorias.Count() == 0)
            {
                VerificarDocumentacionViewModel.resultadoFind = string.Concat("No se encontraron resultado en busqueda");
            }
            else
            {
                VerificarDocumentacionViewModel.resultadoFind = string.Concat("Resultado de busqueda: De ", fechaInicio.ToShortDateString(), " hasta ", fechaFin.ToShortDateString());
            }
            return PartialView("_lstVerificarDocumento", VerificarDocumentacionViewModel);
        }

        // <summary>
        // Obtener Contrato
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public ActionResult getContrato(int pIdPersona)
        {
            var objPersona =
                      from cvt in _db.Convocatoria
                      join ccd in _db.ConvocatoriaCandidato on cvt.idConvocatoria equals ccd.idConvocatoria
                      join cnd in _db.Candidato on ccd.idCandidato equals cnd.idCandidato
                      join pst in _db.Puesto on cvt.Puesto.idPuesto equals pst.idPuesto
                      join per in _db.Persona on cnd.Persona.idPersona equals per.idPersona
                      where per.idPersona == pIdPersona
                      select new { Candidato = cnd, Convocatoria = cvt, Puesto = pst, Persona = per };
            
            VerificarDocumentacionViewModel verificarDocumento = new VerificarDocumentacionViewModel();

            foreach (var itm in objPersona)
            {
                verificarDocumento.Convocatoria = new Convocatoria
                {
                    fechaFinPublicacionStr = itm.Convocatoria.fechaFinPublicacion.ToShortDateString(),
                    fechaVencimientoDocumentoStr = itm.Convocatoria.fechaVencimientoDocumento.ToShortDateString(),
                    idTipoPuesto = itm.Convocatoria.idTipoPuesto,
                    idPuesto = itm.Convocatoria.idPuesto,
                    idArea = itm.Convocatoria.idArea,
                    idDesarrollo = itm.Convocatoria.idDesarrollo,
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
                                TipoDocumento = new TipoDocumento { idTipoDocumento = itm.Persona.TipoDocumento.idTipoDocumento, descripcionDocumento = itm.Persona.TipoDocumento.descripcionDocumento }
                            },
                        }
                    },
                    Puesto = new Puesto
                    {
                        idPuesto = itm.Puesto.idPuesto,
                        descripcionPuesto = itm.Puesto.descripcionPuesto,
                    }
                };
            };
            verificarDocumento.TipoDocumentoList = (from entry in _db.TipoDocumento orderby entry.idTipoDocumento ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedTipoDocumentoId = verificarDocumento.Convocatoria.ConvocatoriaCandidato.Candidato.Persona.TipoDocumento.idTipoDocumento;
            
            verificarDocumento.TipoPuestoList = (from entry in _db.TipoPuesto orderby entry.idTipoPuesto ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedTipoPuestoId = verificarDocumento.Convocatoria.idTipoPuesto;
            
            verificarDocumento.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedPuestoId = verificarDocumento.Convocatoria.idPuesto;
            
            verificarDocumento.AreaList = (from entry in _db.Area orderby entry.idArea ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedAreaId = Convert.ToInt16(verificarDocumento.Convocatoria.idArea);
            
            verificarDocumento.DesarrolloList = (from entry in _db.Desarrollo orderby entry.idDesarrollo ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedDesarrolloId = Convert.ToInt16 (verificarDocumento.Convocatoria.idDesarrollo);
            return View(verificarDocumento);
            //return RedirectToAction("Index");
        }

        // <summary>
        // Actualizar Documentos de Contrato
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public JsonResult setContrato(int pIdPersona, string pNombre, string pApePaterno, string pApeMaterno, string pDireccion, string pTelefono, string pCelular, Int16 pIdPuesto, string pEmail,
                                      string pRutaImgDni, string pRutaImgDomiciliaria, string pRutaImgPenales, string pRutaImgPoliciales, string pRutaImgtitulo,
                                      HttpPostedFileBase Input_folder_Dni)
        {
            VerificarDocumentacionViewModel VerificarDocumentacion = new VerificarDocumentacionViewModel();

            var objCandidato = _db.Candidato.First(x => x.Persona.idPersona == pIdPersona);
            objCandidato.rutaImgDni = Path.GetFileName(pRutaImgDni);
            objCandidato.rutaImgDeclaracionJurada = Path.GetFileName(pRutaImgDomiciliaria);
            objCandidato.rutaImgAntecedentesPenales = Path.GetFileName(pRutaImgPenales);
            objCandidato.rutaImgAntecedentesPoliciales = Path.GetFileName(pRutaImgPoliciales);
            objCandidato.rutaImgTituloProfesional = Path.GetFileName(pRutaImgtitulo);
            
            //var objPersona = _db.Persona.First(x => x.codigo_persona == pDni);
            //objPersona.nombre = pNombre;
            //objPersona.apellido_paterno = pApePaterno;
            //objPersona.apellido_materno = pApeMaterno;
            //objPersona.direccion = pDireccion;
            //objPersona.telefono = pTelefono;
            //objPersona.celular = pCelular;
            //objPersona.id_puesto = pIdPuesto;
            //objPersona.email = pEmail;

            
            //string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            //file.SaveAs(Server.MapPath("~/Uploads/" + archivo));

            //if (input_folder_Dni != null && input_folder_Dni.ContentLength > 0)
            //{
            //    // extract only the filename
            //    var fileName = Path.GetFileName(input_folder_Dni.FileName);
            //    // store the file inside ~/App_Data/uploads folder
            //    var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
            //    input_folder_Dni.SaveAs(path);
            //}


            //if (Request != null)
            //{
            //    HttpPostedFileBase file = Request.Files["fileDni"];

            //    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            //    {
            //        string fileName = file.FileName;
            //        string fileContentType = file.ContentType;
            //        byte[] fileBytes = new byte[file.ContentLength];
            //        file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
            //    }
            //}

            //if (pInput_folder_Dni != null)
            //{
            //    foreach (var file in pInput_folder_Dni)
            //    {
            //        // Verify that the user selected a file
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            // extract only the fielname
            //            var fileName = Path.GetFileName(file.FileName);
            //            // TODO: need to define destination
            //            var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
            //            file.SaveAs(path); //upload for example
            //        }
            //    }
            //}

            _db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
            //return View(true);
        }


        [HttpPost]
        public void Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Junk/"), fileName);
                file.SaveAs(path);
            }

        }
        public JsonResult ImportCsv(IEnumerable<HttpPostedFileBase> files, String cid)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(file.FileName);
                        // TODO: need to define destination
                        var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
                        file.SaveAs(path); //upload for example
                    }
                }
            }

            //String jsonStr = JsonConvert.SerializeObject(ipRestriction);
            //return Json(jsonStr, JsonRequestBehavior.AllowGet); //Now return Json as you need.
            return Json(true, JsonRequestBehavior.AllowGet); //Now return Json as you need.
        }

    }
}
