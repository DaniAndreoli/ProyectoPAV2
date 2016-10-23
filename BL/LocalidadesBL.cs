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
    public class LocalidadesBL
    {
        public static DataTable getLocalidades(){
            
            LocalidadDAL localidadDAL = new LocalidadDAL();
            LocalidadesCollection lsLocalidades = localidadDAL.getLocalidades();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_localidad");
            dt.Columns.Add("n_localidad");
            

            object[] arrParams = new object[2];

            foreach (Localidad item in lsLocalidades)
            {
                arrParams[0] = item.IdLocalidad;
                arrParams[1] = item.NombreLocalidad;
                
                dt.Rows.Add(arrParams);
            }

            return dt;
            
        }

        public static Localidad getLocalidadPorId(int n)
        {
            LocalidadDAL localidadDAL = new LocalidadDAL();

            return localidadDAL.getLocalidadPorID(n);
        }
    }
}
