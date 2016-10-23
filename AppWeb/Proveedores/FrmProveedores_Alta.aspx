<%@ Page Title="" Language="C#" MasterPageFile="~/AppWeb.Master" AutoEventWireup="true" CodeBehind="FrmProveedores_Alta.aspx.cs" Inherits="ProyectoPAV2.AppWeb.Proveedores.FrmProveedores_Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="h1">Proveedores</h1>
    <p class="lead">Formulario de Carga de Proveedores</p>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-10">
                
                    Cuit:<asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>
     
                
                    Nombre:<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>                    
      
                       
                             <div class="form-group">
                    <label class="col-md-3 control-label">Localidad</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="ddlLocalidades" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">                                              
                        Barrio:<asp:TextBox ID="txtBarrio" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>  
                  
                    Calle:<asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>  
                
                  Numero:<asp:TextBox ID="txtNumeroCalle" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>  
            
               Depto:<asp:TextBox ID="txtDepto" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>  
               Piso:<asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" placeholder="" Height="16px" Width="389px"></asp:TextBox>  
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
 
   
</asp:Content>
