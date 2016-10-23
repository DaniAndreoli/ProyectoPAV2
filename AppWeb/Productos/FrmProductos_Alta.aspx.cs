using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using ProyectoPAV2.Entidades;
using ProyectoPAV2.BL;

namespace ProyectoPAV2.AppWeb.Productos
{
    public partial class FrmProductos_Alta : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarComboTiposProducto();
                cargarGrillaInsumos();
                cargarGrillaProductos();
                txtNombreProducto.Focus();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    double precio = 0;

                    //Creamos el objeto Producto
                    Producto objProducto = new Producto();

                    objProducto.NombreProducto = txtNombreProducto.Text;
                    objProducto.TipoProducto = TipoProductoBL.getTipoProductoPorID(int.Parse(ddlTiposProducto.SelectedValue));
                    objProducto.PrecioUnitario = double.TryParse(txtPrecioUnitario.Text, out precio) == true ? precio : 0;

                    DetalleProducto objDetalle;
                    Insumo objInsumo;
                    DataTable tInsumos = ViewState["tInsumos"] as DataTable;

                    //Asignamos los objetos Detalle
                    foreach (GridViewRow row in gvInsumos.Rows)
                    {
                        CheckBox check = row.Cells[3].Controls[1] as CheckBox;
                        TextBox txt = row.Cells[1].Controls[1] as TextBox;

                        if (check != null && check.Checked)
                        {
                            objInsumo = new Insumo(
                                int.Parse(tInsumos.Rows[row.RowIndex]["id_insumo"].ToString()),
                                tInsumos.Rows[row.RowIndex]["n_insumo"].ToString(),
                                MedidaBL.getMediaPorID(int.Parse(tInsumos.Rows[row.RowIndex]["id_medida"].ToString()))
                                );

                            objDetalle = new DetalleProducto(
                                objInsumo,
                                int.Parse(txt.Text));

                            objProducto.LsDetalles.Add(objDetalle);
                        }
                    }
                    switch (btnGuardar.Text)
                    {
                        case "Guardar":

                            ProductoBL.insertarProducto(objProducto);

                            break;
                        case "Modificar":

                            break;
                        default:
                            break;
                    }

                }
                else
                {

                }

                
                
            }
            catch (Exception)
            {
                this.limpiarControles();
                Master.MostrarMensaje(new Excepciones.Excepciones(ex.Message, ex).Message, AppWeb.TipoMensaje.Error);
            }
            

            
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void validarCheckDetalles(object source, ServerValidateEventArgs args)
        {
            //Seteamos una variable local para saber si se seleccionó algun Insumo para el detalle de Producto
            bool checkSeleccionado = false;

            //Declaramos un objeto CheckBox que utilizaremos para castear los elementos de la grilla
            CheckBox objCheck;
            for (int i = 0; i < gvInsumos.Rows.Count; i++)
            {
                objCheck = gvInsumos.Rows[i].Cells[3].Controls[1] as CheckBox;
                if (objCheck.Checked)
                    checkSeleccionado = true;
            }

            args.IsValid = checkSeleccionado;
        }

        #endregion

        #region Metodos

        private void cargarComboTiposProducto()
        {
            ddlTiposProducto.DataSource = TipoProductoBL.getTiposProducto();
            ddlTiposProducto.DataValueField = "id_tipo_producto";
            ddlTiposProducto.DataTextField = "n_tipo_producto";
            ddlTiposProducto.DataBind();
        }

        private void cargarGrillaInsumos()
        {
            ViewState.Add("tInsumos", InsumoBL.getInsumos());
            gvInsumos.DataSource = ViewState["tInsumos"] as DataTable;
            gvInsumos.DataBind();
        }

        private void cargarGrillaProductos()
        {
            ViewState.Add("tProductos", ProductoBL.getProductos());
            gvProductos.DataSource = ViewState["tProductos"] as DataTable;
            gvProductos.DataBind();
        }

        #endregion  

    }
}