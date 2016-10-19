<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmInsumos_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.Insumos.FrmInsumos_Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="h1">Insumos</h1>
    <p class="lead">Formulario de Carga de Insumos</p>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group">
                    <label class="col-md-3 control-label">Nombre del Insumo</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNombreInsumo" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Medida</label>
                    <div class="col-xs-2">
                        <asp:DropDownList ID="ddlMedidas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div style="text-align:center;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuardar_Click" />
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
