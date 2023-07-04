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
    public class NegocioSituacionLaboral
    {
        public DataTable getTabla()
        {
            DaoSituacionLaboral dao = new DaoSituacionLaboral();
            return dao.getTablaSituacionLaboral();
        }

        public DataTable getTablaCodSitLab(String id)
        {
            DaoSituacionLaboral dao = new DaoSituacionLaboral();
            SituacionLaboral situacionLaboral = new SituacionLaboral();
            situacionLaboral.setCodSitLab_SL(id);
            return dao.getTablaSituacionLaboralPorCodSitLab(situacionLaboral);
        }
        public SituacionLaboral get(String id)
        {
            DaoSituacionLaboral dao = new DaoSituacionLaboral();
            SituacionLaboral situacionLaboral = new SituacionLaboral();
            situacionLaboral.setCodSitLab_SL(id);
            return dao.getSituacionLaboral(situacionLaboral);
        }
    }
}
