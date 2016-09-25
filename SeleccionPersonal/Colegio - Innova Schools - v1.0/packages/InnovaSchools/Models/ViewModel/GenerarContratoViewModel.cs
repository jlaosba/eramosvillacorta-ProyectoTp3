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

        [Display(Name = "Prefijo Cuenta")]
        public string prefijoCuenta { get; set; }

        [Display(Name = "Cuenta")]
        public string cuentaBanco { get; set; }

        [Display(Name = "Estado")]
        public string estadoCandidato { get; set; }

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

        public List<DocumentoIdentidad> DocumentoIdentidadList { get; set; }
        [Display(Name = "Tipo Documento")]
        public int SelectedDocumentoIdentidadId { get; set; }
        public IEnumerable<SelectListItem> DocumentoIdentidads
        {
            get { return new SelectList(DocumentoIdentidadList, "idDocumentoIdentidad", "descripcion"); }
        }

        [Display(Name = "Puesto")]
        public int SelectedPuestoId { get; set; }
        public IEnumerable<SelectListItem> Puestos
        {
            get { return new SelectList(PuestoList, "idPuesto", "descripcionPuesto"); }
        }

        public List<TipoPuesto> TipoPuestoList { get; set; }
        [Display(Name = "Tipo Puesto")]
        public int SelectedTipoPuestoId { get; set; }
        public IEnumerable<SelectListItem> TipoPuestos
        {
            get { return new SelectList(TipoPuestoList, "idTipoPuesto", "descripcionPuesto"); }
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

        public List<NivelEstudio> NivelEstudioList { get; set; }
        [Display(Name = "Grado")]
        public int SelectedNivelEstudioId { get; set; }
        public IEnumerable<SelectListItem> NivelEstudios
        {
            get { return new SelectList(NivelEstudioList, "idNivelEstudio", "gradoEstudio"); }
        }

        public List<Seguro> SeguroList { get; set; }
        [Display(Name = "Seguro")]
        public int SelectedSeguroId { get; set; }
        public IEnumerable<SelectListItem> Seguros
        {
            get { return new SelectList(SeguroList, "idSeguro", "descripcionSeguro"); }
        }

        public List<Banco> BancoList { get; set; }
        [Display(Name = "Banco")]
        public int SelectedBancoId { get; set; }
        public IEnumerable<SelectListItem> Bancos
        {
            get { return new SelectList(BancoList, "idBanco", "nombreBanco"); }
        }
    }
}