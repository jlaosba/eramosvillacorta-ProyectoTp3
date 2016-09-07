<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="frmActualizarFeriados.aspx.cs" Inherits="InnovaSchool.UserLayer.Interfaces.frmActualizarFeriados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12" id="divSolicitudActividades" runat="server">
            <div class="box-header" data-original-title="">
                <h2><i class="halflings-icon white edit"></i><span class="break"></span>Actualizar Feriados</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>                    
                </div>                
            </div>                        
            <div class="box-content">           
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtAnioEscolarVigente">Año escolar vigente:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAnioEscolarVigente" runat="server" type="text" class="input-xlarge editable-input"
                                 title="Se necesita un nombre" MaxLength="4" Enabled="false"></asp:TextBox>
                                
                            </div>
                        </div>
                        
                        <div class="control-group">
                            <label class="control-label" for="txtDescripcion">Descripción:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtDescripcion" runat="server" type="text" TextMode="MultiLine" class="input-xlarge editable-input"
                                title="Se necesita una descripción" ValidationGroup="SolicitudValid" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvDescripcion" runat="server"
                                    ValidationGroup="SolicitudValid"
                                    ControlToValidate="txtDescripcion"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una descripción</i></div>"> </asp:RequiredFieldValidator>
                            </div>
                        </div>
                                                
                        
                        
                        <div class="control-group">
                            <label class="control-label" for="txtFechaInicio">Fecha de Inicio:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaInicio" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de inicio"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server"
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaInicio"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de inicio</i></div>"> </asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvFechaInicio" runat="server" 
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaInicio"
                                    
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    MaximumValue="01/01/2100"
                                    ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>" MinimumValue="01/01/2000"></asp:RangeValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtFechaFin">Fecha de Termino:</label>
                            <div class="controls">
                                <asp:TextBox ID="txtFechaFin" runat="server" type="text" class="input-medium datepicker"
                                    title="Se necesita una fecha de fin"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server"
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*Se necesita una fecha de fin</i></div>"> </asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvFechaFin" runat="server" 
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de la actividad se encuentra fuera del rango del año escolar vigente o es menor a la actual.</i></div>"> </asp:RangeValidator>
                                <asp:CompareValidator ID="cvFechaFin" runat="server"  
                                    ValidationGroup="FechaValid"
                                    ControlToValidate="txtFechaFin"
                                    ControlToCompare="txtFechaInicio"
                                    Operator="GreaterThanEqual"
                                    Type="Date"
                                    ForeColor="Red"
                                    Font-Size="Small"
                                    Display="Dynamic"
                                    ErrorMessage="<div><i>*La fecha de fin debe ser mayor o igual a la fecha actual.</i></div>"> </asp:CompareValidator>
                                
                            </div>                                                        
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                <asp:CheckBox ID="chkRepiteCadaAnio" runat="server" Text="Repite cada año" style="margin-left: 10px;" Width="300px" />
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnGuardar" runat="server" type="submit" Text="Guardar" class="btn btn-primary"  ValidationGroup="SolicitudValid"  />
                            <asp:Button ID="btnCargarFeriado" runat="server" type="submit" Text="Cargar Feriados" class="btn btn-primary" Visible="false" />
                            <asp:Button ID="btnLimpiar" runat="server" type="submit" Text="Limpiar" class="btn btn-warning" />                            
                            <a href="../Index.aspx" class="btn btn-success">Cancelar</a>
                        </div>                      
                    </fieldset>
                </div>                 
            </div>                       
        </div>
        <div class="row-fluid sortable ui-sortable">
            <div class="box span12" id="divConsultaSolicitudes" runat="server">
                <div class="box-header" data-original-title="">
                    <h2><i class="halflings-icon white search"></i><span class="break"></span>Consulta Feriados</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-down"></i></a>
                    </div>
                </div>
                <div class="box-content">           
                    <div class="form-horizontal">
                        <fieldset>
                            <div class="control-group">
                                <label class="control-label" for="ddlAnio">Año Escolar</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                            <asp:GridView ID="gvConsultaFeriados" runat="server"
                                CssClass="table table-striped table-bordered bootstrap-datatable datatable dataTable"                                                                                             
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                
                                DataKeyNames="IdFeriado,Motivo">
                                <Columns>                                    
<asp:TemplateField Visible="False"><ItemTemplate>
                                            <asp:Label id="lblIdActividad" runat ="server" text='<%# Eval("IdFeriado")%>' />
                                        
</ItemTemplate>
</asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblDescripcion" runat ="server" text='<%# Eval("Motivo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IdFeriado" HeaderText="IdFeriado" Visible="false" >
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle CssClass="align-cen" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Motivo" HeaderText="Descripción" ItemStyle-CssClass="align-cen" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen" HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Termino" ItemStyle-CssClass="align-cen"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" >                                                                                                          
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle CssClass="align-cen"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Se repite cada año">
                                            <ItemTemplate><%# (Eval("Repetitivo").ToString() == "1") ? "Si" : "No" %></ItemTemplate>
                                            <ControlStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label id="lblMotivo" runat ="server" text='<%# Eval("Motivo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText ="Opciones" HeaderStyle-Width="15%"> 
                                        <ItemTemplate> 
                                        <asp:LinkButton ID="lbtEditar" CommandName="Editar" CssClass="btn btn-primary btn-gv" runat="server" ToolTip="Editar" >
                                            <i class="halflings-icon white edit"></i>
                                        </asp:LinkButton> 
                                        <asp:LinkButton ID="lbtEliminar" CommandName="Eliminar" CssClass="btn btn-danger btn-gv" runat="server" ToolTip="Eliminar" Visible="false">
                                            <i class="halflings-icon white trash"></i>
                                        </asp:LinkButton>
                                        </ItemTemplate> 

<HeaderStyle Width="15%"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>                                                                         
                                </Columns>
                            </asp:GridView>
                        </div>  
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
