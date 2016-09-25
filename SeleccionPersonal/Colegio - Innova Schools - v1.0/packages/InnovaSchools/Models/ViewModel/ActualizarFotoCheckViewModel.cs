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
    public class ActualizarFotoCheckViewModel
    {
        [Display(Name = "Fecha Inicio Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_inicio { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Inicio Contrato")]
        public String fechaInicioPublicacionStr { get; set; }


        [Display(Name = "Fecha Cese")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha_fin { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Fin Contrato")]
        public String fechaFinPublicacionStr { get; set; }

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

        public List<DocumentoIdentidad> DocumentoIdentidadList { get; set; }
        [Display(Name = "Tipo Documento")]
        public int SelectedDocumentoIdentidadId { get; set; }
        public IEnumerable<SelectListItem> DocumentoIdentidads
        {
            get { return new SelectList(DocumentoIdentidadList, "idDocumentoIdentidad", "descripcion"); }
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

        public List<TipoContrato> TipoContratoList { get; set; }
        [Display(Name = "TipoContrato")]
        public int SelectedTipoContratoId { get; set; }
        public IEnumerable<SelectListItem> TipoContratos
        {
            get { return new SelectList(TipoContratoList, "idTipoContrato", "descripcionContrato"); }
        }

        public List<TipoContratoTiempo> TipoContratoTiempoList { get; set; }
        [Display(Name = "TipoContratoTiempo")]
        public int SelectedTipoContratoTiempoId { get; set; }
        public IEnumerable<SelectListItem> TipoContratoTiempos
        {
            get { return new SelectList(TipoContratoTiempoList, "idTipoContratoTiempo", "descripcionContratoTiempo"); }
        }

    }
}