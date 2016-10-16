using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class DetalleProducto
    {
        #region Miembros Privados

        private Insumo insumo;
        private int cantidad;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public DetalleProducto()
        {
            this.Insumo = null;
            this.Cantidad = 0;
        }

        //Constructor con Parametros
        public DetalleProducto(Insumo insumo, int cantidad)
        {
            this.Insumo = insumo;
            this.Cantidad = cantidad;
        }

        #endregion

        #region Properties

        public Insumo Insumo
        {
            get
            {
                return insumo;
            }

            set
            {
                insumo = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
