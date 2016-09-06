<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmMantenerAgenda.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmMantenerAgenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%-- Apertura de Agenda --%>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divApertura" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Aperturar Agenda Escolar</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                </div>
            </div>
            <<div class="box-content" style="display:none;">
            <!--<div class="box-content">-->
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtFApertura">Fecha de Apertura</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFApertura" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de apertura" required></asp:TextBox>
                                <asp:RangeValidator ID="rvApertura" runat="server" 
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFApertura"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de apertura debe pertenecer al año actual.</i></div>">
                                </asp:RangeValidator>
                                <asp:CompareValidator ID="cvApertura" runat="server"  
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFApertura"
                                    Operator="GreaterThanEqual"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de apertura debe ser mayor o igual a la fecha actual.</i></div>">
                                </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFCierre">Fecha de Cierre</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFCierre" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de cierre" required></asp:TextBox>
                                <asp:RangeValidator ID="rvCierre" runat="server" 
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFCierre"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de cierre debe pertenecer al año actual.</i></div>">
                                </asp:RangeValidator>
                                <asp:CompareValidator ID="cvCierre" runat="server"  
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFCierre"
                                    ControlToCompare="txtFApertura"
                                    Operator="GreaterThan"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de cierre debe ser mayor a la de fecha de apertura.</i></div>">
                                </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFInicio">Fec. de Inicio Escolar</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFInicio" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de inicio" required></asp:TextBox>
                                <asp:RangeValidator ID="rvInicio" runat="server" 
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFInicio"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de inicio del año escolar debe pertenecer al año actual.</i></div>">
                                </asp:RangeValidator>
                                <asp:CompareValidator ID="cvInicio" runat="server"  
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFInicio"
                                    ControlToCompare="txtFCierre"
                                    Operator="GreaterThan"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de inicio del año escolar debe ser mayor a la de cierre.</i></div>">
                                </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFTermino">Fec. de Término Escolar</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFTermino" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de término" required></asp:TextBox>
                                <asp:RangeValidator ID="rvTermino" runat="server" 
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFTermino"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha debe encontrarse en el año actual.</i></div>">
                                </asp:RangeValidator>
                                <asp:CompareValidator ID="cvTermino" runat="server"  
                                    ValidationGroup="AperturaValid"
                                    ControlToValidate="txtFTermino"
                                    ControlToCompare="txtFInicio"
                                    Operator="GreaterThan"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de término del año escolar debe ser mayor a la fecha de inicio del año escolar.</i></div>">
                                </asp:CompareValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnOpenApertura" runat="server" type="submit" Text="Guardar" class="btn btn-primary" ValidationGroup="AperturaValid" OnClick="btnOpenApertura_Click" />
                            <button type="reset" class="btn btn-warning">Limpiar</button>
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <%-- Agenda Escolar --%>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Agenda Escolar</h2>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="ddlAnio">Año de Agenda</label>
                            <div class="controls">
                                <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFAperturaC">Fecha de Apertura</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFAperturaC" runat="server" type="text" class="input-medium uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFCierreC">Fecha de Cierre</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFCierreC" runat="server" type="text" class="input-medium uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFInicio">Fec. de Inicio Escolar</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFInicioC" runat="server" type="text" class="input-medium uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFTerminoC">Fec. de Término Escolar</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFTerminoC" runat="server" type="text" class="input-medium uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFAprobacion">Fecha de Aprobación</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFAprobacion" runat="server" type="text" class="input-medium uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtResponsable">Responsable</label>
                            <div class="controls">
                                <asp:TextBox ID="txtResponsable" runat="server" type="text" class="input-xlarge uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:GridView ID="gvCalendario" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"
                                Caption="<div>Calendarios de la Agenda</div>"
                                AutoGenerateColumns="False" OnRowDataBound="gvCalendario_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="IdCalendario" HeaderText="IdCalendario" Visible="false" />
                                    <asp:BoundField DataField="IdAgenda" HeaderText="Año" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%"/>
                                    <asp:BoundField DataField="Tipo" HeaderText="Descripción" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-CssClass="align-cen" HeaderStyle-Width="15%"/>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" class="input-xxlarge uneditable-input" style="resize:none;" MaxLength="250" TextMode="MultiLine" Rows="4" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfDescripcion" runat="server" 
                                    ValidationGroup="GenerarValid"
                                    ControlToValidate="txtDescripcion"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita ingresar un descripción.</i></div>">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnOperGenerar" runat="server" type="submit" Text="Generar" class="btn btn-primary" ValidationGroup="GenerarValid" Visible="false" OnClick="btnOperGenerar_Click" />
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <%-- Mensaje de Confirmación Apertura de Agenda --%>
    <div class="modal hide fade in" id="myModalApertura">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Aperturar Agenda</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de aperturar la agenda escolar para el año escolar vigente?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnGuardar" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
    <%-- Mensaje de Confirmación Generar de Agenda --%>
    <div class="modal hide fade in" id="myModalGenerar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h2>Generar Agenda</h2>
        </div>
        <div class="modal-body">
            <p>¿Está seguro de generar la agenda escolar para el año escolar vigente?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnGenerar" runat="server" type="submit" Text="Si" class="btn btn-primary" OnClick="btnGenerar_Click" />
            <a href="#" class="btn btn-success" data-dismiss="modal">No</a>
        </div>
    </div>
</asp:Content>