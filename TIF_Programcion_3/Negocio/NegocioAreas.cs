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
    public class NegocioAreas
    {
        public DataTable getTabla()
        {
            DaoAreas dao = new DaoAreas();
            return dao.getTablaAreas();
        }

        public DataTable getTablaCodArea_A(String id)
        {
            DaoAreas dao = new DaoAreas();
            Areas areas = new Areas();
            areas.setCodArea_A(id);
            return dao.getTablaAreasPorCodArea(areas);
        }
        public Areas get(String id)
        {
            DaoAreas dao = new DaoAreas();
            Areas areas = new Areas();
            areas.setCodArea_A(id);
            return dao.getAreas(areas);
        }
    }
}
