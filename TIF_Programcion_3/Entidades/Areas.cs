using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Areas
    {
        private String CodArea_A;
        private String Descripcion_A;
        // Constructor
        public Areas()
        {
        }
        // Gets
        public String getCodArea_A()
        {
            return this.CodArea_A;
        }
        public String getDescripcion_A()
        {
            return this.Descripcion_A;
        }
        // Sets
        public void setCodArea_A(String CodArea_A)
        {
            this.CodArea_A = CodArea_A;
        }
        public void setDescripcion_A(String Descripcion_A)
        {
            this.Descripcion_A = Descripcion_A;
        }
    }
}
