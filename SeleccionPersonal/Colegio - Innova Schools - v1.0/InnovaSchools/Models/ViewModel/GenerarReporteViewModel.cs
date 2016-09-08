using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InnovaSchools.Util;

namespace InnovaSchools.Models
{
    public class GenerarReporteViewModel
    {
        [Display(Name = "Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        public DateTime fecha_fin { get; set; }

        public int id_persona { get; set; }
        [Display(Name = "DNI")]
        public string dni { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Ape. Paterno")]
        public string apellido_paterno { get; set; }
        [Display(Name = "Ape. Materno")]
        public string apellido_materno { get; set; }

        public string resultadoFind { get; set; }

        public Persona Persona { get; set; }
        public List<Persona> Personas { get; set; }

        public List<Puesto> PuestoList { get; set; }
        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "id_puesto", "descripcion_puesto"); }
        }

    }
}
