using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class DetallePedido
    {
        #region Miembros Privados

        private Producto producto;
        private int cantidad;
        private double precioUnitario;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public DetallePedido()
        {
            this.Producto = null;
            this.Cantidad = 0;
            this.PrecioUnitario = 0;
        }

        //Constructor con Parametros
        public DetallePedido(Producto producto, int cantidad, double precioUnitario)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }

        #endregion

        #region Properties
        public Producto Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
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

        public double PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }

            set
            {
                precioUnitario = value;
            }
        }
        #endregion

        #region Metodos
        #endregion
    }
}
