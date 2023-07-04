using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private String DNIPac_Pa;
        private String NombreApellido_PA;
        private String Edad_PA;
        private String NomAcompaniante_Pa;
        private String Parentezco_Pa;
        private DateTime FechaEntrevista_Pa;
        private Boolean CUD_Pa;
        private DateTime VencimientoCUD_Pa;
        private String MotivoConsulta_Pa;
        private Boolean Estado;
        private SituacionLaboral  CodSitLab_SL_Pa;
        private Acercamiento CodAcerc_A_Pa;
        // Constructor
        public Paciente() 
        { 
        }
        //Gets y Sets
        public string getDNIPac_Pa()
        {
            return this.DNIPac_Pa;
        }
        public void setDNIPac_Pa(string variable)
        {
            this.DNIPac_Pa = variable;
        }
        public string getNombreApellido_PA()
        {
            return this.NombreApellido_PA;
        }
        public void setNombreApellido_PA(string variable)
        {
            this.NombreApellido_PA = variable;
        }
        public string getEdad_PA()
        {
            return this.Edad_PA;
        }
        public void setEdad_PA(string variable)
        {
            this.Edad_PA = variable;
        }
        public string getNomAcompaniante_Pa()
        {
            return this.NomAcompaniante_Pa;
        }
        public void setNomAcompaniante_Pa(string variable)
        {
            this.NomAcompaniante_Pa = variable;
        }
        public string getParentezco_Pa()
        {
            return this.Parentezco_Pa;
        }
        public void setParentezco_Pa(string variable)
        {
            this.Parentezco_Pa = variable;
        }
        public DateTime getFechaEntrevista_Pa()
        {
            return this.FechaEntrevista_Pa;
        }
        public void setFechaEntrevista_Pa(DateTime variable)
        {
            this.FechaEntrevista_Pa = variable;
        }
        public bool getCUD_Pa()
        {
            return this.CUD_Pa;
        }
        public void setCUD_Pa(bool variable)
        {
            this.CUD_Pa = variable;
        }
        public DateTime getVencimientoCUD_Pa()
        {
            return this.VencimientoCUD_Pa;
        }
        public void setVencimientoCUD_Pa(DateTime variable)
        {
            this.VencimientoCUD_Pa = variable;
        }
        public string getMotivoConsulta_Pa()
        {
            return this.MotivoConsulta_Pa;
        }
        public void setMotivoConsulta_Pa(string variable)
        {
            this.MotivoConsulta_Pa = variable;
        }
        public Boolean getEstado()
        {
            return this.Estado;
        }
        public void setEstado(Boolean variable)
        {
            this.Estado = variable;
        }
        public SituacionLaboral getCodSitLab_SL_Pa()
        {
            return this.CodSitLab_SL_Pa;
        }
        public void setCodSitLab_SL_Pa(SituacionLaboral variable)
        {
            this.CodSitLab_SL_Pa = variable;
        }
        public Acercamiento getCodAcerc_A_Pa()
        {
            return this.CodAcerc_A_Pa;
        }
        public void setCodAcerc_A_Pa(Acercamiento variable)
        {
            this.CodAcerc_A_Pa = variable;
        }
    }
}
