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
        [Display(Name = "Fecha Inicio Convocatoria")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin Convocatoria")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_fin { get; set; }

        public int id_persona { get; set; }

        [Display(Name = "DNI")]
        public string dni { get; set; }
        
        [Display(Name = "Nombre Candidato")]
        public string nombre { get; set; }
        
        [Display(Name = "Ape. Paterno Candidato")]
        public string apellido_paterno { get; set; }
        
        [Display(Name = "Ape. Materno Candidato")]
        public string apellido_materno { get; set; }

        //[Display(Name = "Estado")]
        //public string EstadoVerificacionDocumento { get; set; }
        public EstadoVerificacionDocumento EstadoVerificacionDocumento { get; set; }


        public string resultadoFind { get; set; }


        public Convocatoria Convocatoria { get; set; }
        public List<Convocatoria> Convocatorias { get; set; }

        public List<TipoDocumento> TipoDocumentoList { get; set; }
        [Display(Name = "Tipo Documento")]
        public int SelectedTipoDocumentoId { get; set; }
        public IEnumerable<SelectListItem> TipoDocumentos
        {
            get { return new SelectList(TipoDocumentoList, "idTipoDocumento", "descripcionDocumento"); }
        }

        public List<TipoPuesto> TipoPuestoList { get; set; }
        [Display(Name = "Tipo Puesto")]
        public int SelectedTipoPuestoId { get; set; }
        public IEnumerable<SelectListItem> TipoPuestos
        {
            get { return new SelectList(TipoPuestoList, "idTipoPuesto", "descripcionPuesto"); }
        }

        public List<Puesto> PuestoList { get; set; }
        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "idPuesto", "descripcionPuesto"); }
        }

        public List<Area> AreaList { get; set; }
        [Display(Name = "Área")]
        public int SelectedAreaId { get; set; }
        public IEnumerable<SelectListItem> Areas
        {
            get { return new SelectList(AreaList, "idArea", "descripcionArea"); }
        }

        public List<Desarrollo> DesarrolloList { get; set; }
        [Display(Name = "Desarrollo")]
        public int SelectedDesarrolloId { get; set; }
        public IEnumerable<SelectListItem> Desarrollos
        {
            get { return new SelectList(DesarrolloList, "idDesarrollo", "descripcionDesarrollo"); }
        }

        public List<EstadoCandidato> EstadoCandidatoList { get; set; }
        [Display(Name = "EstadoCandidato")]
        public int SelectedEstadoCandidatoId { get; set; }
        public IEnumerable<SelectListItem> EstadoCandidato
        {
            get { return new SelectList(EstadoCandidatoList, "idEstadoCandidato", "estadoCandidato"); }
        }

    }
}