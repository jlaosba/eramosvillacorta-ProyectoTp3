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
    public partial class frmActividadesAcademicas : System.Web.UI.Page
    {
        BActividad BActividad = new BActividad();
        BPersona BPersona = new BPersona();
        BFeriado BFeriado = new BFeriado();
        BAgenda BAgenda = new BAgenda();
        BParametro BParametro = new BParametro();
        Resources.Resources objResources = new Resources.Resources();
        static int IdCalendario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarActividades();
                ValidarActividades();
                CargarResponsableBusqueda();
            }
        }

        private void IniciarValidacion()
        {
            ECalendario ECalendario = (ECalendario)Session["Calendario"];
            EAgenda EAgenda = new EAgenda()
            {
                IdAgenda = ECalendario.IdAgenda
            };
            EAgenda = BAgenda.ConsultarAgenda(EAgenda);
            var FecIniAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecIniEscolar);
            var FecFinAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecFinEscolar);
            rvInicio.MinimumValue = FecIniAnio.ToString();
            rvInicio.MaximumValue = FecFinAnio.ToString();
            rvTermino.MinimumValue = FecIniAnio.ToString();
            rvTermino.MaximumValue = FecFinAnio.ToString();
            if (ckbFTermino.Checked == false)
            {
                rvInicio.ErrorMessage = "<div><i>*La fecha de la actividad debe pertenecer al año escolar actual (" + FecIniAnio.ToString() + " - " + FecFinAnio.ToString() + ").</i></div>";
                lblFecInicio.Text = "Fecha";
            }
            else
            {
                rvInicio.ErrorMessage = "<div><i>*La fecha de inicio de la actividad debe pertenecer al año escolar actual (" + FecIniAnio.ToString() + " - " + FecFinAnio.ToString() + ").</i></div>";
                lblFecInicio.Text = "Fecha de Inicio";
            }
        }

        private void ValidarActividades()
        {
            IniciarValidacion();
            CargarResponsable();
            if (!lblAnio.Text.Equals(DateTime.Today.Year.ToString()))
            {
                gvActividades.Columns[7].Visible = false;
                divRegistroActividad.Visible = false;
                divCancelar.Visible = true;
            }
            else
            {
                lblMensajeConfirmacion.Text = "¿Está seguro de guardar la actividad académica para el año escolar vigente?";
            }
        }

        private void ActivarFechaTermino(bool marca)
        {
            lblFTermino.Visible = marca;
            txtFTermino.Visible = marca;
            rvTermino.Enabled = marca;
            cvTermino.Enabled = marca;
            divFTermino.Visible = marca;
            IniciarValidacion();
            if(marca == false)
            {
                txtFTermino.Text = "";
            }
        }

        private void CargarResponsable()
        {
            List<EPersona> ListEPersona;
            ListEPersona = BPersona.ListarPersona();
            ddlResponsable.DataSource = ListEPersona;
            ddlResponsable.DataTextField = "Nombre";
            ddlResponsable.DataValueField = "IdPersona";
            ddlResponsable.DataBind();
            ddlResponsable.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        private void CargarResponsableBusqueda()
        {
            List<EPersona> ListEPersona;
            ListEPersona = BPersona.ListarPersona();
            ddlResponsableB.DataSource = ListEPersona;
            ddlResponsableB.DataTextField = "Nombre";
            ddlResponsableB.DataValueField = "IdPersona";
            ddlResponsableB.DataBind();
            ddlResponsableB.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        private void ListarActividades()
        {
            ECalendario ECalendario = (ECalendario)Session["Calendario"];
            EActividad EActividad = new EActividad();
            IdCalendario = ECalendario.IdCalendario;
            EActividad.IdCalendario = IdCalendario;
            lblAnio.Text = ECalendario.IdAgenda;
            List<EActividad> ListEActividad;
            ListEActividad = BActividad.ListarActividadesCalendario(EActividad);
            if (ListEActividad.Count != 0)
            {
                gvActividades.DataSource = ListEActividad;
                gvActividades.DataBind();
                divConsultaActividad.Visible = true;
            }
            else
            {
                divConsultaActividad.Visible = false;
            }
        }

        protected void ckbFTermino_CheckedChanged(object sender, EventArgs e)
        {
            ActivarFechaTermino(ckbFTermino.Checked);
        }

        protected void gvActividades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                objResources.ControlPageGridView(gvActividades, e);
                BuscarActividad();
            }
            catch (Exception) { }
        }

        private void Limpiar()
        {
            objResources.LimpiarControles(this.Controls);
            ActivarFechaTermino(ckbFTermino.Checked);
            ListarActividades();
            lblMensajeConfirmacion.Text = "¿Está seguro de guardar la actividad académica para el año escolar vigente?";
            hdfActividad.Value = "0";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnOperGuardar_Click(object sender, EventArgs e)
        {
            EFeriado EFeriado;
            EActividad EActividad = new EActividad()
            {
                FecInicio = objResources.GetDateFromTextBox(txtFInicio),
                FecTermino = objResources.GetDateFromTextBox(txtFTermino)
            };
            EFeriado = BFeriado.VerificarFeriado(EActividad);
            if (EFeriado != null)
            {
                string Feriado = " " + string.Format("{0:dd/MM/yyyy}", EFeriado.Fecha) + " - " + EFeriado.Motivo.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloActividadFeriado + "','" + Constant.MensajeActividadFeriado + Feriado + "'))</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalGuardar').modal('show');</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuario EUsuario = (EUsuario)Session["Usuario"];
                EActividad EActividad = new EActividad
                {
                    IdActividad = int.Parse(hdfActividad.Value),
                    IdCalendario = IdCalendario, 
				    Nombre = txtNomActividad.Text,
                    FecInicio = objResources.GetDateFromTextBox(txtFInicio),
                    FecTermino = objResources.GetDateFromTextBox(txtFTermino),  
				    Descripcion = txtDescripcion.Text, 
				    IdPersona = int.Parse(ddlResponsable.SelectedValue), 
                };
                int result = 0;
                result = BActividad.RegistrarActividad(EActividad, EUsuario);
                if (result != 0)
                {
                    if (int.Parse(hdfActividad.Value) == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroActividad + "','" + Constant.MensajeRegistroActividadAcademica + "'))</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroActividad + "','" + Constant.MensajeEdicionActividadAcademica + "'))</script>");
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    Limpiar();
                }
                else
                {
                    if (int.Parse(hdfActividad.Value) == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroActividad + "','" + Constant.MensajeErrorRegistroActividadAcademica + "'))</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloRegistroActividad + "','" + Constant.MensajeErrorEdicionActividadAcademica + "'))</script>");
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void gvActividades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex;
                EActividad EActividad = new EActividad();
                switch (e.CommandName)
                {
                    case "Editar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        EActividad.IdActividad = (int)gvActividades.DataKeys[rowIndex][0];
                        EActividad = BActividad.ConsultarActividadCalendario(EActividad);
                        if (EActividad != null)
                        {
                            hdfActividad.Value = EActividad.IdActividad.ToString();
                            txtNomActividad.Text = EActividad.Nombre;
                            txtFInicio.Text = string.Format("{0:dd/MM/yyyy}", EActividad.FecInicio);
                            if (EActividad.FecTermino != null)
                            {
                                txtFTermino.Text = string.Format("{0:dd/MM/yyyy}", EActividad.FecTermino);
                                ckbFTermino.Checked = true;
                                ActivarFechaTermino(true);
                            }
                            else
                            {
                                txtFTermino.Text = "";
                                ckbFTermino.Checked = false;
                                ActivarFechaTermino(false);
                            }
                            txtDescripcion.Text = EActividad.Descripcion;
                            ddlResponsable.SelectedValue = EActividad.IdPersona.ToString();
                            lblMensajeConfirmacion.Text = "¿Está seguro de guardar los cambios en la actividad académica?";
                        }
                        break;
                    case "Eliminar":
                        rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                        EActividad.IdActividad = (int)gvActividades.DataKeys[rowIndex][0];
                        hdfActividad.Value = EActividad.IdActividad.ToString();
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEliminar').modal('show');</script>");
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EActividad EActividad = new EActividad()
                {
                    IdActividad = int.Parse(hdfActividad.Value)
                };
                int result = 0;
                result = BActividad.EliminarActividad(EActividad);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloEliminarActividad + "','" + Constant.MensajeEliminarActividadAcademica + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                    Limpiar();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloEliminarActividad + "','" + Constant.MensajeErrorEliminarActividadAcademica + "'))</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

        private void BuscarActividad()
        {
            ECalendario ECalendario = (ECalendario)Session["Calendario"];
            EActividad EActividad = new EActividad()
            {
                IdCalendario = ECalendario.IdCalendario,
                Nombre = txtNomActividadB.Text,
                FecInicio = objResources.GetDateFromTextBox(txtFInicioB),
                FecTermino = objResources.GetDateFromTextBox(txtFTerminoB),
                IdPersona = int.Parse(ddlResponsableB.SelectedValue)
            };
            List<EActividad> ListEActividad;
            ListEActividad = BActividad.ConsultarActividadCalendarioFiltro(EActividad);
            gvActividades.DataSource = ListEActividad;
            gvActividades.DataBind();
            if (ListEActividad.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script>$('#mensaje').html(GenerarMensaje('" + Constant.TituloNoActividadAcademica + "','" + Constant.MensajeNoActividadAcademica + "'))</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>myModalShow();</script>");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarActividad();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }
        }

    }
}