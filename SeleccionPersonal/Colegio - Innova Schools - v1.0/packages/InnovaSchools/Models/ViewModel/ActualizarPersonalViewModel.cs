using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using InnovaSchools.Util;

namespace InnovaSchools.Models
{
    public class ActualizarPersonalViewModel
    {
        public string resultadoFind { get; set; }

        public Contrato Contrato { get; set; }
        public List<Contrato> Contratos { get; set; }

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

        public List<NivelEstudio> NivelEstudioList { get; set; }
        [Display(Name = "Grado")]
        public int SelectedNivelEstudioId { get; set; }
        public IEnumerable<SelectListItem> NivelEstudios
        {
            get { return new SelectList(NivelEstudioList, "idNivelEstudio", "gradoEstudio"); }
        }

        public List<FondoPensiones> FondoPensioneList { get; set; }
        [Display(Name = "Fondo de Pensiones")]
        public int SelectedFondoPensioneId { get; set; }
        public IEnumerable<SelectListItem> FondoPensiones
        {
            get { return new SelectList(FondoPensioneList, "idFondoPensiones", "fondoPensiones"); }
        }

        public List<EstadoEmpleado> EstadoEmpleadoList { get; set; }
        [Display(Name = "Fondo de Pensiones")]
        public int SelectedEstadoEmpleadoId { get; set; }
        public IEnumerable<SelectListItem> EstadoEmpleados
        {
            get { return new SelectList(EstadoEmpleadoList, "idEstadoEmpleado", "estadoEmpleado"); }
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

        public List<Nacionalidad> NacionalidadList { get; set; }
        [Display(Name = "Nacionalidad")]
        public int SelectedNacionalidadId { get; set; }
        public IEnumerable<SelectListItem> Nacionalidads
        {
            get { return new SelectList(NacionalidadList, "idNacionalidad", "nacionalidad"); }
        }

        public List<EstadoCivil> EstadoCivilList { get; set; }
        [Display(Name = "Estado Civil")]
        public int SelectedEstadoCivilId { get; set; }
        public IEnumerable<SelectListItem> EstadoCivils
        {
            get { return new SelectList(EstadoCivilList, "idEstadoCivil", "estadoCivil"); }
        }
    }
}