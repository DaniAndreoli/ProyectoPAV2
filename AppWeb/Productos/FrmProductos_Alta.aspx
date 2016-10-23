<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmProductos_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.Productos.FrmProductos_Alta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="h1">Gestion de Productos</h1>

    <%-- Declaracion de los tabs--%>
    <ul class="nav nav-tabs" id="myTabs" data-tabs="tabs" role="tablist" style="padding-top: 40px">
        <li role="presentation" class="active">
            <a href="#carga" id="tabCarga" role="tab" data-toggle="tab" aria-controls="carga" aria-expanded="true">Formulario de Carga</a>
        </li>
        <li role="presentation" class="">
            <a href="#consulta" role="tab" id="tabConsulta" data-toggle="tab" aria-controls="consulta" aria-expanded="false">Consulta y Modificacion</a>
        </li>
    </ul>

    <%-- Declaracion del contenido de los tabs --%>
    <div class="tab-content" id="myTabContent">
        <%-- TAB CARGA --%>
        <div class="tab-pane active fade in" role="tabpanel" id="carga" aria-labelledby="tabCarga">
            <p class="lead"></p>
            <p class="text-info">A continuacion ingrese los datos necesarios para la carga de un producto</p>
            <p class="bg-danger" runat="server" id="msgError" visible="false"></p>
            <p class="bg-warning" runat="server" id="msgInfo" visible="false"></p>
            <p class="bg-success" runat="server" id="msgExito" visible="false"></p>

            <div class="form-horizontal">
                <div class="row">
                    <p class="lead"></p>
                    <div class="col-md-10">
                        <div class="form-group">
                            <label class="col-md-3 control-label">Nombre del Producto</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control" placeholder="Ingrese Nombre del Producto" ValidationGroup="IngresoDatos"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="validNombreProducto" runat="server" ErrorMessage="Campo Obligatorio" CssClass="label label-danger"
                                    ValidationGroup="IngresoDatos" ControlToValidate="txtNombreProducto"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Tipo de Producto</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlTiposProducto" runat="server" CssClass="form-control" ValidationGroup="IngresoDatos"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="validTipoProducto" runat="server" ErrorMessage="Campo Obligatorio" CssClass="label label-danger"
                                    ValidationGroup="IngresoDatos" ControlToValidate="ddlTiposProducto"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">Precio Unitario</label>
                            <div class="col-md-2">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" ValidationGroup="IngresoDatos"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="validPrecioProducto" runat="server" ErrorMessage="Campo Obligatorio" CssClass="label label-danger"
                                    ValidationGroup="IngresoDatos" ControlToValidate="txtPrecioUnitario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>

                <p class="lead">Listado de Insumos necesarios para la elaboracion del Producto</p>

                <div class="row">
                    <div class="col-md-10">
                        <asp:GridView ID="gvInsumos" runat="server" CssClass="table table-striped grilla" Width="100%" UseAccessibleHeader="true" HorizontalAlign="Center" AutoGenerateColumns="false" 
                            BorderStyle="None">
                            <Columns>
                                <asp:BoundField ItemStyle-Width="60%" DataField="n_insumo" HeaderText="Nombre" />

                                <asp:TemplateField ItemStyle-Width="5%" HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCantidad" runat="server" Width="100%" placeholder="Ingrese" style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField ItemStyle-Width="10%" DataField="n_medida" HeaderText="Medida"  />

                                <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Seleccion" ValidateRequestMode="Enabled">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAgregados" CssClass="checkbox" runat="server" ValidationGroup="IngresoDatos" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField Visible="false" DataField="id_insumo" />
                                <asp:BoundField Visible="false" DataField="id_medida" />
                            </Columns>
                        </asp:GridView>
                        <asp:CustomValidator ID="validCheckDetalles" runat="server" ErrorMessage="Seleccione al menos un Insumo" CssClass="label label-danger" 
                            ClientValidationFunction="ValidateCheckBoxList" ValidationGroup="IngresoDatos"></asp:CustomValidator>

                        <div class="form-group">
                            <div style="text-align: center;">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="IngresoDatos" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- TAB CONSULTA--%>
        <div class="tab-pane fade" role="tabpanel" id="consulta" aria-labelledby="tabConsulta">
            <p class="lead"></p>
            <div class="form-horizontal">

                <p class="lead">Listado de Productos</p>

                <div class="row">
                    <div class="col-md-10">
                        <asp:GridView ID="gvProductos" runat="server" Width="100%" CssClass="table table-striped grilla" UseAccessibleHeader="true" HorizontalAlign="Center" AutoGenerateColumns="false" BorderStyle="None"
                            OnRowCommand="gvProductos_RowCommand">

                            <Columns>
                                <asp:BoundField DataField="n_producto" HeaderText="Nombre" ItemStyle-Width="60%" />
                                <asp:BoundField DataField="precio_unitario" HeaderText="Precio" ItemStyle-Width="10" />
                                <asp:BoundField DataField="stock" HeaderText="Stock" ItemStyle-Width="10%" />

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderText="Accion">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnModificar" runat="server" CommandName="modificar" CssClass="btn btn-info"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="eliminar" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="id_producto" HeaderText="Id Producto" Visible="false" />
                                <asp:BoundField DataField="id_tipo_producto" HeaderText="Id Tipo Producto" Visible="false" />

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div><%-- Fin Tabs --%>

    <%-- Funciones JS para controlar los jQueryTabs --%>
    <script>
        //Al iniciar el documento, randerizamos los tabs y seleccionamos el primero
        jQuery(document).ready(function ($) {
            $('#myTabs').tab();
            $('#myTabs a:first').tab('show')
        });

        //Definimos el evento click en el tab para realizar el cambio de tab actual
        $('#myTabs a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        });

        //Evento que se ejecuta una vez realizado el cambio del tab
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            var target = e.target.attributes.href.value; // obtenemos el tab seleccionado
            switch (target) {
                case '#carga':
                    document.getElementById("<%= txtNombreProducto %>").focus();
                    break;
                case '#consulta':

                    break;
                default:

            }
        });
    </script>

    <script>
        //Funcion para validar que al menos un check se encuentre seleccionado
        function ValidateCheckBoxList(sender, args) {
            args.IsValid = false;

            $("#" + sender.id).parent().find("table[id$=" + sender.ControlId + "]").find(":checkbox").each(function () {
                if ($(this).attr("checked")) {
                    args.IsValid = true;
                    return;
                }
            });
        }
    </script>

</asp:Content>
