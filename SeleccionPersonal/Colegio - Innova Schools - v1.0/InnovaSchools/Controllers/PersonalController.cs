using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using InnovaSchools.Models;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace InnovaSchools.Controllers
{
    public class PersonalController : Controller
    {

        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Mostrar Persona
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>
        public ActionResult index()
        {
            PersonalViewModel Personal = new PersonalViewModel();

            Personal.Persona = new Persona();
            Personal.Personas = new List<Persona>();

            return View(Personal);
        }

        [HttpPost]
        public JsonResult getTotalFilas()
        {
            return Json(_db.Persona.Count());
        }

        // <summary>
        // Listar Personas
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>

        public ActionResult lstPersonas(string pDni, string pNombre, string pApePaterno, string pApeMaterno)
        {

            PersonalViewModel PersonalViewModel = new PersonalViewModel()
            {
                Persona = new Persona()
            };
            PersonalViewModel.Personas = new List<Persona>();

            //var personas =
            //           from per in _db.Persona
            //           join pst in _db.Puesto on per.id_puesto equals pst.id_puesto
            //           select new { Persona = per, Puest = pst };

            ////if (pDni.Trim().LongCount() > 0) { personas = personas.Where(x => x.Persona.id_persona == pDni); }
            //if (pNombre.Trim().LongCount() > 0) { personas = personas.Where(x => x.Persona.nombre.Contains(pNombre)); }
            //if (pApePaterno.Trim().LongCount() > 0) { personas = personas.Where(x => x.Persona.apellido_paterno.Contains(pApePaterno)); }
            //if (pApeMaterno.Trim().LongCount() > 0) { personas = personas.Where(x => x.Persona.apellido_materno.Contains(pApeMaterno)); }

            //PersonalViewModel.resultadoFind = string.Concat("Se encontraron los siguientes resultados: ", personas.Count().ToString());

            //foreach (var itm in personas)
            //{
            //    PersonalViewModel.Personas.Add(new Persona
            //    {
            //        id_persona = itm.Persona.id_persona,
            //        nombre = itm.Persona.nombre,
            //        apellido_paterno = itm.Persona.apellido_paterno,
            //        apellido_materno = itm.Persona.apellido_materno,
            //        telefono = itm.Persona.telefono,
            //        direccion = itm.Persona.direccion,
            //        id_puesto = itm.Persona.id_puesto,
            //        Puesto = new Puesto { descripcion_puesto = itm.Persona.Puesto.descripcion_puesto }
            //    });
            //};

            return PartialView("_lstPersonas", PersonalViewModel);
        }

        // <summary>
        // Obtener Persona
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>
        public ActionResult getPersona(string pDni)
        {

            //var objPersona =
            //           from per in _db.Persona
            //           join pst in _db.Puesto on per.id_puesto equals pst.id_puesto
            //           where per.codigo_persona == pDni
            //           select new { Persona = per, Puest = pst };

            PersonalViewModel Personal = new PersonalViewModel();

            //foreach (var itm in objPersona)
            //{
            //    Personal.Persona = new Persona
            //    {
            //        id_persona = itm.Persona.id_persona,
            //        nombre = itm.Persona.nombre,
            //        apellido_paterno = itm.Persona.apellido_paterno,
            //        apellido_materno = itm.Persona.apellido_materno,
            //        direccion = itm.Persona.direccion,
            //        telefono = itm.Persona.telefono,
            //        celular = itm.Persona.celular,
            //        id_puesto = itm.Persona.id_puesto,
            //        //brevete = itm.Persona.brevete,
            //        Puesto = new Puesto
            //        {
            //            id_puesto = itm.Persona.Puesto.id_puesto,
            //            descripcion_puesto = itm.Persona.Puesto.descripcion_puesto
            //        }
            //    };
            //};

            //Personal.PuestoList = (from entry in _db.Puesto orderby entry.id_puesto ascending select entry).Take(20).ToList();
            //Personal.SelectedPuestoId = Personal.Persona.id_puesto;

            return View(Personal);
        }

        // <summary>
        // Modificar Persona
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>
        public JsonResult setPersona(string pDni, string pNombre, string pApePaterno, string pApeMaterno, string pDireccion, string pTelefono, string pCelular, Int16 pIdPuesto, string pBrevete)
        {
            //var objPersona = _db.Persona.First(x => x.dni == pDni);
            //objPersona.nombre = pNombre;
            //objPersona.apellido_paterno = pApePaterno;
            //objPersona.apellido_materno = pApeMaterno;
            //objPersona.direccion = pDireccion;
            //objPersona.telefono = pTelefono;
            //objPersona.celular = pCelular;
            //objPersona.id_puesto = pIdPuesto;
            //objPersona.brevete = pBrevete;

            _db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // <summary>
        // Agregar Persona
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>
        public ActionResult newPersona()
        {
            PersonalViewModel Personal = new PersonalViewModel();

            Personal.Persona = new Persona();
            Personal.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();

            return View(Personal);
        }

        // <summary>
        // Registrar Persona
        // </summary>
        // <returns>Fecha Creacion      : 25/05/0216 | M. ARAUJO</returns>
        // <remarks>Fecha Modificacion  : 25/05/0216 | H. HUAMANCAMA</remarks>
        public JsonResult addPersona(string pDni, string pNombre, string pApellidoPaterno, string pApellidoMaterno, 
                                     string pDireccion, string pTelefono, string pCelular, int pIdPuesto, string pBrevete)
        {
            bool vResultado = false;
            PersonalViewModel ActualizarPersonalViewModel = new PersonalViewModel(){};
            try
            {
                //if (_db.Persona.Where(w => w.dni == pDni).Count() == 0)
                //{
                //    _db.Persona.Add(new Persona
                //    {
                //        dni = pDni,
                //        nombre = pNombre,
                //        apellido_paterno = pApellidoPaterno,
                //        apellido_materno = pApellidoMaterno,
                //        direccion = pDireccion,
                //        telefono = pTelefono,
                //        celular = pCelular,
                //        id_puesto = pIdPuesto,
                //        brevete = pBrevete
                //    });
                //    _db.SaveChanges();
                //    vResultado = true;
                //}
                //else
                //{
                //    vResultado = false;
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            ActualizarPersonalViewModel.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarPersonalViewModel.Persona = new Persona();
            ActualizarPersonalViewModel.Personas = new List<Persona>();
            return Json(vResultado, JsonRequestBehavior.AllowGet);
        }

    }
}




