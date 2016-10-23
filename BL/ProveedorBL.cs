using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoPAV2.DAL;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.BL
{
    public class ProveedorBL
    {
        public static ProveedorCollection getProveedor()
        {
            ProveedorDAL proveedorDAL = new ProveedorDAL();
            return proveedorDAL.getProveedores();
        }
        public static int insertarProveedor(Proveedor proveedor)
        {
            ProveedorDAL proveedorDAL = new ProveedorDAL();
            return proveedorDAL.insertarProveedor(proveedor);
        }
    }
}
