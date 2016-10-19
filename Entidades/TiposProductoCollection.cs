using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class TiposProductoCollection : List<TipoProducto>
    {
        /// <summary>
        /// Retorna el objeto de la clase TipoProducto especificado en el parametro de entrada
        /// </summary>
        /// <param name="idTipoProducto"></param>
        /// <returns>Objeto TipoProducto</returns>
        public TipoProducto getTipoProductoPorID(int idTipoProducto)
        {
            TipoProducto objTipoProducto = null;

            foreach (TipoProducto item in this)
            {
                if (item.IdTipoProducto == idTipoProducto)
                {
                    objTipoProducto = item;
                    break;
                }
            }

            return objTipoProducto;
        }


    }
}
