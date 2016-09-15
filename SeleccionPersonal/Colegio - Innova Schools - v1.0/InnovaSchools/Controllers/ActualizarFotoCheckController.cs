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
            //ProgramarPersonal.TurnoList = (from entry in _db.Turno orderby entry.id_turno ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.PuestoList = (from entry in _db.Puesto orderby entry.idPuesto ascending select entry).Take(20).ToList();
            ActualizarFotoCheck.Persona = new Persona();
            ActualizarFotoCheck.Personas = new List<Persona>();
            return View(ActualizarFotoCheck);
        }

    }
}
