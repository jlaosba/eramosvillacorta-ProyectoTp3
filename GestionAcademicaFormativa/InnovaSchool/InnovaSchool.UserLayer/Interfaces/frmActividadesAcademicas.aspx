<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmActividadesAcademicas.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmActividadesAcademicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%-- Actividades Académicas --%>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divApertura" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Actividades Académicas del calendario <asp:Label ID="lblAnio" runat="server" Text="lblAnio"></asp:Label></h2>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div id="divRegistroActividad" runat="server">
                            <div class="control-group">
                                <label class="control-label" for="txtNomActividad">Nombre de la actividad</label>
                                <div class="controls">
                                    <asp:HiddenField ID="hdfActividad" runat="server" Value="0" />
                                    <asp:TextBox ID="txtNomActividad" runat="server" type="text" class="input-xxlarge"
                                        title="Se necesita un nombre para la actividad" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFInicio"><asp:Label ID="lblFecInicio" runat="server" Text="Label"></asp:Label></label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFInicio" runat="server" type="text" class="input-medium datepicker"
                                        title="Se necesita una fecha de inicio" required></asp:TextBox>
                                    <asp:CheckBox ID="ckbFTermino" runat="server" CssClass="checkbox" ToolTip="Activar Fecha de Termino" AutoPostBack="true" OnCheckedChanged="ckbFTermino_CheckedChanged" />
                                    <asp:RangeValidator ID="rvInicio" runat="server" 
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="txtFInicio"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic">
                                    </asp:RangeValidator>
                                </div>
                            </div>
                            <div class="control-group" id="divFTermino" runat="server" visible="false">
                                <asp:Label ID="lblFTermino" runat="server" Text="Fecha de Término" class="control-label" for="txtFTermino" Visible="false"></asp:Label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFTermino" runat="server" type="text" class="input-medium datepicker" Visible="false"
                                        title="Se necesita una fecha de término" required></asp:TextBox>
                                    <asp:RangeValidator ID="rvTermino" runat="server" Enabled="false"
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="txtFTermino"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*La fecha de término de la actividad debe pertenecer al año actual.</i></div>">
                                    </asp:RangeValidator>
                                    <asp:CompareValidator ID="cvTermino" runat="server" Enabled="false"
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="txtFTermino"
                                        ControlToCompare="txtFInicio"
                                        Operator="GreaterThan"
                                        Type="Date"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*La fecha de término de la actividad debe ser mayor a la fecha de inicio de la actividad.</i></div>">
                                    </asp:CompareValidator>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtDescripcion">Descripción</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtDescripcion" runat="server" type="text" class="input-xxlarge" style="resize:none;" 
                                        MaxLength="500" TextMode="MultiLine" Rows="4" title="Se necesita una descripción" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="ddlResponsable">Responsable</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlResponsable" runat="server" required></asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ValidationGroup="ActividadValid"
                                        ControlToValidate="ddlResponsable"
                                        Operator="GreaterThan"
                                        ValueToCompare="0"
                                        ForeColor="Red"
                                        Font-Size="Small"
                                        Display="Dynamic"
                                        ErrorMessage="<div><i>*Se necesita un responsable para la actividad académica.</i></div>">
                                    </asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnOperGuardar" runat="server" type="submit" Text="Guardar" class="btn btn-primary" ValidationGroup="ActividadValid" OnClick="btnOperGuardar_Click" />
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" type="reset" class="btn btn-warning" UseSubmitBehavior="False" OnClick="btnLimpiar_Click"/>
                                <a href="../Interfaces/frmMantenerCalendarioAcademico.aspx" class="btn btn-success">Cancelar</a>
                            </div>
                            <div class="control-group">
                            </div>
                        </div>
                        <div id="divConsultaActividad" runat="server">
                            <div class="box-header" data-original-title="">
                                <h2><i class="halflings-icon white search"></i><span class="break"></span>Consultar Actividades Académicas</h2>
                            </div>
                            <div class="control-group">
                            </div>
                            <%-- Busqueda --%>
                            <div class="control-group">
                                <label class="control-label" for="txtNomActividadB">Nombre de la actividad</label>
                                <div class="controls">
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                    <asp:TextBox ID="txtNomActividadB" runat="server" type="text" class="input-xlarge"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFInicioB">Fecha Incial</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFInicioB" runat="server" type="text" class="input-medium datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="txtFTerminoB">Fecha de Termino</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFTerminoB" runat="server" type="text" class="input-medium datepicker"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="ddlResponsable">Responsable</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlResponsableB" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnBuscar" runat="server" type="submit" Text="Buscar" class="btn btn-info" UseSubmitBehavior="False" OnClick="btnBuscar_Click" />
                            </div>
                            <div class="control-group">
                            </div>
                        </div>
                        <%-- Lista --%>
                        <div class="control-group">
                            <asp:GridView ID="gvActividades" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                                AllowPaging="True" PageSize="8"
                                Caption="<div>Lista de Actividades Académicas</div>"
                                DataKeyNames="IdActividad"
                                AutoGenerateColumns="False" 
                                OnPageIndexChanging="gvActividades_PageIndexChanging" OnRowCommand="gvActividades_RowCommand">
                                <PagerStyle CssClass="pagination pagination-centered" />
                                <Columns>
                                    <asp:BoundField DataField="IdActividad" HeaderText="IdActividad" Visible="false" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Actividad" HeaderStyle-Width="20%" />
                                    <asp:BoundField DataField="FecInicio" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="Fecha de Inicio" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                    <asp:BoundField DataField="FecTermino" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Término" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HeaderStyle-Width="30%" />
                                    <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" Visible="false" />
                                    <asp:BoundField DataField="UsuCreacion" HeaderText="Responsable" HeaderStyle-Width="15%" />
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" >
                                            <i class="halflings-icon white edit"></i>
                                        </asp:LinkButton> 
                                        <asp:LinkButton ID="lbtEliminar" CommandName="Eliminar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Eliiminar" >
                                            <i class="halflings-icon white trash"></i>
                                        </asp:LinkButton>
                                        </ItemTemplate> 
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="form-actions" id="divCancelar" runat="server" visible="false">
                            <a href="../Interfaces/frmMantenerCalendarioAcademico.aspx" class="btn btn-success">Cancelar</a>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <%-- Mensaje de Confirmación de Registro --%>
    <div class="modal hide fade in" id="myModalGuardar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Guardar Actividad</h2>
        </div>
        <div class="modal-body">
            <p><asp:Label ID="lblMensajeConfirmacion" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnGuardar" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
    <%-- Mensaje de Confirmación de Registro --%>
    <div class="modal hide fade in" id="myModalEliminar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Eliminar Actividad</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de eliminar la actividad académica para el año actual?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnEliminar" runat="server" type="submit" Text="Si" class="btn btn-primary" UseSubmitBehavior="False"  OnClick="btnEliminar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>
