using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoPAV2.BL;
using ProyectoPAV2.Entidades;


namespace ProyectoPAV2.AppWeb.SolicitudesFranquicia
{   
    public partial class FrmSolicitudesFranquicia_Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarCombos();
            }
            
        }

        private void cargarCombos()
        {
            ddlTiposDocumento.DataSource = TipoDocumentoBL.getTiposDocumento();
            ddlTiposDocumento.DataValueField = "id_tipo_documento";
            ddlTiposDocumento.DataTextField = "n_tipo_documento";
            ddlTiposDocumento.DataBind();

            ddlLocalidades.DataSource = LocalidadesBL.getLocalidades();
            ddlLocalidades.DataValueField = "id_localidad";
            ddlLocalidades.DataTextField = "n_localidad";
            ddlLocalidades.DataBind();
        }

        protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
        { 
            Domicilio d = new Domicilio(
                LocalidadesBL.getLocalidadPorId(int.Parse(ddlLocalidades.SelectedValue)),
                int.Parse(txtNumeroDomicilio.Text),
                int.Parse(txtPisoDomicilio.Text),
                txtDepartamentoDomicilio.Text,
                txtBarrioDomicilio.Text,
                txtCalle.Text
            );

            Cliente c = new Cliente(

                txtNombreCliente.Text,
                txtApellidoCliente.Text,
                long.Parse(txtNumeroDocumento.Text),
                TipoDocumentoBL.getTipoDocumentoPorId(int.Parse(ddlTiposDocumento.SelectedValue)),
                long.Parse(txtTelefono.Text),
                d,
                txtEmail.Text

            );

            SolicitudFranquicia solicitud = new SolicitudFranquicia(
                c,
                Solicitudes_FranquiciaBL.obtenerEstadoSolicitud(0)

            );

        
            Solicitudes_FranquiciaBL.insertarSolicitud(solicitud);
                
        }
    }
}