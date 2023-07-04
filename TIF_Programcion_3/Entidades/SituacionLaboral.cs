using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SituacionLaboral
    {
        private String CodSitLab_SL;
        private String Descripcion_SL;
        // Constructor
        public SituacionLaboral()
        {
        }
        // Gets
        public String getCodSitLab_SL()
        {
            return this.CodSitLab_SL;
        }
        public String getDescripcion_SL()
        {
            return this.Descripcion_SL;
        }
        // Sets
        public void setCodSitLab_SL(String CodSitLab_SL)
        {
            this.CodSitLab_SL = CodSitLab_SL;
        }
        public void setDescripcion_SL(String Descripcion_SL)
        {
            this.Descripcion_SL = Descripcion_SL;
        }
    }
}
