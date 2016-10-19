using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using ProyectoPAV2.Entidades;
using ProyectoPAV2.DAL;

namespace ProyectoPAV2.BL
{
    public class TipoProductoBL
    {
        public static DataTable getTiposProducto()
        {
            TipoProductoDAL tipoProductoDAL = new TipoProductoDAL();
            TiposProductoCollection lsTiposProducto = tipoProductoDAL.getTiposProducto();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_tipo_producto");
            dt.Columns.Add("n_tipo_producto");

            object[] arrParams = new object[2];

            foreach (TipoProducto item in lsTiposProducto)
            {
                arrParams[0] = item.IdTipoProducto;
                arrParams[1] = item.NombreTipoProducto;
                dt.Rows.Add(arrParams);
            }

            return dt;
        }
    }
}
