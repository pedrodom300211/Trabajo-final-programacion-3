using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComposicionFamiliar
    {

        //Atributos
        private String DNIFAM_CF;
        private Paciente DNIPAC_CF;
        private String NombreFamiliar_CF;
        private String EdadFamiliar_CF;
        private String OcupacionFaimiliar_CF;
        private Boolean ConviveFamiliar_CF;
        private String TelefonoFamiliar_CF;
        private String ParentescoFamiliar_CF;

        //Constructor vacio
        public ComposicionFamiliar() 
        { 
        }

        //Getters And Setters

        //Getters
        public String getDNIFAM_CF() {
            return this.DNIFAM_CF; 
        }

        public Paciente getDNIPAC_CF()
        {
            return this.DNIPAC_CF;
        }

        public String getNombreFamiliar_CF()
        {
            return this.NombreFamiliar_CF;
        }

        public String getEdadFamiliar_CF()
        {
            return this.EdadFamiliar_CF;
        }

        public String getOcupacionFamiliar_CF()
        {
            return this.OcupacionFaimiliar_CF;
        }

        public bool getConviveFamiliar_CF() {
            return this.ConviveFamiliar_CF; 
        }

        public String getTelefonoFamiliar_CF()
        {
            return this.TelefonoFamiliar_CF;
        }

        public String getParentescoFamiliar_CF()
        {
            return this.ParentescoFamiliar_CF;
        }

        //Setters
        public void setDNIFAM_CF(String DNIFAM)
        {
            this.DNIFAM_CF = DNIFAM;
        }

        public void setDNIPAC_CF(Paciente DNIPAC)
        {
            this.DNIPAC_CF = DNIPAC;
        }

        public void setNombreFamiliar_CF(String NombreFamiliar)
        {
            this.NombreFamiliar_CF = NombreFamiliar;
        }

        public void setEdadFamiliar_CF(String EdadFamiliar)
        {
            this.EdadFamiliar_CF = EdadFamiliar;
        }

        public void setOcupacionFamiliar_CF(String OcupacionFamiliar)
        {
            this.OcupacionFaimiliar_CF = OcupacionFamiliar;
        }

        public void setConviveFamiliar_CF(Boolean ConviveFamiliar) {
            this.ConviveFamiliar_CF = ConviveFamiliar;
        }

        public void setTelefonoFamiliar_CF(String TelefonoFamiliar)
        {
            this.TelefonoFamiliar_CF = TelefonoFamiliar;
        }

        public void setParentescoFamiliar(String ParentescoFamiliar)
        {
            this.ParentescoFamiliar_CF = ParentescoFamiliar;
        }

    }
}
