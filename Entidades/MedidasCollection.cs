using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class MedidasCollection : List<Medida>
    {

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Medida especificado en el parametro de entrada
        /// </summary>
        /// <param name="idMedida"></param>
        /// <returns></returns>
        public Medida getMedidaPorID(int idMedida)
        {
            Medida objMedida = null;

            foreach (Medida item in this)
            {
                if (item.IdMedida == idMedida)
                {
                    objMedida = item;
                    break;
                }
            }

            return objMedida;
        }
    }
}
