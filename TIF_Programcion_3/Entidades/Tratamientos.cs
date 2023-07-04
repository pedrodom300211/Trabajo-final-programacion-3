using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tratamientos
    {
        private int NumTram_Tr;
        private Paciente DNIPac_Tr;
        private String Droga_Tr;
        private String Marca_Tr;
        private Boolean Psicoterapia_Tr;
        private Boolean Rehabilitacion_Tr;
        private Boolean TO_Tr;
        private Boolean Otras_Tr;

        public Tratamientos() 
        { 
        }

        public int getNumTram_Tr()
        {
            return this.NumTram_Tr;
        }

        public void setNumTram_Tr(int variable)
        {
            this.NumTram_Tr = variable;
        }

        public Paciente getDNIPac_Tr()
        {
            return this.DNIPac_Tr;
        }

        public void setDNIPac_Tr(Paciente variable)
        {
            this.DNIPac_Tr = variable;
        }

        public string getDroga_Tr()
        {
            return this.Droga_Tr;
        }

        public void setDroga_Tr(string variable)
        {
            this.Droga_Tr = variable;
        }

        public string getMarca_Tr()
        {
            return this.Marca_Tr;
        }

        public void setMarca_Tr(string variable)
        {
            this.Marca_Tr = variable;
        }

        public bool getPsicoterapia_Tr()
        {
            return this.Psicoterapia_Tr;
        }

        public void setPsicoterapia_Tr(bool variable)
        {
            this.Psicoterapia_Tr = variable;
        }

        public bool getRehabilitacion_Tr()
        {
            return this.Rehabilitacion_Tr;
        }

        public void setRehabilitacion_Tr(bool variable)
        {
            this.Rehabilitacion_Tr = variable;
        }

        public bool getTO_Tr()
        {
            return this.TO_Tr;
        }

        public void setTO_Tr(bool variable)
        {
            this.TO_Tr = variable;
        }

        public bool getOtras_Tr()
        {
            return this.Otras_Tr;
        }

        public void setOtras_Tr(bool variable)
        {
            this.Otras_Tr = variable;
        }

    }
}
