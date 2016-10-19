using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoPAV2.BL;

namespace ProyectoPAV2.AppWeb.Insumos
{
    public partial class FrmInsumos_Alta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarComboMedidas();
        }

        private void cargarComboMedidas()
        {
            ddlMedidas.DataSource = MedidaBL.getMedidas();
            ddlMedidas.DataValueField = "id_medida";
            ddlMedidas.DataTextField = "n_medida";
            ddlMedidas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}