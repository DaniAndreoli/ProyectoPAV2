<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmProductos_Modificacion.aspx.cs" Inherits="ProyectoPAV2.AppWeb.Productos.FrmProductos_Modificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="h1">Productos</h1>
    <p class="lead">Formulario de Modificacion de Productos</p>

    <div class="form-horizontal">

        <p class="lead">Listado de Productos</p>

        <div class="row">
            <div class="col-md-10">
                <asp:GridView ID="gvProductos" runat="server" CssClass="table table-hover table-striped" UseAccessibleHeader="true" HorizontalAlign="Center" AutoGenerateColumns="false" OnRowCommand="gvProductos_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="id_producto" HeaderText="Id Producto" />
                        <asp:BoundField DataField="n_producto" HeaderText="Nombre" />
                        <asp:BoundField DataField="id_tipo_producto" HeaderText="Id Tipo Producto" />
                        <asp:BoundField DataField="precio_unitario" HeaderText="Precio" />
                        <asp:BoundField DataField="stock" HeaderText="Stock" />

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderText="Accion">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModificar" runat="server" CommandName="modificar" CssClass="btn btn-info"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="eliminar" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-md-10">
                <div class="form-group">
                    <label class="col-md-3 control-label">Nombre del Producto</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control" placeholder="Nombre" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 control-label">Tipo de Producto</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlTiposProducto" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Precio Unitario</label>
                    <div class="col-md-2">
                        <div class="input-group">
                            <span class="input-group-addon">$</span>
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div style="text-align: center;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuardar_Click" Enabled="false" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" Enabled="false" />
                    </div>
                </div>
            </div>
        </div>

        <p class="lead">Listado de Insumos</p>

        <div class="row">
            <div class="col-md-10">
                <asp:GridView ID="gvInsumos" runat="server" CssClass="table table-hover table-striped" UseAccessibleHeader="true" HorizontalAlign="Center" AutoGenerateColumns="false">

                    <Columns>
                        <asp:BoundField DataField="id_insumo" HeaderText="Id Insumo" />
                        <asp:BoundField DataField="n_insumo" HeaderText="Nombre" />
                        <asp:BoundField DataField="stock" HeaderText="Stock" />

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px" HeaderText="Accion">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAprobar" runat="server" CommandName="aprobar" CssClass="btn btn-success"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnDeny" runat="server" CommandName="rechazar" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnReturn" runat="server" CommandName="modificar" CssClass="btn btn-info"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>


    </div>
</asp:Content>
