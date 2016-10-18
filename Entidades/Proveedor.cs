using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Proveedor
    {
        #region Miembros Privados

        private int idProveedor;
        private long cuit;
        private string nombreProveedor;
        private Domicilio domicilio;
        private DateTime? fechaAlta;
        private DateTime? fechaBaja;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Proveedor()
        {
            this.IdProveedor = 0;
            this.Cuit = 0;
            this.NombreProveedor = string.Empty;
            this.Domicilio = null;
            this.FechaAlta = null;
            this.FechaBaja = null;
        }

        //Constructor con Parametros
        public Proveedor(int idProveedor, long cuit, string nombreProveedor, Domicilio domicilio, DateTime? fechaAlta, DateTime? fechaBaja)
        {
            this.IdProveedor = idProveedor;
            this.Cuit = cuit;
            this.NombreProveedor = nombreProveedor;
            this.Domicilio = domicilio;
            this.FechaAlta = fechaAlta;
            this.FechaBaja = fechaBaja;
        }

        #endregion

        #region Properties

        public int IdProveedor
        {
            get
            {
                return idProveedor;
            }

            set
            {
                idProveedor = value;
            }
        }

        public long Cuit
        {
            get
            {
                return cuit;
            }

            set
            {
                cuit = value;
            }
        }

        public string NombreProveedor
        {
            get
            {
                return nombreProveedor;
            }

            set
            {
                nombreProveedor = value;
            }
        }

        public Domicilio Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public DateTime? FechaAlta
        {
            get
            {
                return fechaAlta;
            }

            set
            {
                fechaAlta = value;
            }
        }

        public DateTime? FechaBaja
        {
            get
            {
                return fechaBaja;
            }

            set
            {
                fechaBaja = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
