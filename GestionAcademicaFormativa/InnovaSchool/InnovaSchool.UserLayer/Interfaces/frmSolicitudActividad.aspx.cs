using InnovaSchool.BL;
using InnovaSchool.Entity;
using InnovaSchool.UserLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnovaSchool.UserLayer.Interfaces
{
    public partial class frmSolicitudActividad : System.Web.UI.Page
    {
        BPersona BPersona = new BPersona();
        BAgenda BAgenda = new BAgenda();
        Resources.Resources objResources = new Resources.Resources();
        BParametro BParametro = new BParametro();
        BAmbiente BAmbiente = new BAmbiente();
        BSolicitudActividad BSolicitudActividad = new BSolicitudActividad();
        BActividad BActividad = new BActividad();
        BFeriado BFeriado = new BFeriado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IniciarValidacion();                                    
            }
        }

        private void CargarAlcance()
        {
            ddlAlcance.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroAlcance));
            ddlAlcance.DataValueField = "ValTextual";
            ddlAlcance.DataTextField = "Descripcion";
            ddlAlcance.DataBind();
            ddlAlcance.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
        }

        private void CargarTipoActividad()
        {
            ddlActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividad));
            ddlActividad.DataValueField = "ValTextual";
            ddlActividad.DataTextField = "Descripcion";
            ddlActividad.DataBind();
            ddlActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
            ddlTipoActividad.Enabled = false;
        }

        protected void ddlActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTipoActividad = ddlActividad.SelectedValue;
            if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioAcademico))
            {
                CargarTipoActividadAcademica();
                ddlTipoActividad.Enabled = true;
            }
            else if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioExtracurricular))
            {
                CargarTipoActividadExtracurricular();
                ddlTipoActividad.Enabled = true;
            }
            else
            { 
                ddlTipoActividad.Enabled = false;
                ddlTipoActividad.Items.Clear();
                ddlTipoActividad.DataBind();
            }
        }

        private void CargarTipoActividadAcademica()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadAcademica));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));               
        }

        private void CargarTipoActividadExtracurricular()
        {
            ddlTipoActividad.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroTipoActividadExtracurricular));
            ddlTipoActividad.DataValueField = "ValNumerico";
            ddlTipoActividad.DataTextField = "Descripcion";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));            
        }

        private void IniciarValidacion()
        {

            EAgenda EAgenda = new EAgenda();
            EAgenda.IdAgenda = DateTime.Now.Year.ToString();
            var FecIniAnio = string.Empty;
            var FecFinAnio = string.Empty;

            EAgenda = BAgenda.ConsultarAgenda(EAgenda);
            if (EAgenda != null)
            {
                FecIniAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecIniEscolar);
                FecFinAnio = string.Format("{0:dd/MM/yyyy}", EAgenda.FecFinEscolar);

                if (EAgenda.Estado == int.Parse(Constant.ParametroAgendaEstadoVigente))
                {
                    CargarTipoActividad();
                    CargarResponsable();
                    CargarAlcance();
                    CargarAnioEscolar();                      
                }
                else
                {                    
                    lblTituloMensaje.Text = Constant.TituloNoAgendaAprobada;
                    lblDescripcionMensaje.Text = Constant.MensajeNoAgendaAprobada;
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>"); 
                    divSolicitudActividades.Visible = false;                    
                }                                
            }
            else
            {
                FecIniAnio = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                FecFinAnio = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                
                lblTituloMensaje.Text = Constant.TituloNoAgendaAperturada;
                lblDescripcionMensaje.Text = Constant.MensajeNoAgendaAperturada;
                ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>"); 
                divSolicitudActividades.Visible = false;                
            }

            rvFechaInicio.MinimumValue = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            rvFechaInicio.MaximumValue = FecFinAnio.ToString();
            rvFechaFin.MinimumValue = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            rvFechaFin.MaximumValue = FecFinAnio.ToString();           
        }

        protected void gvDetalleSolicitudActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlUbicacion = (e.Row.FindControl("ddlUbicacion") as DropDownList);
                ddlUbicacion.DataSource = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroUbicacion));
                ddlUbicacion.DataValueField = "ValTextual";
                ddlUbicacion.DataTextField = "Descripcion";
                ddlUbicacion.DataBind();
                ddlUbicacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));

                List<EParametro> lstHora = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroHora));
                List<EParametro> lstMinuto = BParametro.ConsultarParametrosLista(Convert.ToInt32(Constant.ParametroMinuto));

                DropDownList ddlHoraInicio = (e.Row.FindControl("ddlHoraInicio") as DropDownList);
                ddlHoraInicio.DataSource = lstHora;
                ddlHoraInicio.DataValueField = "ValNumerico";
                ddlHoraInicio.DataTextField = "Descripcion";
                ddlHoraInicio.DataBind();
                ddlHoraInicio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "0"));

                DropDownList ddlMinutoInicio = (e.Row.FindControl("ddlMinutoInicio") as DropDownList);
                ddlMinutoInicio.DataSource = lstMinuto;
                ddlMinutoInicio.DataValueField = "ValNumerico";
                ddlMinutoInicio.DataTextField = "Descripcion";
                ddlMinutoInicio.DataBind();
                ddlMinutoInicio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "-1"));

                DropDownList ddlHoraFin = (e.Row.FindControl("ddlHoraFin") as DropDownList);
                ddlHoraFin.DataSource = lstHora;
                ddlHoraFin.DataValueField = "ValNumerico";
                ddlHoraFin.DataTextField = "Descripcion";
                ddlHoraFin.DataBind();
                ddlHoraFin.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "0"));

                DropDownList ddlMinutoFin = (e.Row.FindControl("ddlMinutoFin") as DropDownList);
                ddlMinutoFin.DataSource = lstMinuto;
                ddlMinutoFin.DataValueField = "ValNumerico";
                ddlMinutoFin.DataTextField = "Descripcion";
                ddlMinutoFin.DataBind();
                ddlMinutoFin.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--", "-1"));

                if(!hfIdSolicitudActividad.Value.Equals(string.Empty))
                {
                    DateTime dtHoraInicial = Convert.ToDateTime((e.Row.FindControl("lblHoraInicial") as Label).Text);
                    string strHoraInicial = dtHoraInicial.ToString("HH:mm");
                    ddlHoraInicio.SelectedIndex = ddlHoraInicio.Items.IndexOf(ddlHoraInicio.Items.FindByText(strHoraInicial.Split(':')[0]));                    
                    ddlMinutoInicio.SelectedIndex = ddlMinutoInicio.Items.IndexOf(ddlMinutoInicio.Items.FindByText(strHoraInicial.Split(':')[1]));

                    DateTime dtHoraTermino = Convert.ToDateTime((e.Row.FindControl("lblHoraTermino") as Label).Text);
                    string strHoraTermino = dtHoraTermino.ToString("HH:mm");
                    ddlHoraFin.SelectedIndex = ddlHoraFin.Items.IndexOf(ddlHoraFin.Items.FindByText(strHoraTermino.Split(':')[0]));
                    ddlMinutoFin.SelectedIndex = ddlMinutoFin.Items.IndexOf(ddlMinutoFin.Items.FindByText(strHoraTermino.Split(':')[1]));

                    string strDireccion = (e.Row.FindControl("lblDireccion") as Label).Text;
                    string IdAmbiente = (e.Row.FindControl("lblIdAmbiente") as Label).Text;
                    DropDownList ddlAmbiente = (e.Row.FindControl("ddlAmbiente") as DropDownList);
                    TextBox txtDirecion = (e.Row.FindControl("txtDireccion") as TextBox);
                    
                    if (!strDireccion.Equals(string.Empty))
                    {
                        ddlUbicacion.SelectedIndex = 2;
                        txtDirecion.Text = strDireccion;
                        txtDirecion.Visible = true;
                        ddlAmbiente.Visible = false;
                    }
                    else
                    {
                        ddlUbicacion.SelectedIndex = 1;
                        ddlAmbiente.DataSource = BAmbiente.ListarAmbientes();
                        ddlAmbiente.DataValueField = "IDAmbiente";
                        ddlAmbiente.DataTextField = "Nombre";
                        ddlAmbiente.DataBind();
                        ddlAmbiente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));
                        ddlAmbiente.SelectedIndex = ddlAmbiente.Items.IndexOf(ddlAmbiente.Items.FindByValue(IdAmbiente));
                        txtDirecion.Visible = false;
                        ddlAmbiente.Visible = true;
                    }                     
                }
            }            
        }

        protected void ddlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlUbicacion = (DropDownList)sender;
            string strUbicacion = ddlUbicacion.SelectedValue;

            GridViewRow gvrUbicacion = ((GridViewRow)ddlUbicacion.Parent.Parent);
            DropDownList ddlAmbiente = (DropDownList)gvrUbicacion.FindControl("ddlAmbiente");
            TextBox txtDireccion = (TextBox)gvrUbicacion.FindControl("txtDireccion");           

            if(strUbicacion.Equals(Constant.ParametroUbicacionInterna))
            {
                ddlAmbiente.DataSource = BAmbiente.ListarAmbientes();
                ddlAmbiente.DataValueField = "IDAmbiente";
                ddlAmbiente.DataTextField = "Nombre";
                ddlAmbiente.DataBind();
                ddlAmbiente.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Selecionar", "0"));          
                ddlAmbiente.Visible = true;
                txtDireccion.Visible = false;                
            }
            else if (strUbicacion.Equals(Constant.ParametroUbicacionExterna))
            {
                ddlAmbiente.Visible = false;                
                txtDireccion.Visible = true;
                txtDireccion.Text = string.Empty;
            }
            else
            {
                ddlAmbiente.Visible = false;
                txtDireccion.Visible = false;
            }
        }

        protected void gvDetalleSolicitudActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {                     
        }

        protected void gvConsultaSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            
            if (e.Row.Cells[6].Text == "A")
                e.Row.Cells[7].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividadAcademica), int.Parse(e.Row.Cells[7].Text), null);
            else if (e.Row.Cells[6].Text == "E")
                e.Row.Cells[7].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividadExtracurricular), int.Parse(e.Row.Cells[7].Text), null);

            e.Row.Cells[6].Text = BParametro.ConsultarParametro(int.Parse(Constant.ParametroTipoActividad), 0, e.Row.Cells[6].Text);

            LinkButton lnkEditar = ((LinkButton)e.Row.FindControl("lbtEditar"));
            if (e.Row.Cells[12].Text == "1")
            {
                e.Row.Cells[12].Text = "Borrador";
                e.Row.Cells[12].CssClass = "label label-warning estado";
                lnkEditar.Visible = true;                
            }
            else
            {
                e.Row.Cells[12].Text = "Pendiente de aprobación";
                e.Row.Cells[12].CssClass = "label label-success estado";
                lnkEditar.Visible = false; 
            }
        }

        protected void gvConsultaSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex;
            EActividad EActividad = new EActividad();
            ESolicitudActividad ESolicitudActividad = new ESolicitudActividad();

            switch (e.CommandName)
            {
                case "Editar":
                    btnEnviar.Visible = true;
                    rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    GridViewRow gvr = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent));
                  
                    ESolicitudActividad.IdSolicitudActividad = int.Parse(gvConsultaSolicitudes.DataKeys[rowIndex][0].ToString());
                    hfIdSolicitudActividad.Value = ESolicitudActividad.IdSolicitudActividad.ToString();
                    EActividad.IdActividad = int.Parse(((Label)gvr.FindControl("lblIdActividad")).Text);
                    txtNombreActividad.Text = gvConsultaSolicitudes.Rows[rowIndex].Cells[5].Text;                  
                    ddlActividad.SelectedIndex = ddlActividad.Items.IndexOf(ddlActividad.Items.FindByText(gvConsultaSolicitudes.Rows[rowIndex].Cells[6].Text));

                    string strTipoActividad = gvConsultaSolicitudes.Rows[rowIndex].Cells[6].Text.Substring(0,1);
                    if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioAcademico))
                    {
                        CargarTipoActividadAcademica();
                        ddlTipoActividad.Enabled = true;
                    }
                    else if (strTipoActividad.Equals(Constant.ParametroTipoCalendarioExtracurricular))
                    {
                        CargarTipoActividadExtracurricular();
                        ddlTipoActividad.Enabled = true;
                    }
                    else
                    { 
                        ddlTipoActividad.Enabled = false;
                        ddlTipoActividad.Items.Clear();
                        ddlTipoActividad.DataBind();
                    }

                    ddlTipoActividad.SelectedIndex = ddlTipoActividad.Items.IndexOf(ddlTipoActividad.Items.FindByText(gvConsultaSolicitudes.Rows[rowIndex].Cells[7].Text));
                    txtDescripcion.Text = ((Label)gvr.FindControl("lblDescripcion")).Text;
                    txtMotivo.Text = gvConsultaSolicitudes.DataKeys[rowIndex][1].ToString();                                                           
                    ddlResponsable.SelectedIndex = ddlResponsable.Items.IndexOf(ddlResponsable.Items.FindByText(gvConsultaSolicitudes.Rows[rowIndex].Cells[8].Text));
                    ddlAlcance.SelectedIndex = ddlAlcance.Items.IndexOf(ddlAlcance.Items.FindByValue(((Label)gvr.FindControl("lblAlcance")).Text));
                    txtFechaInicio.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaSolicitudes.Rows[rowIndex].Cells[9].Text);      
                    txtFechaFin.Text = string.Format("{0:dd/MM/yyyy}", gvConsultaSolicitudes.Rows[rowIndex].Cells[10].Text);

                    gvDetalleSolicitudActividad.DataSource = BActividad.ConsultarDetalleActividad(EActividad);                    
                    gvDetalleSolicitudActividad.DataBind();                    

                    /*EActividad = BActividad.ConsultarActividadCalendario(EActividad);
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
                    }*/
                    break;
                case "Eliminar":
                    /*rowIndex = (((GridViewRow)((TableCell)((LinkButton)e.CommandSource).Parent).Parent)).RowIndex;
                    EActividad.IdActividad = (int)gvActividades.DataKeys[rowIndex][0];
                    hdfActividad.Value = EActividad.IdActividad.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEliminar').modal('show');</script>");*/
                    break;
            }
        }


        protected void btnIngresarHoras_Click(object sender, EventArgs e)
        {   
            List<EDetalleActividad> lstDetalleActividad = new List<EDetalleActividad>();            
            DateTime dtFechaFin = Convert.ToDateTime(txtFechaFin.Text);
            DateTime dtFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            hfIdSolicitudActividad.Value = string.Empty;

            for (DateTime dt = dtFechaInicio; dt <= dtFechaFin; dt = dt.AddDays(1))
            {
                EDetalleActividad EDetalleActividad = new EDetalleActividad();
                EDetalleActividad.Fecha = dt;
                lstDetalleActividad.Add(EDetalleActividad);
            }

            gvDetalleSolicitudActividad.DataSource = lstDetalleActividad;
            gvDetalleSolicitudActividad.DataBind();            
        }        
                
        protected void ddlTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAlcance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EAgenda EAgenda = new EAgenda();
                EAgenda.IdAgenda = ddlAnio.SelectedValue;
                EUsuario EUsuario = (EUsuario)Session["Usuario"];

                List<ESolicitudActividad> lstSolicitudes = BSolicitudActividad.ListarSolicitudesAgenda(EAgenda, EUsuario);
                gvConsultaSolicitudes.DataSource = lstSolicitudes;
                gvConsultaSolicitudes.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }

            /*retval.Columns.Add("IdSolicitudActividad", typeof(int));
            retval.Columns.Add("IdActividad", typeof(int));
            retval.Columns.Add("Nombre", typeof(string));
            retval.Columns.Add("Actividad", typeof(string));
            retval.Columns.Add("TipoActividad", typeof(string));
            retval.Columns.Add("FechaInicio", typeof(DateTime));
            retval.Columns.Add("FechaFin", typeof(DateTime));
            retval.Columns.Add("IdPersona", typeof(string));
            retval.Columns.Add("Responsable", typeof(string));
            retval.Columns.Add("Motivo", typeof(string));
            retval.Columns.Add("Estado", typeof(DateTime));*/


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

        private void CargarAnioEscolar()
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
                EActividad EActividad = new EActividad
                {
                    Nombre = txtNombreActividad.Text,                    
                    Descripcion = txtDescripcion.Text,
                    IdPersona = int.Parse(ddlResponsable.SelectedValue),
                    Alcance = ddlAlcance.SelectedValue,
                    FecInicio = objResources.GetDateFromTextBox(txtFechaInicio),
                    Tipo = int.Parse(ddlTipoActividad.SelectedValue),
                    FecTermino = objResources.GetDateFromTextBox(txtFechaFin)
                };

                EFeriado EFeriado = new EFeriado();
                EFeriado = BFeriado.VerificarFeriado(EActividad);                
                if (EFeriado != null)
                {
                    string Feriado = " " + string.Format("{0:dd/MM/yyyy}", EFeriado.Fecha) + " - " + EFeriado.Motivo.ToString();                   
                    lblTituloMensaje.Text = Constant.TituloActividadFeriado;
                    lblDescripcionMensaje.Text = Constant.MensajeActividadFeriado;
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");   
                    gvDetalleSolicitudActividad.DataSource = new List<EDetalleActividad>();
                    gvDetalleSolicitudActividad.DataBind();
                }
                else
                {
                    int IdSolicitud = 0;
                    if (!hfIdSolicitudActividad.Value.Equals(string.Empty))
                        IdSolicitud = int.Parse(hfIdSolicitudActividad.Value);

                    ESolicitudActividad ESolicitudActividad = new ESolicitudActividad
                    {
                        IdSolicitudActividad = IdSolicitud,
                        Motivo = txtMotivo.Text
                    };

                    ECalendario ECalendario = new ECalendario
                    {
                        IdAgenda = DateTime.Today.Year.ToString(),
                        Tipo = ddlActividad.SelectedValue
                    };

                    EUsuario EUsuario = (EUsuario)Session["Usuario"];

                    List<EDetalleActividad> lstDetalleActividad = new List<EDetalleActividad>();
                    foreach (GridViewRow gvr in gvDetalleSolicitudActividad.Rows)
                    {
                        DateTime dtFecha = Convert.ToDateTime(gvr.Cells[0].Text);
                        DropDownList ddlHoraInicio = (gvr.FindControl("ddlHoraInicio") as DropDownList);
                        DropDownList ddlMinutoInicio = (gvr.FindControl("ddlMinutoInicio") as DropDownList);
                        DropDownList ddlHoraFin = (gvr.FindControl("ddlHoraFin") as DropDownList);
                        DropDownList ddlMinutoFin = (gvr.FindControl("ddlMinutoFin") as DropDownList);
                        DropDownList ddlUbicacion = gvr.FindControl("ddlUbicacion") as DropDownList;
                        DropDownList ddlAlmbiente = gvr.FindControl("ddlAmbiente") as DropDownList;
                        string strIdDetalleActividad = (gvr.FindControl("lblIdDetalleActividad") as Label).Text;
                        int IdDetalleActividad = 0;
                        if (!strIdDetalleActividad.Equals(string.Empty))
                            IdDetalleActividad = int.Parse(strIdDetalleActividad);
                        EDetalleActividad EDetalleActividad = new EDetalleActividad
                        {
                            IdDetalleActividad = IdDetalleActividad,
                            Fecha = dtFecha,
                            HoraInicial = new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day, int.Parse(ddlHoraInicio.SelectedValue), int.Parse(ddlMinutoInicio.SelectedValue), 0),
                            HoraTermino = new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day, int.Parse(ddlHoraFin.SelectedValue), int.Parse(ddlMinutoFin.SelectedValue), 0),
                            IdAmbiente = (ddlUbicacion.SelectedIndex == 1 ? int.Parse(ddlAlmbiente.SelectedValue) : 0),
                            Direccion = (ddlUbicacion.SelectedIndex == 2 ? ((gvr.FindControl("txtDireccion") as TextBox).Text) : string.Empty),
                        };

                        lstDetalleActividad.Add(EDetalleActividad);
                    }

                    EActividad.ListaDetalleActividad = lstDetalleActividad;
                    ESolicitudActividad.EActividad = EActividad;

                    int IdSolicitudActividad = 0;
                    int retval = 0;
                    retval = BSolicitudActividad.RegistrarSolicitudActividad(ESolicitudActividad, EUsuario, ECalendario, ref IdSolicitudActividad);

                    if (retval == 0)
                    {                     
                        lblTituloMensaje.Text = Constant.TituloGuardarSolicitud;
                        lblDescripcionMensaje.Text = Constant.MensajeErrorGuardarSolicitud;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    }
                    else
                    {
                        hfIdSolicitudActividad.Value = IdSolicitudActividad.ToString();
                        lblTituloMensaje.Text = Constant.TituloGuardarSolicitud;
                        lblDescripcionMensaje.Text = Constant.MensajeGuardarSolicitud;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");                       
                        btnEnviar.Visible = true;
                        /*Se comenta porque ahora el guardar y enviar trabajarán por separado    
                        Limpiar();
                        lblMensajeConfirmacionEnviar.Text = Constant.MensajeGuardarSolicitud;
                        ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalEnviar').modal('show');</script>");*/
                    }
                }                
            }
            
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            }            
        }

        protected void btnConfirmarEnviarAprobar_Click(object sender, EventArgs e)
        {            
            try
            {
                ESolicitudActividad ESolicitudActividad = new ESolicitudActividad
                {
                    IdSolicitudActividad = int.Parse(hfIdSolicitudActividad.Value)
                };

                int retval = 0;
                retval = BSolicitudActividad.EnviarSolicitudActividad(ESolicitudActividad);

                if (retval != 1)
                {                 
                    lblTituloMensaje.Text = Constant.TituloEnviarSolicitud;
                    lblDescripcionMensaje.Text = Constant.MensajeErrorEnviarSolicitud;
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");    
                }
                else
                {                    
                    lblTituloMensaje.Text = Constant.TituloEnviarSolicitud;
                    lblDescripcionMensaje.Text = Constant.MensajeEnviarSolicitud;
                    ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalMensaje').modal('show');</script>");
                    EnviarCorreo();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error/NoAccess.html");
            } 
        }       
 
        private void EnviarCorreo()
        {
            if (Constant.FlagCorreo.Equals("1"))
            {
                var fromAddress = new MailAddress(Constant.CorreoAprobacion, "InnovaSchools");
                var toAddress = new MailAddress(Constant.CorreoAprobacion, "Coordinador Académico");
                string fromPassword = Constant.PasswordAprobacion;
                string subject = "Solicitud de Actividad: " + txtNombreActividad.Text;
                string body = txtDescripcion.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            lblMensajeConfirmacionEnviar.Text = Constant.MensajeConfirmarEnviarSolicitud;
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "<script>$('#myModalConfirmarEnviar').modal('show');</script>");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();            
        }

        private void Limpiar()
        {
            objResources.LimpiarControles(this.Controls);
            ddlTipoActividad.Items.Clear();
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Enabled = false;
            btnEnviar.Visible = false;
        }
    }
}