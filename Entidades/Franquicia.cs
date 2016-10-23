using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Franquicia
    {
        #region Miembros Privados

        private int idFranquicia;
        private Domicilio domicilio;
        private string razonSocial;
        private long cuit;
        private Cliente cliente;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Franquicia()
        {
            this.IdFranquicia = 0;
            this.Domicilio = null;
            this.RazonSocial = string.Empty;
            this.Cuit = 0;
            this.cliente = null;
        }

 

        //Constructor con Parametros
        public Franquicia(int idFranquicia, Domicilio domicilio, string razonSocial, long cuit)
        {
            this.IdFranquicia = idFranquicia;
            this.Domicilio = domicilio;
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            
        }

        //Constructor con Parametros
        public Franquicia(int idFranquicia, Domicilio domicilio, string razonSocial, long cuit,Cliente cliente)
        {
            this.IdFranquicia = idFranquicia;
            this.Domicilio = domicilio;
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            this.cliente = cliente;
        }

        #endregion

        #region Properties

        public int IdFranquicia
        {
            get
            {
                return idFranquicia;
            }

            set
            {
                idFranquicia = value;
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

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
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

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
