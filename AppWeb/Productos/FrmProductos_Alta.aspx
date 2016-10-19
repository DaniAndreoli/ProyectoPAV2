<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmProductos_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.Productos.FrmProductos_Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="h1">Productos</h1>
    <p class="lead">Formulario de Carga de Productos</p>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group">
                    <label class="col-md-3 control-label">Nombre del Producto</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Tipo de Producto</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlTiposProducto" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Precio Unitario</label>
                    <div class="col-md-2">
                        <div class="input-group">
                            <span class="input-group-addon">$</span>
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div style="text-align:center;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-10">
                
            </div>
        </div>

    </div>

</asp:Content>
