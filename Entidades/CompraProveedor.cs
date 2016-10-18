using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class CompraProveedor
    {
        #region Miembros Privados

        private int idCompra;
        private Proveedor proveedor;
        private DateTime? fecha;
        private DetallesCompraProveedorCollection lsDetalles;

        #endregion

        #region Constructores

        //Constructor con Parametros
        public CompraProveedor()
        {
            this.IdCompra = 0;
            this.Proveedor = null;
            this.Fecha = null;
            this.LsDetalles = null;
        }

        //Constructor con Parametros sin instancia de DetalleCompraProveedor
        public CompraProveedor(int idCompra, Proveedor proveedor, DateTime fecha)
        {
            this.IdCompra = idCompra;
            this.Proveedor = proveedor;
            this.Fecha = fecha;
            this.LsDetalles = null;
        }

        //Constructor con Parametros
        public CompraProveedor(int idCompra, Proveedor proveedor, DateTime fecha, DetallesCompraProveedorCollection lsDetalles)
        {
            this.IdCompra = idCompra;
            this.Proveedor = proveedor;
            this.Fecha = fecha;
            this.LsDetalles = lsDetalles;
        }

        #endregion

        #region Properties

        public int IdCompra
        {
            get
            {
                return idCompra;
            }

            set
            {
                idCompra = value;
            }
        }

        public Proveedor Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        public DateTime? Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public DetallesCompraProveedorCollection LsDetalles
        {
            get
            {
                return lsDetalles;
            }

            set
            {
                lsDetalles = value;
            }
        }

        #endregion

        #region Metodos

        #endregion
    }
}
