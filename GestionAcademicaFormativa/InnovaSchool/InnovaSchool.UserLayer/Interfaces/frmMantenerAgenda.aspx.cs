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
    public partial class frmMantenerAgenda : System.Web.UI.Page
    {
        BAgenda BAgenda = new BAgenda();
        BParametro BParametro = new BParametro();
        Resources.Resources objResources = new Resources.Resources();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerificarAperturaAgenda();
                CargarAniosAgenda();
                IniciarValidacion();
            }
        }

        private void VerificarAperturaAgenda()
        {
            EAgenda EAgenda;
            EAgenda = BAgenda.VerificarAperturaAgenda();
            if (EAgenda == null)
            {
                divApertura.Visible = true;
            }
            else
            {
                divApertura.Visible = false;
            }
        }

        private void IniciarValidacion()
        {
            var FecIniAnio = "01/01/" + DateTime.Today.Year.ToString();
            var FecFinAnio = "31/12/" + DateTime.Today.Year.ToString();
            var FecActual = DateTime.Today.ToShortDateString();
            rvApertura.MinimumValue = FecIniAnio.ToString();
            rvApertura.MaximumValue = FecFinAnio.ToString();
            rvCierre.MinimumValue = FecIniAnio.ToString();
            rvCierre.MaximumValue = FecFinAnio.ToString();
            rvInicio.MinimumValue = FecIniAnio.ToString();
            rvInicio.MaximumValue = FecFinAnio.ToString();
            rvTermino.MinimumValue = FecIniAnio.ToString();
            rvTermino.MaximumValue = FecFinAnio.ToString();
            cvApertura.ValueToCompare = FecActual.ToString();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuario EUsuario = (EUsuario)Session["Usuario"];
                EAgenda EAgenda = new EAgenda
                {
                    fechaApertura = objResources.GetDateFromTextBox(txtFApertura),
                    fechaCierre = objResources.GetDateFromTextBox(txtFCierre),
                    fechaInicioEscolar = objResources.GetDateFromTextBox(txtFInicio),
                    FechaTerminoEscolar = objResources.GetDateFromTextBox(txtFTermino)
                };
                int result = 0;
                result = BAgenda.RegistrarAperturaAgenda(EAgenda, EUsuario);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloApertura + "','" + Constant.MensajeAperturaAgenda + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    objResources.LimpiarControles(this.Controls);
                    CargarAniosAgenda();
                    VerificarAperturaAgenda();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloErrorApertura + "','" + Constant.MensajeErrorAperturaAgenda + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedValue != "0")
            {
                EAgenda EAgenda = new EAgenda();
                EAgenda.IdAgenda = ddlAnio.SelectedValue;
                EAgenda = BAgenda.ConsultarAgenda(EAgenda);
                if (EAgenda != null)
                {
                    txtFAperturaC.Text = string.Format("{0:dd/MM/yyyy}", EAgenda.fechaApertura);
                    txtFCierreC.Text = string.Format("{0:dd/MM/yyyy}", EAgenda.fechaCierre);
                    txtFInicioC.Text = string.Format("{0:dd/MM/yyyy}", EAgenda.fechaInicioEscolar);
                    txtFTerminoC.Text = string.Format("{0:dd/MM/yyyy}", EAgenda.FechaTerminoEscolar);
                    txtFAprobacion.Text = string.Format("{0:dd/MM/yyyy}", EAgenda.FecModificacion);
                    txtResponsable.Text = EAgenda.UsuModificación.ToString();
                    txtDescripcion.Text = EAgenda.Descripcion.ToString();
                }
                ECalendario ECalendario = new ECalendario();
                ECalendario.IdAgenda = ddlAnio.SelectedValue;
                BCalendario BCalendario = new BCalendario();
                List<ECalendario> ListECalendario;
                ListECalendario = BCalendario.ConsultarCalendariosAgenda(ECalendario);
                gvCalendario.DataSource = ListECalendario;
                gvCalendario.DataBind();
                if (ListECalendario.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloCalendarioAgenda + "','" + Constant.MensajeCalendarioAgenda + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
                if (ListECalendario.Count == 2)
                {
                    if (gvCalendario.Rows[0].Cells[3].Text == Constant.ParametroCalendarioAprobado && gvCalendario.Rows[1].Cells[3].Text == Constant.ParametroCalendarioAprobado)
                    {
                        btnOperGenerar.Visible = true;
                        txtDescripcion.CssClass = "input-xxlarge ";
                    }
                    else
                    {
                        btnOperGenerar.Visible = false;
                        txtDescripcion.CssClass = "input-xxlarge uneditable-input";
                    }
                }
                else
                {
                    txtDescripcion.CssClass = "input-xxlarge uneditable-input";
                }
            }
            else
            {
                objResources.LimpiarControles(this.Controls);
                btnOperGenerar.Visible = false;
                txtDescripcion.CssClass = "input-xxlarge uneditable-input";
            }
        }

        protected void gvCalendario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            e.Row.Cells[2].Text = BParametro.ConsultarParametro(Constant.ParametroTipoCalendario, 0, e.Row.Cells[2].Text) + e.Row.Cells[1].Text;
            if (e.Row.Cells[3].Text == "4")
            {
                e.Row.Cells[3].CssClass = "label label-success estado";
            }
            else
            {
                if (e.Row.Cells[3].Text == "5")
                {
                    e.Row.Cells[3].CssClass = "label label-important estado";
                }
                else
                {
                    e.Row.Cells[3].CssClass = "label label-warning estado";
                }
            }
            e.Row.Cells[3].Text = BParametro.ConsultarParametro(Constant.ParametroEstadosCalendario, int.Parse(e.Row.Cells[3].Text), null);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                EAgenda EAgenda = new EAgenda
                {
                    IdAgenda = ddlAnio.SelectedValue.ToString(),
                    Descripcion = txtDescripcion.Text
                };
                int result = 0;
                result = BAgenda.GenerarAgenda(EAgenda);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloGenerarAgenda + "','" + Constant.MensajeGenerarAgenda + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    objResources.LimpiarControles(this.Controls);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloGenerarAgenda + "','" + Constant.MensajeErrorGenerarAgenda + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnOpenApertura_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalApertura').modal('show');</script>");
        }

        protected void btnOperGenerar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalGenerar').modal('show');</script>");
        }
    }
}