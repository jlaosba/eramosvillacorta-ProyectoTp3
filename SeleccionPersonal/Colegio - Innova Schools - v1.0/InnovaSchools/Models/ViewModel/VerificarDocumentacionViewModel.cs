using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InnovaSchools.Util;

namespace InnovaSchools.Models
{
    public class VerificarDocumentacionViewModel
    {
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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

        [Display(Name = "Estado")]
        public string EstadoVerificacionDocumento { get; set; }
        //public EstadoVerificacionDocumento EstadoVerificacionDocumento { get; set; }


        public string resultadoFind { get; set; }

        public Candidato Candidato { get; set; }
        public List<Candidato> Candidatos { get; set; }

        public List<Puesto> PuestoList { get; set; }
        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "id_puesto", "descripcion_puesto"); }
        }
    }
}