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
            //ProgramarPersonal.TurnoList = (from entry in _db.Turno orderby entry.id_turno ascending select entry).Take(20).ToList();
            VerificarDocumentacion.PuestoList = (from entry in _db.Puesto orderby entry.id_puesto ascending select entry).Take(20).ToList();
            VerificarDocumentacion.Candidato = new Candidato();
            VerificarDocumentacion.Candidatos = new List<Candidato>();
            return View(VerificarDocumentacion);
        }
        
        // <summary>
        // Listar Candidatos
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public ActionResult lstCandidatos(string pFechaInicio, string pFechaFin, Int16 pIdPuesto)
        {
            //DateTime fechaInicio = Convert.ToDateTime(pFechaInicio);
            //DateTime fechaFin = Convert.ToDateTime(pFechaFin);
            var fechaInicio = Convert.ToDateTime(pFechaInicio);
            var fechaFin = Convert.ToDateTime(pFechaFin);

            VerificarDocumentacionViewModel VerificarDocumentacionViewModel = new VerificarDocumentacionViewModel()
            {
                Candidato = new Candidato()
            };
            VerificarDocumentacionViewModel.Candidatos = new List<Candidato>();
            
            var objPersona =
                       from cnd in _db.Candidato
                       join cvt in _db.Convocatoria on cnd.id_convocatoria equals cvt.id_convocatoria
                       join pst in _db.Puesto on cvt.id_puesto equals pst.id_puesto
                       join per in _db.Persona on cnd.codigo_persona equals per.codigo_persona
                       //where (cvt.fechaInicioPublicacion >= fechaInicio && cvt.fechaFinPublicacion <= fechaFin) 
                       select new { Candidato = cnd, Convocatoria = cvt, Puesto = pst, Persona = per };

            if (pIdPuesto > 0) { objPersona = objPersona.Where(x => x.Convocatoria.id_puesto == pIdPuesto); }

            foreach (var itmPrs in objPersona)
            {

                //&&
                //    _db.ProgramarPersonal.Where(w => w.fecha >= fechaInicio &&
                //                                       w.fecha <= fechaFin).Count() == 0

                if (VerificarDocumentacionViewModel.Candidatos.Where(w => w.codigo_persona == itmPrs.Persona.codigo_persona).ToList().Count == 0)
                {
                    VerificarDocumentacionViewModel.Candidatos.Add(new Candidato
                    {                        
                        Persona = new Persona
                        {
                            fecha_inicio = itmPrs.Convocatoria.fechaInicioPublicacion.ToShortDateString(),
                            fecha_fin = itmPrs.Convocatoria.fechaFinPublicacion.ToShortDateString(),
                            id_programar_persona = 0,
                            codigo_persona = itmPrs.Persona.codigo_persona,
                            nombre = itmPrs.Persona.nombre,
                            apellido_paterno = itmPrs.Persona.apellido_paterno,
                            apellido_materno = itmPrs.Persona.apellido_materno,
                            telefono = itmPrs.Persona.telefono,
                            direccion = itmPrs.Persona.direccion,
                            id_puesto = itmPrs.Persona.id_puesto,
                            Puesto = new Puesto { descripcion_puesto = itmPrs.Puesto.descripcion_puesto },
                            Turno = new Turno { descripcion_turno = "" }
                        }
                    });
                }
            }
            if (VerificarDocumentacionViewModel.Candidatos.Count() == 0)
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
        public ActionResult getContrato(string pCodigo_persona)
        {

            var objPersona =
                       from per in _db.Persona
                       join cdt in _db.Candidato on per.codigo_persona equals cdt.codigo_persona
                       join pst in _db.Puesto on per.id_puesto equals pst.id_puesto
                       where cdt.codigo_persona == pCodigo_persona
                       select new { Persona = per, Candidato = cdt, Puest = pst };

            VerificarDocumentacionViewModel verificarDocumento = new VerificarDocumentacionViewModel();

            foreach (var itm in objPersona)
            {
                verificarDocumento.Candidato = new Candidato
                {
                    codigo_persona = itm.Persona.codigo_persona,
                    rutaImgDni = itm.Candidato.rutaImgDni,
                    rutaImgDeclaracionJurada = itm.Candidato.rutaImgDeclaracionJurada,
                    rutaImgAntecedentesPenales = itm.Candidato.rutaImgAntecedentesPenales,
                    rutaImgAntecedentesPoliciales = itm.Candidato.rutaImgAntecedentesPoliciales,
                    rutaImgTituloProfesional = itm.Candidato.rutaImgTituloProfesional,
                    Persona = new Persona
                    {
                        codigo_persona = itm.Persona.codigo_persona,
                        nombre = itm.Persona.nombre,
                        apellido_paterno = itm.Persona.apellido_paterno,
                        apellido_materno = itm.Persona.apellido_materno,
                        direccion = itm.Persona.direccion,
                        telefono = itm.Persona.telefono,
                        celular = itm.Persona.celular,
                        id_puesto = itm.Persona.id_puesto,
                        email = itm.Persona.email,
                        Puesto = new Puesto
                        {
                            id_puesto = itm.Persona.Puesto.id_puesto,
                            descripcion_puesto = itm.Persona.Puesto.descripcion_puesto
                        }
                    }
                    
                };                
            };

            verificarDocumento.PuestoList = (from entry in _db.Puesto orderby entry.id_puesto ascending select entry).Take(20).ToList();
            verificarDocumento.SelectedPuestoId = verificarDocumento.Candidato.Persona.id_puesto;

            return View(verificarDocumento);
        }

        // <summary>
        // Actualizar Documentos de Contrato
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public JsonResult setContrato(string pDni, string pNombre, string pApePaterno, string pApeMaterno, string pDireccion, string pTelefono, string pCelular, Int16 pIdPuesto, string pEmail,
                                      string pRutaImgDni, string pRutaImgDomiciliaria, string pRutaImgPenales, string pRutaImgPoliciales, string pRutaImgtitulo,
                                      HttpPostedFileBase Input_folder_Dni)
        {
            var objCandidato = _db.Candidato.First(x => x.codigo_persona == pDni);
            objCandidato.rutaImgDni = Path.GetFileName(pRutaImgDni);
            objCandidato.rutaImgDeclaracionJurada = Path.GetFileName(pRutaImgDomiciliaria);
            objCandidato.rutaImgAntecedentesPenales = Path.GetFileName(pRutaImgPenales);
            objCandidato.rutaImgAntecedentesPoliciales = Path.GetFileName(pRutaImgPoliciales);
            objCandidato.rutaImgTituloProfesional = Path.GetFileName(pRutaImgtitulo);
            
            var objPersona = _db.Persona.First(x => x.codigo_persona == pDni);
            objPersona.nombre = pNombre;
            objPersona.apellido_paterno = pApePaterno;
            objPersona.apellido_materno = pApeMaterno;
            objPersona.direccion = pDireccion;
            objPersona.telefono = pTelefono;
            objPersona.celular = pCelular;
            objPersona.id_puesto = pIdPuesto;
            objPersona.email = pEmail;

            
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
