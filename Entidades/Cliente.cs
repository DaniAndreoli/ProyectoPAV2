using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Cliente
    {
        #region Miembros Privados

        private int idCliente;
        private string nombre;
        private string apellido;
        private long nroDocumento;
        private TipoDocumento tipoDocumento;
        private long telefono;
        private Domicilio domicilio;
        private string eMail;
        private Usuario usuario;
 

        #endregion

        #region Constructores

        //Constructor sin parametros
        public Cliente()
        {
            this.IdCliente = 0;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.NroDocumento = 0;
            this.TipoDocumento = null;
            this.Telefono = 0;
            this.Domicilio = null;
            this.EMail = string.Empty;
            this.Usuario = null;

        }

        //Constructor con parametros
        public Cliente(int idCliente, string nombre, string apellido, long nroDocumento, TipoDocumento tipoDocumento, long telefono, Domicilio domicilio, string eMail, Usuario usuario)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NroDocumento = nroDocumento;
            this.TipoDocumento = tipoDocumento;
            this.Telefono = telefono;
            this.Domicilio = domicilio;
            this.EMail = eMail;
            this.Usuario = usuario;

        }

        public Cliente(string nombre, string apellido, long nroDocumento, TipoDocumento tipoDocumento, long telefono, Domicilio domicilio, string eMail, Usuario usuario)
        { 
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NroDocumento = nroDocumento;
            this.TipoDocumento = tipoDocumento;
            this.Telefono = telefono;
            this.Domicilio = domicilio;
            this.EMail = eMail;
            this.Usuario = usuario;

        }

        public Cliente(string nombre, string apellido, long nroDocumento, TipoDocumento tipoDocumento, long telefono, Domicilio domicilio, string eMail)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NroDocumento = nroDocumento;
            this.TipoDocumento = tipoDocumento;
            this.Telefono = telefono;
            this.Domicilio = domicilio;
            this.EMail = eMail;


        }

        #endregion

        #region Properties

        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public long NroDocumento
        {
            get
            {
                return nroDocumento;
            }

            set
            {
                nroDocumento = value;
            }
        }

        public TipoDocumento TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public long Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
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

        public string EMail
        {
            get
            {
                return eMail;
            }

            set
            {
                eMail = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }


        #endregion

        #region Metodos
        #endregion
    }
}
