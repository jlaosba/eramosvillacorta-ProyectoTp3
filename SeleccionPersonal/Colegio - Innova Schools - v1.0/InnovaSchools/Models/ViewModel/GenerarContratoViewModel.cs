using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using InnovaSchools.Util;

namespace InnovaSchools.Models
{
    public class GenerarContratoViewModel
    {
        //public int id_persona { get; set; }

        [Display(Name = "Nro Contrato")]
        public string nroContrato { get; set; }

        [Display(Name = "Documento Identidad")]
        public string dni { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Ape. Paterno")]
        public string apellido_paterno { get; set; }

        [Display(Name = "Ape. Materno")]
        public string apellido_materno { get; set; }

        public string resultadoFind { get; set; }

        public Convocatoria Convocatoria { get; set; }
        public List<Convocatoria> Convocatorias { get; set; }

        [Display(Name = "Fecha Inicio contrat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaIngreso { get; set; }

        [Display(Name = "Fecha Fin contracto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCese { get; set; }

        [Display(Name = "Salario")]
        public decimal salario { get; set; }

        //public Candidato Candidato { get; set; }
        //public List<Candidato> Candidatos { get; set; }

        //public Contrato Contrato { get; set; }
        //public List<Contrato> Contratos { get; set; }

        public List<Puesto> PuestoList { get; set; }
        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "idPuesto", "descripcionPuesto"); }
        }

        public List<TipoContrato> TipoContratoList { get; set; }
        [Display(Name = "TipoContrato")]
        public int SelectedTipoContratoId { get; set; }
        public IEnumerable<SelectListItem> TipoContratos
        {
            get { return new SelectList(TipoContratoList, "idTipoContrato", "descripcionContrato"); }
        }
    }
}