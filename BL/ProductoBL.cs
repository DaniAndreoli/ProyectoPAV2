using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoPAV2.Entidades;
using ProyectoPAV2.DAL;

using System.Data;

namespace ProyectoPAV2.BL
{
    public class ProductoBL
    {

        public static int insertarProducto(Producto producto)
        {
            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.insertarProducto(producto);
        }

        public static DataTable getProductos()
        {
            ProductoDAL productoDAL = new ProductoDAL();
            ProductosCollection lsProductos = productoDAL.getProductos();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_producto");
            dt.Columns.Add("n_producto");
            dt.Columns.Add("id_tipo_producto");
            dt.Columns.Add("precio_unitario");
            dt.Columns.Add("stock");

            object[] arrParams = new object[5];

            foreach (Producto item in lsProductos)
            {
                arrParams[0] = item.IdProducto;
                arrParams[1] = item.NombreProducto;
                arrParams[2] = item.TipoProducto.IdTipoProducto;
                arrParams[3] = item.PrecioUnitario;
                arrParams[4] = item.Stock;
                dt.Rows.Add(arrParams);
            }

            return dt;
        }
    }
}
