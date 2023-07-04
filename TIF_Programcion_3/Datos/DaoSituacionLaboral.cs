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
    public class DaoSituacionLaboral
    {
        private AccesoDatos ds = new AccesoDatos();
        public SituacionLaboral getSituacionLaboral(SituacionLaboral situacionLaboral)
        {
            DataTable tabla = ds.ObtenerTabla("SituacionLaboral", "SELECT * FROM SituacionLaboral WHERE CodSitLab_SL='" + situacionLaboral.getCodSitLab_SL() + "'");
            situacionLaboral.setCodSitLab_SL(tabla.Rows[0][0].ToString());
            situacionLaboral.setDescripcion_SL(tabla.Rows[0][1].ToString());
            return situacionLaboral;
        }
        public Boolean existeSituacionLaboral(SituacionLaboral situacionLaboral)
        {
            String consulta = "SELECT * FROM SituacionLaboral WHERE CodSitLab_SL='" + situacionLaboral.getCodSitLab_SL() + "'";
            return ds.existe(consulta);
        }
        public DataTable getTablaSituacionLaboral()
        {
            DataTable tabla = ds.ObtenerTabla("SituacionLaboral", "SELECT * FROM SituacionLaboral");
            return tabla;
        }
        public DataTable getTablaSituacionLaboralPorCodSitLab(SituacionLaboral situacionLaboral)
        {
            DataTable tabla = ds.ObtenerTabla("SituacionLaboral", "SELECT * FROM SituacionLaboral WHERE CodSitLab_SL='" + situacionLaboral.getCodSitLab_SL() + "'");
            return tabla;
        }
    }
}
