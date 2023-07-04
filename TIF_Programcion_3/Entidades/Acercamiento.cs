using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Acercamiento
    {
        private String CodAcerc_A;
        private String Descripcion_A;
        // Constructor
        public Acercamiento()
        {
        }
        // Gets
        public String getCodAcerc_A()
        {
            return this.CodAcerc_A;
        }
        public String getDescripcion_A()
        {
            return this.Descripcion_A;
        }
        // Sets
        public void setCodAcerc_A(String CodAcerc_A)
        {
            this.CodAcerc_A = CodAcerc_A;
        }
        public void setDescripcion_A(String Descripcion_A)
        {
            this.Descripcion_A = Descripcion_A;
        }
    }
}
