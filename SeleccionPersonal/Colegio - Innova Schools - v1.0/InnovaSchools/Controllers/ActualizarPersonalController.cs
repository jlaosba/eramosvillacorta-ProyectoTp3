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
        // <returns>Fecha Creacion      : 29/08/0216 | C. Quiroz</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | C. Quiroz</remarks>
        public ActionResult index()
        {
            ActualizarPersonalViewModel ActualizarPersonal = new ActualizarPersonalViewModel();
            //ProgramarPersonal.TurnoList = (from entry in _db.Turno orderby entry.id_turno ascending select entry).Take(20).ToList();
            ActualizarPersonal.PuestoList = (from entry in _db.Puesto orderby entry.id_puesto ascending select entry).Take(20).ToList();
            ActualizarPersonal.Persona = new Persona();
            ActualizarPersonal.Personas = new List<Persona>();
            return View(ActualizarPersonal);
        }

    }
}
