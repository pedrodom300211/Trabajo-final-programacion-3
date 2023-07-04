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
    public class NegocioAcercamiento
    {
        public DataTable getTabla()
        {
            DaoAcercamiento dao = new DaoAcercamiento();
            return dao.getTablaAcercamiento();
        }

        public DataTable getTablaCodAcerc(String id)
        {
            DaoAcercamiento dao = new DaoAcercamiento();
            Acercamiento acercamiento = new Acercamiento();
            acercamiento.setCodAcerc_A(id);
            return dao.getTablaAcercamientoPorCodAcerc(acercamiento);
        }
        public Acercamiento get(String id)
        {
            DaoAcercamiento dao = new DaoAcercamiento();
            Acercamiento acercamiento = new Acercamiento();
            acercamiento.setCodAcerc_A(id);
            return dao.getAcercamiento(acercamiento);
        }
    }
}
