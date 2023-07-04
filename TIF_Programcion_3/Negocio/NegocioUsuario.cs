using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioUsuario
    {
        public DataTable getTabla()
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaUsuario();
        }
        public Usuario get(String dni)
        {
            DaoUsuario dao = new DaoUsuario();
            Usuario usuario = new Usuario();
            usuario.setDNI_U(dni);
            return dao.getUsuario(usuario);
        }
        public Boolean agregarUsuario(Usuario usuario)
        {
            int cantFilas = 0;
            DaoUsuario dao = new DaoUsuario();
            if (dao.existeUsuario(usuario) == false)
            {
                cantFilas = dao.agregarUsuario(usuario);
            }
            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean existeUsuariorDNI(Usuario usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.existeUsuario(usuario);
        }
        public Boolean ActivoUsuario(Usuario usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.ActivoUsuario(usuario);
        }
    }
}
