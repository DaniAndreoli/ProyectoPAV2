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
    public class MedidaBL
    {
        public static DataTable getMedidas()
        {
            MedidaDAL medidaDAL = new MedidaDAL();
            MedidasCollection lsMedidas = medidaDAL.getMedidas();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_medida");
            dt.Columns.Add("n_medida");

            object[] arrParams = new object[2];

            foreach (Medida item in lsMedidas)
            {
                arrParams[0] = item.IdMedida;
                arrParams[1] = item.NombreMedida;
                dt.Rows.Add(arrParams);
            }

            return dt;
        }

        public static Medida getMediaPorID(int idMedida)
        {
            MedidaDAL medidaDAL = new MedidaDAL();
            return medidaDAL.getMedidaPorID(idMedida);
        }
    }
}
