<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmSolicitudesFranquicia_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.SolicitudesFranquicia.FrmSolicitudesFranquicia_Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- <link href="../Content/lib/bootstrap/css/bootstrap.css" rel="stylesheet" /> --%>
    <link href="../Content/css/cssPropios.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">Heladerias Limar</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="#">Inicio</a></li>
            <li><a href="#about">Acerca de</a></li>
            <li><a href="#contact">Contacto</a></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav>

    <div class="container">

        <div class="starter-template">
            <p class="lead">Use this document as a way to quickly start any new project.<br>
                All you get is this text and a mostly barebones HTML document.</p>
            <asp:DropDownList ID="ddlTiposDocumento" runat="server"></asp:DropDownList>
        </div>

    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</asp:Content>
