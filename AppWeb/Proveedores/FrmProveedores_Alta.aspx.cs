using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoPAV2.BL;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.AppWeb.Proveedores
{
    public partial class FrmProveedores_Alta : System.Web.UI.Page
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
            ddlLocalidades.DataSource = LocalidadesBL.getLocalidades();
            ddlLocalidades.DataValueField = "id_localidad";
            ddlLocalidades.DataTextField = "n_localidad";
            ddlLocalidades.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Domicilio d = new Domicilio(
              LocalidadesBL.getLocalidadPorId(int.Parse(ddlLocalidades.SelectedValue)),
              int.Parse(txtNumeroCalle.Text),
              int.Parse(txtPiso.Text),
              txtDepto.Text,
              txtBarrio.Text,
              txtCalle.Text
              );
            Proveedor p = new Proveedor(
                long.Parse(txtCuit.Text),
                txtNombre.Text,
                d
                );
            ProveedorBL.insertarProveedor(p);
        }

    }
}