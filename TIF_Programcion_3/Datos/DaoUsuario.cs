using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoUsuario
    {
        private AccesoDatos ds = new AccesoDatos();
        public Usuario getUsuario(Usuario usuario)
        {
            DataTable tabla = ds.ObtenerTabla("Usuario", "SELECT * FROM Usuario WHERE DNI_U='" + usuario.getDNI_U() + "'");
            usuario.setDNI_U(tabla.Rows[0][0].ToString());
            usuario.setRol_U(Convert.ToBoolean(tabla.Rows[0][1].ToString()));
            usuario.setContraseña_U(tabla.Rows[0][2].ToString());
            usuario.setEstado(Convert.ToBoolean(tabla.Rows[0][3].ToString()));
            return usuario;
        }
        public Boolean existeUsuario(Usuario usuario) // busca usuario por DNI
        {
            String consulta = "SELECT * FROM Usuario WHERE DNI_U='" + usuario.getDNI_U() + "'";
            return ds.existe(consulta);
        }
        public Boolean ActivoUsuario(Usuario usuario) 
        {
            DataTable tabla = ds.ObtenerTabla("Usuario", "SELECT Estado FROM Usuario WHERE DNI_U='" + usuario.getDNI_U() + "'");
            if(Convert.ToBoolean( tabla.Rows[0][0])== true)
            { return true; }
            else { return false; }
        }
        public DataTable getTablaUsuario()
        {
            DataTable tabla = ds.ObtenerTabla("Usuario", "SELECT * FROM Usuario"); // MODIFICADO Y FUNCIONANDO
            return tabla;
        }
        public DataTable getTablaUsuarioPorDNI(Usuario usuario)
        {
            DataTable tabla = ds.ObtenerTabla("Usuario", "SELECT * FROM Usuario WHERE DNI_U='" + usuario.getDNI_U() + "'");
            return tabla;
        }
        public int agregarUsuario(Usuario usuario)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuarioAgregar(ref comando, usuario);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SP_AgregarUsuario");
        }
        private void ArmarParametrosUsuarioAgregar(ref SqlCommand Comando, Usuario usuario)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNI_U", SqlDbType.VarChar);
            SqlParametros.Value = usuario.getDNI_U();
           
            SqlParametros = Comando.Parameters.Add("@Contraseña_U", SqlDbType.VarChar);
            SqlParametros.Value = usuario.getContraseña_U();
        }
    }
}
