using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using ProyectoPAV2.DAL;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.BL
{
    public class TipoDocumentoBL
    {
        public static DataTable getTiposDocumento()
        {
            TipoDocumentoDAL tipoDocumentoDAL = new TipoDocumentoDAL();
            TiposDocumentoCollection lsTiposDocumento = tipoDocumentoDAL.getTiposDocumento();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_tipo_documento");
            dt.Columns.Add("n_tipo_documento");

            object[] arrParams = new object[2];

            foreach (TipoDocumento item in lsTiposDocumento)
            {
                arrParams[0] = item.IdTipoDocumento;
                arrParams[1] = item.NombreTipoDocumento;
                dt.Rows.Add(arrParams);
            }

            return dt;
        }

        public static TipoDocumento getTipoDocumentoPorId(int n)
        {
            TipoDocumentoDAL tipoDocumentoDal = new TipoDocumentoDAL();
            return tipoDocumentoDal.getTipoDocumentoPorID(n);
        }
    }
}
