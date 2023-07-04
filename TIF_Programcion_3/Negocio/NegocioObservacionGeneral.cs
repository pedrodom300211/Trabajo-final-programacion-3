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
    public class NegocioObservacionGeneral
    {
        public DataTable getTabla()
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            return dao.getTablaObservacionGeneral();
        }

        public DataTable getTablaDNI(String dni)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            ObservacionGeneral observacionGeneral = new ObservacionGeneral();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            observacionGeneral.setDNIPac_OG(pac);
            return dao.getTablaObservacionGeneralPorDNI(observacionGeneral);
        }
        public DataTable getTablaDNI2(String dni)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            ObservacionGeneral observacionGeneral = new ObservacionGeneral();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            observacionGeneral.setDNIPac_OG(pac);
            return dao.getTablaObservacionGeneralPorDNI2(observacionGeneral);
        }

        public DataTable getObservacionGeneral(String areas, String dni)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            ObservacionGeneral observacionGeneral = new ObservacionGeneral();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            observacionGeneral.setDescripcion_OG(areas);
            observacionGeneral.setDNIPac_OG(pac);
            return dao.obtenerObservacionesGeneralesEspecificosConFiltro(areas, dni);            
        }

        public ObservacionGeneral get(int id)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            ObservacionGeneral observacionGeneral = new ObservacionGeneral();
            observacionGeneral.setNumObser_OG(id);
            return dao.getObservacionGeneral(observacionGeneral);
        }
       
        public bool agregarObsGeneral(ObservacionGeneral obsGeneral)
        {
            int cantFilas = 0;
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            //if(dao.existeObservacionGeneral(obsGeneral)==false)
            //{
            //    cantFilas = dao.agregarObservacionGeneral(obsGeneral);
            //}
            cantFilas = dao.agregarObservacionGeneral(obsGeneral);
            if (cantFilas == 1)
                return true;
            else
                return false;
        }
        public ObservacionGeneral getAreaObservacionDNI(String dni)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();
            ObservacionGeneral observacionGeneral = new ObservacionGeneral();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            observacionGeneral.setDNIPac_OG(pac);
            return dao.getAreaObservacionGeneralDNI(observacionGeneral);
        }

        public bool ModificarObservacionGeneral(ObservacionGeneral observacionGeneral)
        {
            DaoObservacionGeneral dao = new DaoObservacionGeneral();          

            bool op = dao.actualizarObservacionesGenerales(observacionGeneral);
            if (op == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtenerTabla()
        {
            DaoObservacionGeneral observacionGeneral = new DaoObservacionGeneral();
            return observacionGeneral.obtenerObservacionesGenerales();
        }

        public DataTable obtenerTablaEspecifica(String dni, String numObser)
        {
            DaoObservacionGeneral observacionGeneral = new DaoObservacionGeneral();
            return observacionGeneral.obtenerObservacionesGeneralesConWhere(dni);
        }
        public bool ValidarExistePaciente(string dni)
        {
            DaoObservacionGeneral obsGeneral = new DaoObservacionGeneral();
            DaoPaciente paciente = new DaoPaciente();
            if(paciente.existePaciente(dni))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
