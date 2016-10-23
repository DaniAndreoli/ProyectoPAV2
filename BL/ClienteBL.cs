using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoPAV2.DAL;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.BL
{
    public class ClienteBL
    {

        public static ClientesCollection getClientes()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            return clienteDAL.getClientes();
        }

        public static int insertarCliente(Cliente c)
        {
            ClienteDAL clienteDal = new ClienteDAL();

            return clienteDal.insertarCliente(c);
        }

    }
}
