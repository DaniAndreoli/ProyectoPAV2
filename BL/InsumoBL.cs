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
    public class InsumoBL
    {

        public static DataTable getInsumos()
        {
            InsumoDAL insumoDAL = new InsumoDAL();
            InsumosCollection lsInsumos = insumoDAL.getInsumos();

            DataTable dt = new DataTable();
            dt.Columns.Add("n_insumo");
            dt.Columns.Add("n_medida");
            dt.Columns.Add("stock");
            dt.Columns.Add("id_insumo");
            dt.Columns.Add("id_medida");

            object[] arrParams = new object[5];

            foreach (Insumo item in lsInsumos)
            {
                arrParams[0] = item.NombreInsumo;
                arrParams[1] = item.Medida.NombreMedida;
                arrParams[2] = item.Stock;
                arrParams[3] = item.IdInsumo;
                arrParams[4] = item.Medida.IdMedida;
                dt.Rows.Add(arrParams);
            }
            return dt;
        }

        public static int insertarInsumo(Insumo insumo)
        {
            InsumoDAL insumoDAL = new InsumoDAL();

            return insumoDAL.insertarInsumo(insumo);
        }

        public static void eliminarInsumo(int idInsumo)
        {
            InsumoDAL insumoDAL = new InsumoDAL();
            insumoDAL.eliminarInsumo(idInsumo);
        }

        public static void modificarInsumo(Insumo insumo)
        {
            InsumoDAL insumoDAL = new InsumoDAL();
            insumoDAL.modificarInsumo(insumo);
        }

        public static Insumo getInsumoPorID(int idInsumo)
        {
            InsumoDAL insumoDAL = new InsumoDAL();
            return insumoDAL.getInsumoPorID(idInsumo);
        }
    }
}
