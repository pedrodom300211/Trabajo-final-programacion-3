using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ObservacionGeneral
    {
        private int NumObser_OG;
        private Paciente DNIPac_OG;
        private String Descripcion_OG;
        private Areas CodArea_OG;
        /// Constructor
        public ObservacionGeneral()
        {
        }
        /// Gets
        public int getNumObser_OG()
        {
            return this.NumObser_OG;
        }
        public Paciente getDNIPac_OG()
        {
            return this.DNIPac_OG;
        }
        public String getDescripcion_OG()
        {
            return this.Descripcion_OG;
        }
        public Areas getCodArea_OG()
        {
            return this.CodArea_OG;
        }
        /// Sets
        public void setNumObser_OG(int NumObser_OG)
        {
            this.NumObser_OG = NumObser_OG;
        }
        public void setDNIPac_OG(Paciente DNIPac_OG)
        {
            this.DNIPac_OG = DNIPac_OG;
        }
        public void setDescripcion_OG(String Descripcion_OG)
        {
            this.Descripcion_OG = Descripcion_OG;
        }
        public void setCodArea_OG(Areas CodArea_OG)
        {
            this.CodArea_OG = CodArea_OG;
        }
    }
}
