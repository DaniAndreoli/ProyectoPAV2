<%@ Page Title="Solicitud de Franquicias" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmSolicitudesFranquicia_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.SolicitudesFranquicia.FrmSolicitudesFranquicia_Alta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- <link href="../Content/lib/bootstrap/css/bootstrap.css" rel="stylesheet" /> --%>
    <%--<link href="../Content/css/cssPropios.css" rel="stylesheet" /> --%>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="h1">Formulario de Solicitud de Franquicias</h1>


    <div id="example-basic">
        <h3>Keyboard</h3>
        <section>
            <p>Try the keyboard navigation by clicking arrow left or right!</p>
        </section>
        <h3>Effects</h3>
        <section>
            <p>Wonderful transition effects.</p>
        </section>
        <h3>Pager</h3>
        <section>
            <p>The next and previous buttons help you to navigate through your content.</p>
        </section>
    </div>

    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                <div class="form-group">
                    <label class="col-md-3 control-label">Datos del Cliente</label>&nbsp;<div class="col-md-3">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Nombre</label>&nbsp;<div class="col-md-6">
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Apellido</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtApellidoCliente" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Tipo Documento</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlTiposDocumento" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Numero</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Telefono</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">E-mail</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Datos del Domicilio</label>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Localidad</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Calle</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Calle"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Numero</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNumeroDomicilio" runat="server" CssClass="form-control" placeholder="Numero del domicilio"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Barrio</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtBarrioDomicilio" runat="server" CssClass="form-control" placeholder="Barrio"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Departamento</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtDepartamentoDomicilio" runat="server" CssClass="form-control" placeholder="Departamento"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Piso</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtPisoDomicilio" runat="server" CssClass="form-control" placeholder="Piso"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div style="text-align: center;">
                        <asp:Button ID="btnEnviarSolicitud" runat="server" Text="Confirmar Solicitud" OnClick="btnEnviarSolicitud_Click" />
                        <asp:Button ID="btnCancelarSolicitud" runat="server" Text="Cancelar" />
                    </div>

                </div>

            </div>

        </div>

    </div>


</asp:Content>

