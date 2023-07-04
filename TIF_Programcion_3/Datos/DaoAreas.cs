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
    public class DaoAreas
    {
        private AccesoDatos ds = new AccesoDatos();
        public Areas getAreas(Areas areas)
        {
            DataTable tabla = ds.ObtenerTabla("Areas", "SELECT * FROM Areas WHERE CodArea_A='" + areas.getCodArea_A() + "'");
            areas.setCodArea_A(tabla.Rows[0][0].ToString());
            areas.setDescripcion_A(tabla.Rows[0][1].ToString());
            return areas;
        }
        public Boolean existeAreas(Areas areas)
        {
            String consulta = "SELECT * FROM Areas WHERE CodArea_A='" + areas.getCodArea_A() + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaAreas()
        {
            DataTable tabla = ds.ObtenerTabla("Areas", "SELECT * FROM Areas");
            return tabla;
        }
        public DataTable getTablaAreasPorCodArea(Areas areas)
        {
            DataTable tabla = ds.ObtenerTabla("Areas", "SELECT * FROM Areas WHERE CodArea_A='" + areas.getCodArea_A() + "'");
            return tabla;
        }
    }
}
