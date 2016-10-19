using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoPAV2.BL;

namespace ProyectoPAV2.AppWeb.Productos
{
    public partial class FrmProductos_Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarComboTiposProducto();
        }

        private void cargarComboTiposProducto()
        {
            ddlTiposProducto.DataSource = TipoProductoBL.getTiposProducto();
            ddlTiposProducto.DataValueField = "id_tipo_producto";
            ddlTiposProducto.DataTextField = "n_tipo_producto";
            ddlTiposProducto.DataBind();
        }
    }
}