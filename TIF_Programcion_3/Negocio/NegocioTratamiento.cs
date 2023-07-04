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
    public class NegocioTratamiento
    {
        public DataTable getTabla()
        {
            DaoTratamiento dao = new DaoTratamiento();
            return dao.getTablaTratamiento();
        }

        public DataTable getTablaDNI(String dni)
        {
            DaoTratamiento dao = new DaoTratamiento();
            Tratamientos tratamiento = new Tratamientos();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            tratamiento.setDNIPac_Tr(pac);
            return dao.getTablaTratamientoPorDNI(tratamiento);
        }
        public bool agregarTratamiento(Tratamientos tratamientos/*String nombre*/)
        {
            int cantFilas = 0;

            DaoTratamiento dao = new DaoTratamiento();
          
            cantFilas = dao.agregarTratamiento(tratamientos);
            if (cantFilas == 1)
                return true;
            else
                return false;
        }
        public bool verificarDNI(string dni)
        {
            DaoPaciente dp = new DaoPaciente();
            bool estado;
            estado = dp.existePaciente(dni);
                return estado;

        }

        public DataTable getTratamiento(String droga, String dni)
        {
            DaoTratamiento daoTratamiento = new DaoTratamiento();
            Tratamientos tratamientos = new Tratamientos();
            Paciente pac = new Paciente();
            pac.setDNIPac_Pa(dni);
            tratamientos.setDroga_Tr(droga);
            tratamientos.setDNIPac_Tr(pac);
            return daoTratamiento.obtenerTratamientosEspecificosConFiltro(droga, dni);
        }

        public Tratamientos get(int id)
        {
            DaoTratamiento dao = new DaoTratamiento();
            Tratamientos tratamiento = new Tratamientos();
            tratamiento.setNumTram_Tr(id);
            return dao.getTratamiento(tratamiento);
        }

        public bool MOdificarNegocioTratamiento(Tratamientos tratamientos)
        {
            DaoTratamiento dao = new DaoTratamiento();

            bool op = dao.actualizarTratamiento(tratamientos);
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
            DaoTratamiento dao = new DaoTratamiento();
            return dao.obtenerTratamientos();
        }

        public DataTable obtenerTablaEspecifica(String dni)
        {
            DaoTratamiento dao = new DaoTratamiento();
            return dao.obtenerTratamientosEspecificos(dni);
        }
    }
}

