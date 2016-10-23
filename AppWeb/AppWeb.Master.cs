using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPAV2.AppWeb
{
    public partial class AppWeb : System.Web.UI.MasterPage
    {
        #region Miembros Publicos

        public enum TipoMensaje { Exito, Error, Info, Aviso };
        public event EventHandler confirmacionModal;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Boton de confirmacion de dialogo emergente
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Verificamos que la interfaz desde donde se origino la llamada, haya instanciado el manejador del evento (EventHandler) 
            if (confirmacionModal != null)
                //En caso afirmativo, desencadena la ejecucion del Manejador (EventHandler) definido en el Page_PreInit de los formularios
                confirmacionModal(this, EventArgs.Empty);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que permite mostrar un mensaje de informacion al usuario, respecto de una operacion realizada
        /// </summary>
        /// <param name="mensaje">Texto del mensaje que se desea mostrar al usuario</param>
        /// <param name="tipo">Tipo de mensaje que define el estilo con que se muestra el informe</param>
        public void MostrarMensaje(string mensaje, TipoMensaje tipo)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "MostrarMensaje('" + mensaje + "','" + tipo + "');", true);
        }

        /// <summary>
        /// Metodo que permite ejecutar una funcion JS para mostrar el dialogo de confirmacion
        /// </summary>
        /// <param name="mensaje">Texto que aparecerá en el cuadro de dialogo</param>
        public void PedirConfirmacion(string mensaje)
        {
            mensajeConfirmacion.InnerText = mensaje;
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "PedirConfirmacion();", true);
        }

        #endregion
    }
}   