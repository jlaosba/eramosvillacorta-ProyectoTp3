using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InnovaSchool.Entity;
using InnovaSchool.BL;
using InnovaSchool.UserLayer.Common;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmActualizarFeriados : System.Web.UI.Page
    {
        BAgenda BAgenda = new BAgenda();
        BFeriado bFeriado = new BFeriado();
        BParametro BParametro = new BParametro();
        Resources.Resources objResources = new Resources.Resources();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {         
                CargarAniosAgenda();
                IniciarValidacion();
            }
        }
        private void CargarAniosAgenda()
        {
            List<EAgenda> ListEagenda;
            ListEagenda = BAgenda.AniosAgenda();
            ddlAnio.DataSource = ListEagenda;
            ddlAnio.DataTextField = "IdAgenda";
            ddlAnio.DataValueField = "IdAgenda";
            ddlAnio.DataBind();
            ddlAnio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Años", "0"));
        }

        private void IniciarValidacion()
        {
            var FecIniAnio = "01/01/" + DateTime.Today.Year.ToString();
            var FecFinAnio = "31/12/" + DateTime.Today.Year.ToString();
            var FecActual = DateTime.Today.ToShortDateString();
           /* rvApertura.MinimumValue = FecIniAnio.ToString();
            rvApertura.MaximumValue = FecFinAnio.ToString();
            rvCierre.MinimumValue = FecIniAnio.ToString();
            rvCierre.MaximumValue = FecFinAnio.ToString();
            rvInicio.MinimumValue = FecIniAnio.ToString();
            rvInicio.MaximumValue = FecFinAnio.ToString();
            rvTermino.MinimumValue = FecIniAnio.ToString();
            rvTermino.MaximumValue = FecFinAnio.ToString();
            cvApertura.ValueToCompare = FecActual.ToString();*/
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedValue != "0")
            {
                EFeriado eFeriado = new EFeriado();
                eFeriado.IdAgenda = ddlAnio.SelectedValue;
                eFeriado = bFeriado.ConsultarFeriado(eFeriado);
                if (eFeriado != null)
                {
                    txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", eFeriado.FechaInicio);
                    txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", eFeriado.FechaTermino);
                    txtAnioEscolarVigente.Text = eFeriado.IdAgenda;
                    txtDescripcion.Text = eFeriado.Motivo;
                }

                List<EFeriado> ListECalendario;
                ListECalendario = bFeriado.ConsultarFeriadoLista(eFeriado);
                gvConsultaFeriados.DataSource = ListECalendario;
                gvConsultaFeriados.DataBind();
            }
            else
            {
                objResources.LimpiarControles(this.Controls);                
                txtDescripcion.CssClass = "input-xxlarge uneditable-input";
            }
        }
    }
}