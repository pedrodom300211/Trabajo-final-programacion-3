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
    public class NegocioPaciente
    {
        public DataTable getTabla()
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPaciente();
        }

        public DataTable getTablaFiltro()
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPaciente();
        }
        public DataTable getTablaDNI(String dni)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente paciente = new Paciente();
            paciente.setDNIPac_Pa(dni);
            return dao.getTablaPacientePorDNI(paciente);
        }
        public DataTable getTablaDNILaborAcercamiento(String dni)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente paciente = new Paciente();
            paciente.setDNIPac_Pa(dni);
            return dao.getTablaPacientePorDNILaborAcercamiento(paciente);
        }
        public DataTable getTablaDNIFiltro(String dni,String simbolo)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente paciente = new Paciente();
            paciente.setDNIPac_Pa(dni);
            return dao.obtenerPacientesEspecificosConFiltro(dni,simbolo);
        }
        public Paciente getPaciente(String dni)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente paciente = new Paciente();
            paciente.setDNIPac_Pa(dni);
            return dao.getPaciente(paciente);
        }
        public bool agregarPaciente(Paciente paciente/*String nombre*/)
        {
            int cantFilas = 0;
            DaoPaciente dao = new DaoPaciente();
            if (dao.existePaciente(paciente) == false)
            {
                cantFilas = dao.agregarPaciente(paciente);
            }
            if (cantFilas == 1)
                return true;
            else
                return false;
        }

         public bool BajaPaciente(String dni)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente paciente = new Paciente();

            paciente.setDNIPac_Pa(dni);
            int op = dao.BajaLogicaPaciente(paciente);
            if (op == 2) // SE PUSO 2 DEBIDO A QUE DEVUELVE DOS FILAS AFECTADAS
                return true;
            else
                return false;
        }

        public bool ModificarPaciente(Paciente paciente)
        {
            DaoPaciente dao = new DaoPaciente();

            bool op = dao.actualizarPacientes(paciente);
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
            DaoPaciente dao = new DaoPaciente();
            return dao.obtenerPacientes();
        }
        public DataTable obtenerTablaEspecifica(String dni)
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.obtenerPacientesEspecificos(dni);
        }

        public DataTable obtenerTablaEspecificaConFiltro(String dni, String simbolo) {
            DaoPaciente dao = new DaoPaciente();
            return dao.obtenerPacientesEspecificosConFiltro(dni, simbolo); 
        }
    }
}
