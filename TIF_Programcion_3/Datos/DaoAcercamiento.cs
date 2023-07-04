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
    public class DaoAcercamiento
    {
        private AccesoDatos ds = new AccesoDatos();
        public Acercamiento getAcercamiento(Acercamiento acercamiento)
        {
            DataTable tabla = ds.ObtenerTabla("Acercamiento", "SELECT * FROM Acercamiento WHERE CodAcerc_A='" + acercamiento.getCodAcerc_A() + "'");
            acercamiento.setCodAcerc_A(tabla.Rows[0][0].ToString());
            acercamiento.setDescripcion_A(tabla.Rows[0][1].ToString());
            return acercamiento;
        }
        public Boolean existeAcercamiento(Acercamiento acercamiento)
        {
            String consulta = "SELECT * FROM Acercamiento WHERE CodAcerc_A='" + acercamiento.getCodAcerc_A() + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaAcercamiento()
        {
            DataTable tabla = ds.ObtenerTabla("Acercamiento", "SELECT * FROM Acercamiento");
            return tabla;
        }
        public DataTable getTablaAcercamientoPorCodAcerc(Acercamiento acercamiento)
        {
            DataTable tabla = ds.ObtenerTabla("Acercamiento", "SELECT * FROM Acercamiento WHERE CodAcerc_A='" + acercamiento.getCodAcerc_A() + "'");
            return tabla;
        }
    }
}
