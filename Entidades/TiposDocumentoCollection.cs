using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace ProyectoPAV2.Entidades
{
    public class TiposDocumentoCollection : List<TipoDocumento>
    {

        /// <summary>
        /// Retorna el objeto de la clase TipoDocumento especificado en el parametro de entrada
        /// </summary>
        /// <param name="idTipoDocumento"></param>
        /// <returns>Objeto TipoDocumento</returns>
        public TipoDocumento getTipoDocumentoPorID(int idTipoDocumento)
        {
            TipoDocumento objTipoDocumento = null;

            foreach (TipoDocumento item in this)
            {
                if (item.IdTipoDocumento == idTipoDocumento)
                {
                    objTipoDocumento = item;
                    break;
                }
            }

            return objTipoDocumento;
        }
    }
}
