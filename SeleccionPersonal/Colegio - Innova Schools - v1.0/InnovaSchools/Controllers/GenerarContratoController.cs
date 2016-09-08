using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnovaSchools.Models;

namespace InnovaSchools.Controllers
{
    public class GenerarContratoController : Controller
    {
        private InnovaSchoolsContext _db = new InnovaSchoolsContext();

        // <summary>
        // Permite generar el contrato del candidato y/o empleado
        // </summary>
        // <returns>Fecha Creacion      : 29/08/0216 | M. MAURICIO</remarks>
        // <remarks>Fecha Modificacion  : 29/08/0216 | M. MAURICIO</remarks>
        public ActionResult index()
        {
            GenerarContratoViewModel GenerarContrato = new GenerarContratoViewModel();
            GenerarContrato.Persona = new Persona();
            GenerarContrato.Personas = new List<Persona>();
            return View(GenerarContrato);
        }

    }
}
