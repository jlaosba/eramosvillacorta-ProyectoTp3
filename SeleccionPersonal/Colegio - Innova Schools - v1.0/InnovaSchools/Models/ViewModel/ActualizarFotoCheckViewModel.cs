using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InnovaSchools.Util;

namespace InnovaSchools.Models
{
    public class ActualizarFotoCheckViewModel
    {
        [Display(Name = "Fecha Inicio Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_inicio { get; set; }

        [Display(Name = "Fecha Cese Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_fin { get; set; }

        [Display(Name = "Nro Contrato")]
        public string nroContrato { get; set; }

        [Display(Name = "Documento Identidad")]
        public string documentoIdentidad { get; set; }
        
        [Display(Name = "Nombre Empleado")]
        public string nombre { get; set; }

        [Display(Name = "Ape. Paterno Empleado")]
        public string apellido_paterno { get; set; }

        [Display(Name = "Ape. Materno Empleado")]
        public string apellido_materno { get; set; }


        public string resultadoFind { get; set; }

        //public Empleado Empleado { get; set; }
        //public List<Empleado> Empleados { get; set; }

        public Contrato Contrato { get; set; }
        public List<Contrato> Contratos { get; set; }

        //public Persona Persona { get; set; }
        //public List<Persona> Personas { get; set; }

        public List<TipoDocumento> TipoDocumentoList { get; set; }
        [Display(Name = "Tipo Documento")]
        public int SelectedTipoDocumentoId { get; set; }
        public IEnumerable<SelectListItem> TipoDocumentos
        {
            get { return new SelectList(TipoDocumentoList, "idTipoDocumento", "descripcionDocumento"); }
        }

        public List<Puesto> PuestoList { get; set; }
        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "idPuesto", "descripcionPuesto"); }
        }
    }
}