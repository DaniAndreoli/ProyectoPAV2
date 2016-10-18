using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    /// <summary>
    /// Clase empleada para mantener informacion util para la Capa de Acceso a Datos
    /// Es una clase Interna y Estatica puesto a que estara disponible para todas las demas clases de la capa DAL
    /// Objetivo: Evita que las clases de la capa DAL tengan que instanciar objetos entre si para intercambiar informacion almacenada en la base de datos
    /// </summary>
    internal static class DBHelper
    {
        private static TiposDocumentoCollection lsTiposDocumento = new TiposDocumentoCollection();
        private static MedidasCollection lsMedidas = new MedidasCollection();

        /// <summary>
        /// Metodo que permite obtener el listado completo de Tipos de Documento desde la Base de Datos
        /// </summary>
        /// <returns>Lista de tipo Generics, con objetos TipoDocumento</returns>
        public static TiposDocumentoCollection getTiposDocumento()
        {
            //Instanciamos un objeto TipoDocumento de la capa de datos
            TipoDocumentoDAL tipoDocuDAL = new TipoDocumentoDAL();

            //Solicitamos al objeto que nos devuelva todos los registros de Tipos de Documento disponibles en la Base de Datos
            if (lsTiposDocumento.Count == 0)
                lsTiposDocumento = tipoDocuDAL.getTiposDocumento();

            return lsTiposDocumento;
        }

        /// <summary>
        /// Metodo que permite obtener el objeto TipoDocumento especificado en el parametro de entrada
        /// </summary>
        /// <param name="idTipoDocumento"></param>
        /// <returns></returns>
        public static TipoDocumento getTipoDocumentoPorID(int idTipoDocumento)
        {
            TipoDocumento objTipoDocumento;

            //Verificamos que la clase no contenga ya un listado con los objetos TipoDocumento para evitar una consulta a la Base de Datos
            if (lsTiposDocumento.Count != 0)
            {
                objTipoDocumento = lsTiposDocumento.getTipoDocumentoPorID(idTipoDocumento);

                if (objTipoDocumento != null)
                    return objTipoDocumento;
                else
                {
                    //Si no encontramos el TipoDocumento especificado, en la coleccion local, la actualizamos
                    lsTiposDocumento = getTiposDocumento();
                    objTipoDocumento = lsTiposDocumento.getTipoDocumentoPorID(idTipoDocumento);
                }
            } 
            else
            {
                TipoDocumentoDAL tipoDocuDAL = new TipoDocumentoDAL();

                objTipoDocumento = tipoDocuDAL.getTipoDocumentoPorID(idTipoDocumento);
            }

            return objTipoDocumento;
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Domicilio especificado en el parametro de entrada
        /// </summary>
        /// <param name="idDomicilio"></param>
        /// <returns>Objeto Domicilio</returns>
        public static Domicilio getDomicilioPorID(int idDomicilio)
        {
            DomicilioDAL domicilioDAL = new DomicilioDAL();

            return domicilioDAL.getDomicilioPorID(idDomicilio);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Localidad especificado en el parametro de entrada
        /// </summary>
        /// <param name="idLocalidad"></param>
        /// <returns></returns>
        public static Localidad getLocalidadPorID(int idLocalidad)
        {
            LocalidadDAL localidadDAL = new LocalidadDAL();

            return localidadDAL.getLocalidadPorID(idLocalidad);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Usuario especificado en el parametro de entrada
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns>Objeto Usuario</returns>
        public static Usuario getUsuarioPorID(int idUsuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            return usuarioDAL.getUsuarioPorID(idUsuario);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Franquicia especificado en el parametro de entrada
        /// </summary>
        /// <param name="idFranquicia"></param>
        /// <returns>Objeto Franquicia</returns>
        public static Franquicia getFranquiciaPorID(int idFranquicia)
        {
            FranquiciaDAL franquiciaDAL = new FranquiciaDAL();

            return franquiciaDAL.getFranquiciaPorID(idFranquicia);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase EstadoSolicitud por idEstado
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns>Objeto EstadoSolicitud</returns>
        public static EstadoSolicitud getEstadoSolicitud(int idEstado)
        {
            EstadoSolicitudDAL estadoSolicitudDAL = new EstadoSolicitudDAL();

            return estadoSolicitudDAL.getEstadoPorID(idEstado);
        }

        /// <summary>
        /// Metodo que permite obtener una coleccion de todas las franquicias pertenecientes a un cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static FranquiciasCollection getFranquiciasPorCliente(int idCliente)
        {
            FranquiciaDAL franquiciaDAL = new FranquiciaDAL();

            return franquiciaDAL.getFranquiciasPorCliente(idCliente);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase EstadoPedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        public static EstadoPedido getEstadoPorID(int idEstado)
        {
            EstadoPedidoDAL estadoPedidoDAL = new EstadoPedidoDAL();

            return estadoPedidoDAL.getEstadoPorID(idEstado);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Cliente especificando un id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static Cliente getClientePorID(int idCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            return clienteDAL.getClientePorID(idCliente);
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Proveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
        public static Proveedor getProveedorPorID(int idProveedor)
        {
            ProveedorDAL proveedorDAL = new ProveedorDAL();

            return proveedorDAL.getProveedorPorID(idProveedor);
        }

        /// <summary>
        /// Metodo que permite obtener la coleccion de todos los objetos de la clase Medida
        /// </summary>
        /// <returns></returns>
        public static MedidasCollection getMedidas()
        {
            MedidaDAL medidaDAL = new MedidaDAL();

            if (lsMedidas.Count == 0)
                lsMedidas = medidaDAL.getMedidas();

            return lsMedidas;
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Medida especificado en el parametro de entrada
        /// </summary>
        /// <param name="idMedida"></param>
        /// <returns></returns>
        public static Medida getMedidaPorID(int idMedida)
        {
            Medida objMedida = null;

            if(lsMedidas.Count != 0)
            {
                objMedida = lsMedidas.getMedidaPorID(idMedida);

                if (objMedida != null)
                    return objMedida;
                else
                {
                    //Si no encontramos el objeto medida en la coleccion local actualizamos la lista
                    lsMedidas = getMedidas();
                    objMedida = lsMedidas.getMedidaPorID(idMedida);
                }
            }
            else
            {
                MedidaDAL medidaDAL = new MedidaDAL();

                objMedida = medidaDAL.getMedidaPorID(idMedida);
            }

            return objMedida;
        }

        /// <summary>
        /// Metodo que permite obtener el objeto de la clase Insumo especificado en el parametro de entrada
        /// </summary>
        /// <param name="idInsumo"></param>
        /// <returns></returns>
        public static Insumo getInsumoPorID(int idInsumo)
        {
            InsumoDAL insumoDAL = new InsumoDAL();

            return insumoDAL.getInsumoPorID(idInsumo);
        }

        /// <summary>
        /// Metodo que permite obtener una coleccion con todos los objetos DetalleCompraProveedor 
        /// de la CompraProveedor especificada en el parametro de entrada
        /// </summary>
        /// <param name="idCompra">Id del objeto Compra que posee el DetalleCompraProveedor que se desea retornar</param>
        /// <returns></returns>
        public static DetallesCompraProveedorCollection getDetallesCompraProveedor(int idCompra)
        {
            DetalleCompraProveedorDAL detalleCompraProveedorDAL = new DetalleCompraProveedorDAL();

            return detalleCompraProveedorDAL.getDetallesCompraProveedor(idCompra);
        }
    }
}
