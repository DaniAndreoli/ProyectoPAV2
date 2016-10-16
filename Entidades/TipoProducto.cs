using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class TipoProducto
    {
        #region Miembros Privados

        private int idTipoProducto;
        private string nombreTipoProducto;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public TipoProducto()
        {
            this.IdTipoProducto = 0;
            this.NombreTipoProducto = string.Empty;
        }

        //Constructor con Parametros
        public TipoProducto(int idTipoProducto, string nombreTipoProducto)
        {
            this.IdTipoProducto = idTipoProducto;
            this.NombreTipoProducto = nombreTipoProducto;
        }

        #endregion

        #region Properties
        public int IdTipoProducto
        {
            get
            {
                return idTipoProducto;
            }

            set
            {
                idTipoProducto = value;
            }
        }

        public string NombreTipoProducto
        {
            get
            {
                return nombreTipoProducto;
            }

            set
            {
                nombreTipoProducto = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
